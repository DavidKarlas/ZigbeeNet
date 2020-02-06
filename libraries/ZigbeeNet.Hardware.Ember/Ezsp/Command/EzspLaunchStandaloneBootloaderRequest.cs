//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:3.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Ember.Ezsp.Command
{
    using ZigBeeNet.Hardware.Ember.Internal.Serializer;
    
    
    /// <summary>
    /// Class to implement the Ember EZSP command " launchStandaloneBootloader ".
    /// Quits the current application and launches the standalone bootloader (if installed) The
    /// function returns an error if the standalone bootloader is not present
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspLaunchStandaloneBootloaderRequest : EzspFrameRequest
    {
        
        public const int FRAME_ID = 143;
        
        /// <summary>
        ///  Controls the mode in which the standalone bootloader will run. See the app. note for full
        /// details. Options are: STANDALONE_BOOTLOADER_NORMAL_MODE: Will listen for an
        /// over-the-air image transfer on the current channel with current power settings.
        /// STANDALONE_BOOTLOADER_RECOVERY_MODE: Will listen for an over-the-air im-age transfer
        /// on the default channel with default power settings. Both modes also allow an image transfer
        /// to begin with XMODEM over the serial protocol's Bootloader Frame.
        /// </summary>
        private int _mode;
        
        private EzspSerializer _serializer;
        
        public EzspLaunchStandaloneBootloaderRequest()
        {
            _frameId = FRAME_ID;
            _serializer = new EzspSerializer();
        }
        
        /// <summary>
        /// The mode to set as <see cref="uint8_t"/> </summary>
        public void SetMode(int mode)
        {
            _mode = mode;
        }
        
        /// <summary>
        ///  Controls the mode in which the standalone bootloader will run. See the app. note for full
        /// details. Options are: STANDALONE_BOOTLOADER_NORMAL_MODE: Will listen for an
        /// over-the-air image transfer on the current channel with current power settings.
        /// STANDALONE_BOOTLOADER_RECOVERY_MODE: Will listen for an over-the-air im-age transfer
        /// on the default channel with default power settings. Both modes also allow an image transfer
        /// to begin with XMODEM over the serial protocol's Bootloader Frame.
        /// Return the mode as <see cref="System.Int32"/>
        /// </summary>
        public int GetMode()
        {
            return _mode;
        }
        
        /// <summary>
        /// Method for serializing the command fields </summary>
        public override int[] Serialize()
        {
            SerializeHeader(_serializer);
            _serializer.SerializeUInt8(_mode);
            return _serializer.GetPayload();
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspLaunchStandaloneBootloaderRequest [mode=");
            builder.Append(_mode);
            builder.Append(']');
            return builder.ToString();
        }
    }
}