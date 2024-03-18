using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BaseMisc
{
    public class Logger
    {
        public static void Log(string message)
        {
            Debug.Log("[BaseMisc] " + message);
        }

        public static void Warn(string message)
        {
            Debug.LogWarning("[BaseMisc] " + message);
        }

        public static void Error(string message)
        {
            Debug.LogError("[BaseMisc] " + message);
        }
    }
}
