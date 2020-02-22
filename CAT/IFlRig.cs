using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookComputing.XmlRpc;

namespace Log4WinNet.Log.CAT
{
    [XmlRpcUrl("http://127.0.0.1:12345/")]
    public interface IFlRig : IXmlRpcProxy
    {
        [XmlRpcMethod("rig.get_mode")]
        string Rig_get_mode();
        [XmlRpcMethod("rig.get_info")]
        string RigGetInfo();
        [XmlRpcMethod("rig.get_xcvr")]
        string RigGetXcvr();
        [XmlRpcMethod("rig.get_vfo")]
        string RigGetVfo();
        [XmlRpcMethod("rig.set_frequency")]
        int RigSetFreq(double freq);
        [XmlRpcMethod("rig.set_AB")]
        void RigSetAB(string par);
        [XmlRpcMethod("rig.get_AB")]
        string RigGetAB();
        [XmlRpcMethod("rig.get_modes")]
        string[] RigGetModes();
        [XmlRpcMethod("rig.get_ptt")]
        int RigGetPtt();
        [XmlRpcMethod("rig.set_ptt")]
        void RigSetPtt(int i);
        [XmlRpcMethod("rig.set_mode")]
        void RigSetMode(string mode);
        [XmlRpcMethod("main.set_frequency")]
        void SetMainFrequency(double dFreq);
        [XmlRpcMethod("rig.get_pwrmeter")]
        int RigGetPower();
    }
}
