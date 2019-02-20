﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.RSSILocation;

/**
 * RSSI Response value object class.
 *
 * Cluster: RSSI Location. Command is sentTO the server.
 * This command is a specific command used for the RSSI Location cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.RSSILocation
{
       public class RSSIResponse : ZclCommand
       {
           /**
           * Replying Device command message field.
           */
           public IeeeAddress ReplyingDevice { get; set; }

           /**
           * Coordinate 1 command message field.
           */
           public short Coordinate1 { get; set; }

           /**
           * Coordinate 2 command message field.
           */
           public short Coordinate2 { get; set; }

           /**
           * Coordinate 3 command message field.
           */
           public short Coordinate3 { get; set; }

           /**
           * RSSI command message field.
           */
           public sbyte RSSI { get; set; }

           /**
           * Number RSSI Measurements command message field.
           */
           public byte NumberRSSIMeasurements { get; set; }


           /**
           * Default constructor.
           */
           public RSSIResponse()
           {
               GenericCommand = false;
               ClusterId = 11;
               CommandId = 4;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(ReplyingDevice, ZclDataType.Get(DataType.IEEE_ADDRESS));
            serializer.Serialize(Coordinate1, ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
            serializer.Serialize(Coordinate2, ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
            serializer.Serialize(Coordinate3, ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
            serializer.Serialize(RSSI, ZclDataType.Get(DataType.SIGNED_8_BIT_INTEGER));
            serializer.Serialize(NumberRSSIMeasurements, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               ReplyingDevice = deserializer.Deserialize<IeeeAddress>(ZclDataType.Get(DataType.IEEE_ADDRESS));
               Coordinate1 = deserializer.Deserialize<short>(ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
               Coordinate2 = deserializer.Deserialize<short>(ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
               Coordinate3 = deserializer.Deserialize<short>(ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
               RSSI = deserializer.Deserialize<sbyte>(ZclDataType.Get(DataType.SIGNED_8_BIT_INTEGER));
               NumberRSSIMeasurements = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("RSSIResponse [");
               builder.Append(base.ToString());
               builder.Append(", ReplyingDevice=");
               builder.Append(ReplyingDevice);
               builder.Append(", Coordinate1=");
               builder.Append(Coordinate1);
               builder.Append(", Coordinate2=");
               builder.Append(Coordinate2);
               builder.Append(", Coordinate3=");
               builder.Append(Coordinate3);
               builder.Append(", RSSI=");
               builder.Append(RSSI);
               builder.Append(", NumberRSSIMeasurements=");
               builder.Append(NumberRSSIMeasurements);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
