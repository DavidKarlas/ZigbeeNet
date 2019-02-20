﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.General;

/**
 * Discover Attributes Extended value object class.
 *
 * Cluster: General. Command is sentTO the server.
 * This command is a generic command used across the profile.
 *
 * The Discover Attributes Extended command is generated when a remote device wishes to discover the * identifiers and types of the attributes on a device which are supported within the cluster to which this * command is directed, including whether the attribute is readable, writeable or reportable. *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.General
{
       public class DiscoverAttributesExtended : ZclCommand
       {
           /**
           * Start attribute identifier command message field.
           */
           public ushort StartAttributeIdentifier { get; set; }

           /**
           * Maximum attribute identifiers command message field.
           */
           public byte MaximumAttributeIdentifiers { get; set; }


           /**
           * Default constructor.
           */
           public DiscoverAttributesExtended()
           {
               GenericCommand = true;
               CommandId = 21;
               CommandDirection = ZclCommandDirection.CLIENT_TO_SERVER;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(StartAttributeIdentifier, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(MaximumAttributeIdentifiers, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               StartAttributeIdentifier = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               MaximumAttributeIdentifiers = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("DiscoverAttributesExtended [");
               builder.Append(base.ToString());
               builder.Append(", StartAttributeIdentifier=");
               builder.Append(StartAttributeIdentifier);
               builder.Append(", MaximumAttributeIdentifiers=");
               builder.Append(MaximumAttributeIdentifiers);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
