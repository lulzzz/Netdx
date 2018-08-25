﻿using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Text;

namespace Netdx.PacketDecoders.Base
{
    public partial class EthernetFrame
    {
        /// <summary>
        /// Ethernet protocol field encoding information.
        /// </summary>
        static class EthernetFields
        {
            /// <summary> Position of the destination MAC address within the ethernet header.</summary>
            public static readonly Int32 DestinationMacPosition = 0;

            /// <summary> Total length of an ethernet header in bytes.</summary>
            public static readonly Int32 HeaderLength; // == 14

            /// <summary>
            /// size of an ethernet mac address in bytes
            /// </summary>
            public static readonly Int32 MacAddressLength = 6;

            /// <summary> Position of the source MAC address within the ethernet header.</summary>
            public static readonly Int32 SourceMacPosition;

            /// <summary> Width of the ethernet type code in bytes.</summary>
            public static readonly Int32 TypeLength = 2;

            /// <summary> Position of the ethernet type field within the ethernet header.</summary>
            public static readonly Int32 TypePosition;

            static EthernetFields()
            {
                SourceMacPosition = MacAddressLength;
                TypePosition = MacAddressLength * 2;
                HeaderLength = TypePosition + TypeLength;
            }
        }
        public static Span<Byte> PayloadBytes(Span<Byte> etherBytes)
        {
            return etherBytes.Slice(EthernetFields.HeaderLength);
        }
        public static Int16 EtherType(Span<Byte> etherBytes)
        {
            return BinaryPrimitives.ReadInt16BigEndian(etherBytes.Slice(EthernetFields.TypePosition));
        }
        public static Span<Byte> SourceMacAddress(Span<Byte> etherBytes)
        {
            return etherBytes.Slice(EthernetFields.SourceMacPosition);
        }
        public static Span<Byte> DestinationMacAddress(Span<Byte> etherBytes)
        {
            return etherBytes.Slice(EthernetFields.DestinationMacPosition);
        }
    }
}
