﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.IASWD;

/**
 * Squawk Command value object class.
 *
 * Cluster: IAS WD. Command is sentTO the server.
 * This command is a specific command used for the IAS WD cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

/* Autogenerated: 18.02.2019 - 16:46 */
namespace ZigBeeNet.ZCL.Clusters.IASWD
{
       public class SquawkCommand : ZclCommand
       {
           /**
           * Header command message field.
           */
           public byte Header { get; set; }


           /**
           * Default constructor.
           */
           public SquawkCommand()
           {
               GenericCommand = false;
               ClusterId = 1282;
               CommandId = 2;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Header, ZclDataType.Get(DataType.DATA_8_BIT));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Header = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.DATA_8_BIT));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("SquawkCommand [");
               builder.Append(base.ToString());
               builder.Append(", Header=");
               builder.Append(Header);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
