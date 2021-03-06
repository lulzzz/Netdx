﻿using Kaitai;
using Microsoft.Extensions.CommandLineUtils;
using Netdx.ConversationTracker;
using Netdx.Packets.Core;
using Netdx.Packets.IoT;
using PacketDotNet;
using SharpPcap;
using System;
using System.IO;
using System.Linq;

namespace Netdx.Examples.DnsCheck
{
    /// <summary>
    /// Dumps the events as simple text output.
    /// </summary>
    class DumpDnsEvents
    {
        internal static readonly string Name = "dump-events";
        private static IOutputFormatter outputFormatter;

        public static Action<CommandLineApplication> Configuration =>
            (CommandLineApplication target) =>
            {

                var debug = target.Option("-d", "Enable debug mode.", CommandOptionType.NoValue);
                var inputFile = target.Option("-r", "Read packet data from infile, can be any supported capture file format (including gzipped files).", CommandOptionType.SingleValue);
                var captureInterface = target.Option("-i", "Set the name of the network interface or pipe to use for live packet capture.", CommandOptionType.SingleValue);
                var outputFormat = target.Option("-T", "Set the format of the output when viewing decoded packet data.", CommandOptionType.SingleValue);
                var outputFile = target.Option("-w", "Write the output to the specified file.", CommandOptionType.SingleValue);
                target.Description = "Dumps LwM2M events to simple text output format.";
                target.OnExecute(() =>
                {
                    if (!inputFile.HasValue() && !captureInterface.HasValue())
                    {
                        throw new ArgumentException("Either input file (-r <infile>) or capture interface (-i <capint>) must be specified.");
                    }

                    ICaptureDevice inputDevice = null;
                    if (inputFile.HasValue())
                    {
                        inputDevice = new SharpPcap.LibPcap.CaptureFileReaderDevice(inputFile.Value());
                    }
                    if (captureInterface.HasValue())
                    {
                        if (Int32.TryParse(captureInterface.Value(), out int interfaceIndex))
                        {
                            if (interfaceIndex < CaptureDeviceList.Instance.Count)
                            {
                                inputDevice = CaptureDeviceList.Instance[interfaceIndex];
                            }
                            else
                            {
                                throw new ArgumentException($"Interface index: {captureInterface.Value()} is invalid. This value should be between 0 and {CaptureDeviceList.Instance.Count - 1}. Use print-interfaces command to see available options.");
                            }
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid interface index: {captureInterface.Value()}. This should be an integer value between 0 and {CaptureDeviceList.Instance.Count - 1}. Use print-interfaces command to see available options.");
                        }
                    }

                    var outstream = outputFile.HasValue() ? File.OpenWrite(outputFile.Value()) : Console.OpenStandardOutput();

                    outputFormatter = null;
                    switch (outputFormat.Value() ?? "text")
                    {
                        case "json": throw new NotImplementedException();
                        case "csv": throw new NotImplementedException();
                        case "text": outputFormatter = new TextOutputFormatter(outstream); break;
                        default: throw new ArgumentException($"Unknown output format  {outputFormat.Value()}. Available formats are json|csv|text.");
                    }

                    Console.WriteLine($"Processing {inputDevice.Description} -> {outputFormatter}");
                    Execute(inputDevice, outputFormatter);
                    return 0;
                });
            };

        public static void Execute(ICaptureDevice device, IOutputFormatter output)
        {
            device.OnPacketArrival += Device_OnPacketArrival;
            device.Open();
            device.Filter = "port 53";
            device.Capture();
            device.Close();
        }


        private static void Device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            try
            {
                var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                var ip = packet.Extract(typeof(IpPacket)) as IpPacket;
                var udp = packet.Extract(typeof(UdpPacket)) as UdpPacket;

                var flowKey = new FlowKey()
                {
                    Protocol = ProtocolType.UDP,
                    SourceEndpoint = new System.Net.IPEndPoint(ip.SourceAddress, udp.SourcePort),
                    DestinationEndpoint = new System.Net.IPEndPoint(ip.DestinationAddress, udp.DestinationPort)
                };

                var str = new KaitaiStream(udp.PayloadData);
                var dns = new DnsPacket(str);
                outputFormatter.WriteRecord(e.Packet.Timeval, flowKey, dns);
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine($"{e.Packet.Timeval.Date}: Unable to parse packet.");
            }
        }
    }
}
