using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZigBeeNet.ZCL;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZDO.Field;


namespace ZigBeeNet.ZDO.Command
{
    /// <summary>
    /// Match Descriptor Response value object class.
    ///
    ///
    /// The Match_Desc_rsp is generated by a remote device in response to a Match_Desc_req
    /// either broadcast or directed to the remote device. This command shall be unicast to the
    /// originator of the Match_Desc_req command.
    ///
    /// Code is auto-generated. Modifications may be overwritten!
    /// </summary>
    public class MatchDescriptorResponse : ZdoResponse
    {
        /// <summary>
        /// The ZDO cluster ID.
        /// </summary>
        public const ushort CLUSTER_ID = 0x8006;

        /// <summary>
        /// NWK Addr Of Interest command message field.
        /// </summary>
        public ushort NwkAddrOfInterest { get; set; }

        /// <summary>
        /// Match List command message field.
        /// </summary>
        public List<byte> MatchList { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MatchDescriptorResponse()
        {
            ClusterId = CLUSTER_ID;
        }

        internal override void Serialize(ZclFieldSerializer serializer)
        {
            base.Serialize(serializer);

            serializer.Serialize(Status, ZclDataType.Get(DataType.ZDO_STATUS));
            serializer.Serialize(NwkAddrOfInterest, ZclDataType.Get(DataType.NWK_ADDRESS));
            serializer.Serialize(MatchList.Count, ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            for (int cnt = 0; cnt < MatchList.Count; cnt++)
            {
                serializer.Serialize(MatchList[cnt], ZclDataType.Get(DataType.ENDPOINT));
            }
        }

        internal override void Deserialize(ZclFieldDeserializer deserializer)
        {
            base.Deserialize(deserializer);

            // Create lists
            MatchList = new List<byte>();

            Status = deserializer.Deserialize<ZdoStatus>(ZclDataType.Get(DataType.ZDO_STATUS));
            if (Status != ZdoStatus.SUCCESS)
            {
                // Don't read the full response if we have an error
                return;
            }
            NwkAddrOfInterest = deserializer.Deserialize<ushort>(ZclDataType.Get(DataType.NWK_ADDRESS));
            byte? matchLength = (byte?) deserializer.Deserialize(ZclDataType.Get(DataType.UNSIGNED_8_BIT_INTEGER));
            if (matchLength != null)
            {
                for (int cnt = 0; cnt < matchLength; cnt++)
                {
                    MatchList.Add((byte) deserializer.Deserialize(ZclDataType.Get(DataType.ENDPOINT)));
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append("MatchDescriptorResponse [");
            builder.Append(base.ToString());
            builder.Append(", Status=");
            builder.Append(Status);
            builder.Append(", NwkAddrOfInterest=");
            builder.Append(NwkAddrOfInterest);
            builder.Append(", MatchList=");
            builder.Append(MatchList == null? "" : string.Join(", ", MatchList));
            builder.Append(']');

            return builder.ToString();
        }
    }
}
