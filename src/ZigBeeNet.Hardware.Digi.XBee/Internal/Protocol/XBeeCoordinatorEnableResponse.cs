//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Digi.XBee.Internal.Protocol
{
    
    
    /// <summary>
    /// Class to implement the XBee command " Coordinator Enable ".
    /// AT Command <b>CE</b></p>Sets or displays whether the device is a coordinator. (SM must be 0
    /// to set CE to 1). 
    /// This class provides methods for processing XBee API commands.
    /// </summary>
    public class XBeeCoordinatorEnableResponse : XBeeFrame, IXBeeResponse 
    {
        
        /// <summary>
        /// Response field
        /// </summary>
        private int _frameId;
        
        /// <summary>
        /// Response field
        /// </summary>
        private CommandStatus _commandStatus;
        
        /// <summary>
        /// Response field
        /// </summary>
        private bool _enable;
        
        /// <summary>
        ///  Return the frameId as <see cref="System.Int32"/>
        /// </summary>
        public int GetFrameId()
        {
            return _frameId;
        }
        
        /// <summary>
        ///  Return the commandStatus as <see cref="CommandStatus"/>
        /// </summary>
        public CommandStatus GetCommandStatus()
        {
            return _commandStatus;
        }
        
        /// <summary>
        ///  Return the enable as <see cref="System.Boolean"/>
        /// </summary>
        public bool GetEnable()
        {
            return _enable;
        }
        
        /// <summary>
        /// Method for deserializing the fields for the response </summary>
        public void Deserialize(int[] incomingData)
        {
            InitializeDeserializer(incomingData);
            _frameId = DeserializeInt8();
            DeserializeAtCommand();
            _commandStatus = DeserializeCommandStatus();
            if (_commandStatus != CommandStatus.OK || IsComplete())
            {
                    return;
            }
            _enable = DeserializeBoolean();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder(479);
            builder.Append("XBeeCoordinatorEnableResponse [frameId=");
            builder.Append(_frameId);
            builder.Append(", commandStatus=");
            builder.Append(_commandStatus);
            builder.Append(_enable);
            builder.Append(']');
            return builder.ToString();
        }
    }
}