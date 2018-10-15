using Assets.Scripts.android;
using Assets.Scripts.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
/*
 * applem - Unity 3D Roll-a-ball Tutorial
 * Bonus, not in tutorial
 * Jan 6 2018
*/    
    class DeviceTypeFactory
    {
        private DeviceTypeFactory()
        { }

        public static IDeviceType getDeviceType()
        {
            if(SystemInfo.deviceType == DeviceType.Handheld)
            {
                return new AndroidDeviceType();
            }

            //default
            return new WindowsDeviceType();
        }
    }
}
