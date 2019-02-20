﻿// License text here
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZCL.Clusters.Scenes;

/**
 * View Scene Response value object class.
 *
 * Cluster: Scenes. Command is sentFROM the server.
 * This command is a specific command used for the Scenes cluster.
 *
 * Code is auto-generated. Modifications may be overwritten!
 */

namespace ZigBeeNet.ZCL.Clusters.Scenes
{
       public class ViewSceneResponse : ZclCommand
       {
           /**
           * Status command message field.
           */
           public byte Status { get; set; }

           /**
           * Group ID command message field.
           */
           public ushort GroupID { get; set; }

           /**
           * Scene ID command message field.
           */
           public byte SceneID { get; set; }

           /**
           * Transition time command message field.
           */
           public ushort TransitionTime { get; set; }

           /**
           * Scene Name command message field.
           */
           public string SceneName { get; set; }

           /**
           * Extension field sets command message field.
           */
           public List<ExtensionFieldSet> ExtensionFieldSets { get; set; }


           /**
           * Default constructor.
           */
           public ViewSceneResponse()
           {
               GenericCommand = false;
               ClusterId = 5;
               CommandId = 1;
               CommandDirection = ZclCommandDirection.SERVER_TO_CLIENT;
           }

           public override void Serialize(ZclFieldSerializer serializer)
           {
            serializer.Serialize(Status, ZclDataType.Get(DataType.ENUMERATION_8_BIT));
            serializer.Serialize(GroupID, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(SceneID, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            serializer.Serialize(TransitionTime, ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
            serializer.Serialize(SceneName, ZclDataType.Get(DataType.CHARACTER_STRING));
            serializer.Serialize(ExtensionFieldSets, ZclDataType.Get(DataType.N_X_EXTENSION_FIELD_SET));
           }

           public override void Deserialize(ZclFieldDeserializer deserializer)
           {
               Status = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.ENUMERATION_8_BIT));
               GroupID = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               SceneID = deserializer.Deserialize<byte>(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
               TransitionTime = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.UNSIGNED_16_BIT_INTEGER));
               SceneName = deserializer.Deserialize<string>(ZclDataType.Get(DataType.CHARACTER_STRING));
               ExtensionFieldSets = deserializer.Deserialize<List<ExtensionFieldSet>>(ZclDataType.Get(DataType.N_X_EXTENSION_FIELD_SET));
           }

           public override string ToString()
           {
               var builder = new StringBuilder();

               builder.Append("ViewSceneResponse [");
               builder.Append(base.ToString());
               builder.Append(", Status=");
               builder.Append(Status);
               builder.Append(", GroupID=");
               builder.Append(GroupID);
               builder.Append(", SceneID=");
               builder.Append(SceneID);
               builder.Append(", TransitionTime=");
               builder.Append(TransitionTime);
               builder.Append(", SceneName=");
               builder.Append(SceneName);
               builder.Append(", ExtensionFieldSets=");
               builder.Append(ExtensionFieldSets);
               builder.Append(']');

               return builder.ToString();
           }

       }
}
