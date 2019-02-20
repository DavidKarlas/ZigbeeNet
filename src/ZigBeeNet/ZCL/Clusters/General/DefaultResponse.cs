﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.General;

/**
 * Default Response value object class.
 *
 * Cluster: General. Command is sentTO the server.
 * This command is a generic command used across the profile.
 *
 * The default response command is generated when a device receives a unicast * command, there is no other relevant response specified for the command, and * either an error results or the Disable default response bit of its Frame control field * is set to 0. *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.General
{
       public class DefaultResponse : ZclCommand
       {
           /**
           * Command identifier command message field.
           */
           public byte CommandIdentifier { get; set; }

           /**
           * Status code command message field.
           */
           public ZclStatus StatusCode { get; set; }


           /**
           * Default constructor.
           */
           public DefaultResponse()
           {
               GenericCommand = true;
               CommandId = 11;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(CommandIdentifier, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(StatusCode, ZclDataType.Get(DataType.ZCL_STATUS));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               CommandIdentifier = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
               StatusCode = deserializer.Deserialize<ZclStatus>(ZclDataType.Get(DataType.ZCL_STATUS));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("DefaultResponse [");
               builder.Append(base.ToString());
               builder.Append(", CommandIdentifier=");
               builder.Append(CommandIdentifier);
               builder.Append(", StatusCode=");
               builder.Append(StatusCode);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
