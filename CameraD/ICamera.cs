using HLHal;
using System;
using System.Collections.Generic;
using System.Text;

namespace CameraD
{
   public interface ICamera
    {
        HCtrl hCtrl { get; set; }
        void Open();
        void Close();
        float ExposureTime{ get; set; }
        float Gain{ get; set; }
        void StartGrab(); 
        void StopGrab(); 
        void Trigger(); 
        
    }
}
