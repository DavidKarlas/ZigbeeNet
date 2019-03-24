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
    /// Class to implement the XBee command " Set Scan Channels ".
    /// AT Command <b>SC</b></p>Set or read the list of channels to scan. Coordinator - Bit field
    /// list of channels to choose from prior to starting network. Router/End Device - Bit field list
    /// of channels scanned to find a Coordinator/Router to join. Write changes to SC using the WR
    /// command to preserve the SC setting if a power cycle occurs. 
    ///This class provides methods for processing XBee API commands.
    ///
    /// </summary>
    public class XBeeSetScanChannelsCommand : XBeeFrame, IXBeeCommand 
    {
        
        /// <summary>
        /// 
        /// </summary>
        private int _frameId;
        
        /// <summary>
        /// 
        /// </summary>
        private int _channels;
        
        public void SetFrameId(int frameId)
        {
            this._frameId = frameId;
        }
        
        public void SetChannels(int channels)
        {
            this._channels = channels;
        }
    }
}
