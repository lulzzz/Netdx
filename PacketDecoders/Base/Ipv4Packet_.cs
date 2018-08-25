﻿using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Text;

namespace Netdx.PacketDecoders.Base
{
    public partial class Ipv4Packet
    {
        static class IPv4Fields
        {
            /// <summary> Width of the IP version and header length field in bytes.</summary>
            public static readonly Int32 VersionAndHeaderLengthLength = 1;

            /// <summary> Width of the Differentiated Services / Type of service field in bytes.</summary>
            public static readonly Int32 DifferentiatedServicesLength = 1;

            /// <summary> Width of the total length field in bytes.</summary>
            public static readonly Int32 TotalLengthLength = 2;

            /// <summary> Width of the ID field in bytes.</summary>
            public static readonly Int32 IdLength = 2;

            /// <summary> Width of the fragment offset bits and offset field in bytes.</summary>
            public static readonly Int32 FragmentOffsetAndFlagsLength = 2;

            /// <summary> Width of the TTL field in bytes.</summary>
            public static readonly Int32 TtlLength = 1;

            /// <summary> Width of the IP protocol code in bytes.</summary>
            public static readonly Int32 ProtocolLength = 1;

            /// <summary> Width of the IP checksum in bytes.</summary>
            public static readonly Int32 ChecksumLength = 2;

            /// <summary> Position of the version code and header length within the IP header.</summary>
            public static readonly Int32 VersionAndHeaderLengthPosition = 0;

            /// <summary> Position of the differentiated services value within the IP header.</summary>
            public static readonly Int32 DifferentiatedServicesPosition;

            /// <summary> Position of the header length within the IP header.</summary>
            public static readonly Int32 TotalLengthPosition;

            /// <summary> Position of the packet ID within the IP header.</summary>
            public static readonly Int32 IdPosition;

            /// <summary> Position of the flag bits and fragment offset within the IP header.</summary>
            public static readonly Int32 FragmentOffsetAndFlagsPosition;

            /// <summary> Position of the ttl within the IP header.</summary>
            public static readonly Int32 TtlPosition;

            /// <summary>
            /// Position of the protocol used within the IP data
            /// </summary>
            public static readonly Int32 ProtocolPosition;

            /// <summary> Position of the checksum within the IP header.</summary>
            public static readonly Int32 ChecksumPosition;

            /// <summary> Position of the source IP address within the IP header.</summary>
            public static readonly Int32 SourcePosition;

            /// <summary> Position of the destination IP address within a packet.</summary>
            public static readonly Int32 DestinationPosition;

            /// <summary> Length in bytes of an IP header, excluding options.</summary>
            public static readonly Int32 HeaderLength; // == 20

            /// <summary>
            /// Number of bytes in an IPv4 address
            /// </summary>
            public static readonly Int32 AddressLength = 4;

            static IPv4Fields()
            {
                DifferentiatedServicesPosition = VersionAndHeaderLengthPosition + VersionAndHeaderLengthLength;
                TotalLengthPosition = DifferentiatedServicesPosition + DifferentiatedServicesLength;
                IdPosition = TotalLengthPosition + TotalLengthLength;
                FragmentOffsetAndFlagsPosition = IdPosition + IdLength;
                TtlPosition = FragmentOffsetAndFlagsPosition + FragmentOffsetAndFlagsLength;
                ProtocolPosition = TtlPosition + TtlLength;
                ChecksumPosition = ProtocolPosition + ProtocolLength;
                SourcePosition = ChecksumPosition + ChecksumLength;
                DestinationPosition = SourcePosition + AddressLength;
                HeaderLength = DestinationPosition + AddressLength;
            }
        }
                                   
        public static Byte Protocol(Span<Byte> ipBytes)
        {
            return ipBytes[IPv4Fields.ProtocolPosition];
        }
        public static Span<byte> SourceAddress(Span<Byte> ipBytes)
        {
            return ipBytes.Slice(IPv4Fields.SourcePosition, IPv4Fields.AddressLength);
        }
        public static Span<byte> DestinationAddress(Span<Byte> ipBytes)
        {
            return ipBytes.Slice(IPv4Fields.DestinationPosition, IPv4Fields.AddressLength);
        }
        public static Byte HeaderLength(Span<Byte> ipBytes)
        {
            return (byte)(ipBytes[IPv4Fields.VersionAndHeaderLengthPosition] & 0x0F);
        }

        public static Span<Byte> PayloadBytes(Span<Byte> ipBytes)
        {
            var hdrLen = HeaderLength(ipBytes);
            var totalLen = TotalLength(ipBytes);
            return ipBytes.Slice(HeaderLength(ipBytes), hdrLen - totalLen);
        }

        private static UInt16 TotalLength(Span<byte> ipBytes)
        {
            return BinaryPrimitives.ReadUInt16BigEndian(ipBytes.Slice(IPv4Fields.TotalLengthPosition));
        }
    }
}
