﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Alarms;

/**
 * Get Alarm Response value object class.
 *
 * Cluster: Alarms. Command is sentFROM the server.
 * This command is a specific command used for the Alarms cluster.
 *
 * If there is at least one alarm record in the alarm table then the status field is set to SUCCESS. * The alarm code, cluster identifier and time stamp fields SHALL all be present and SHALL take their * values from the item in the alarm table that they are reporting.If there  are  no more  alarms logged * in the  alarm table  then the  status field is set  to NOT_FOUND  and the alarm code, cluster * identifier and time stamp fields SHALL be omitted. *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.Alarms
{
       public class GetAlarmResponse : ZclCommand
       {
           /**
           * Status command message field.
           */
           public byte Status { get; set; }

           /**
           * Alarm code command message field.
           */
           public byte AlarmCode { get; set; }

           /**
           * Cluster identifier command message field.
           */
           public ushort ClusterIdentifier { get; set; }

           /**
           * Timestamp command message field.
           */
           public uint Timestamp { get; set; }


           /**
           * Default constructor.
           */
           public GetAlarmResponse()
           {
               GenericCommand = false;
               ClusterId = 9;
               CommandId = 1;
               CommandDirection = ZclCommandDirection.SERVER_TO_CLIENT;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Status, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(AlarmCode, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(ClusterIdentifier, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(Timestamp, ZclDataType.Get(DataType.UNSIGNED_32_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Status = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               AlarmCode = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               ClusterIdentifier = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               Timestamp = deserializer.Deserialize<uint>(ZclDataType.Get(DataType.UNSIGNED_32_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("GetAlarmResponse [");
               builder.Append(base.ToString());
               builder.Append(", Status=");
               builder.Append(Status);
               builder.Append(", AlarmCode=");
               builder.Append(AlarmCode);
               builder.Append(", ClusterIdentifier=");
               builder.Append(ClusterIdentifier);
               builder.Append(", Timestamp=");
               builder.Append(Timestamp);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
