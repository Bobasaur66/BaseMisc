using System;
using UnityEngine;

namespace BaseMisc.Music
{
    public class MusicController
    {
        public static void ChangeMusicTypeToDefault()
        {
            BaseMiscLogger.Log("Music type default");
        }
        public static void ChangeMusicTypeToCustom()
        {
            BaseMiscLogger.Log("Music type custom");
        }

        public static void StopMusic()
        {
            BaseMiscLogger.Log("Stop music");
        }

        public static void StartMusic()
        {
            BaseMiscLogger.Log("Start music");
        }

        public static void ForwardMusic()
        {
            BaseMiscLogger.Log("Forward music");
        }

        public static void BackMusic()
        {
            BaseMiscLogger.Log("Back music");
        }
    }
}
