using System;
using Walkhorn_Core.Configurations;
using Walkhorn_Core.Drawing.Window;
using Walkhorn_Core.Registries;

namespace Walkhorn_Core.Core
{
    class Program
    {
        public static Configuration GameConfiguration = new Configuration();
        public static GameRegistry GameRegistry = new GameRegistry();
        public static Window Window;

        [STAThread]
        static void Main(string[] args)
        {
            Globals.Load();
            GameConfiguration = Configuration.LoadFromFile(Globals.GetConfigurationDestination());
            GameRegistry.LoadRegistries(GameConfiguration);
            //TODO Load Processors
            LoadWindow();
            //TODO Load Proxy (Client/Server)
            //TODO Ensure Integrity
        }

        public static void LoadWindow()
        {
            Window = new Window();
            Window.Run(60.0, 60.0);
        }
    }
}