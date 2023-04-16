﻿using CommandTerminal;
using UnityEngine;
using Winch.Config;
using Winch.Util;

namespace Winch.Core
{
    class Initializer
    {
        public static void Initialize()
        {
            WinchCore.Log.Debug("Initializer started.");

            InitializeVersionLabel();

            if(WinchConfig.GetProperty("EnableDeveloperConsole", false))
                InitializeDevConsole();
        }

        private static void InitializeVersionLabel()
        {
            WinchCore.Log.Debug("Initializing Version Label...");

            string versionString = VersionUtil.GetVersion();
            GameManager.Instance.BuildInfo.BuildNumber += $"\nWinch {versionString}";

            int modsLoaded = ModAssemblyLoader.LoadedAssemblies;
            string modsLoadedString = $"{modsLoaded} Mod{(modsLoaded > 1 ? "s" : "")} loaded";
            GameManager.Instance.BuildInfo.BuildNumber += $"\n{modsLoadedString}";
        }

        private static void InitializeDevConsole()
        {
            WinchCore.Log.Debug("Initializing Developer Console...");
            GameObject term = new GameObject();
            term.AddComponent<Terminal>();
            UnityEngine.Object.DontDestroyOnLoad(term);
        }
    }
}