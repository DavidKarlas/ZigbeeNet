﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.General;

/**
 * Write Attributes Command value object class.
 *
 * Cluster: General. Command is sentTO the server.
 * This command is a generic command used across the profile.
 *
 * The write attributes command is generated when a device wishes to change the * values of one or more attributes located on another device. Each write attribute * record shall contain the identifier and the actual value of the attribute to be * written. *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.General
{
       public class WriteAttributesCommand : ZclCommand
       {
           /**
           * Records command message field.
           */
           public List<WriteAttributeRecord> Records { get; set; }


           /**
           * Default constructor.
           */
           public WriteAttributesCommand()
           {
               GenericCommand = true;
               CommandId = 2;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Records, ZclDataType.Get(DataType.N_X_WRITE_ATTRIBUTE_RECORD));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Records = deserializer.Deserialize<List<WriteAttributeRecord>>(ZclDataType.Get(DataType.N_X_WRITE_ATTRIBUTE_RECORD));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("WriteAttributesCommand [");
               builder.Append(base.ToString());
               builder.Append(", Records=");
               builder.Append(Records);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
