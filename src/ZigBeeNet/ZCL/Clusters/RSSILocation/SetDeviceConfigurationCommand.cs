﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.RSSILocation;

/**
 * Set Device Configuration Command value object class.
 *
 * Cluster: RSSI Location. Command is sentTO the server.
 * This command is a specific command used for the RSSI Location cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.RSSILocation
{
       public class SetDeviceConfigurationCommand : ZclCommand
       {
           /**
           * Power command message field.
           */
           public short Power { get; set; }

           /**
           * Path Loss Exponent command message field.
           */
           public ushort PathLossExponent { get; set; }

           /**
           * Calculation Period command message field.
           */
           public ushort CalculationPeriod { get; set; }

           /**
           * Number RSSI Measurements command message field.
           */
           public byte NumberRSSIMeasurements { get; set; }

           /**
           * Reporting Period command message field.
           */
           public ushort ReportingPeriod { get; set; }


           /**
           * Default constructor.
           */
           public SetDeviceConfigurationCommand()
           {
               GenericCommand = false;
               ClusterId = 11;
               CommandId = 1;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Power, ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
            serializer.Serialize(PathLossExponent, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(CalculationPeriod, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(NumberRSSIMeasurements, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(ReportingPeriod, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Power = deserializer.Deserialize<short>(ZclDataType.Get(DataType.SIGNED_16_BIT_INTEGER));
               PathLossExponent = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               CalculationPeriod = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               NumberRSSIMeasurements = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
               ReportingPeriod = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("SetDeviceConfigurationCommand [");
               builder.Append(base.ToString());
               builder.Append(", Power=");
               builder.Append(Power);
               builder.Append(", PathLossExponent=");
               builder.Append(PathLossExponent);
               builder.Append(", CalculationPeriod=");
               builder.Append(CalculationPeriod);
               builder.Append(", NumberRSSIMeasurements=");
               builder.Append(NumberRSSIMeasurements);
               builder.Append(", ReportingPeriod=");
               builder.Append(ReportingPeriod);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
