using Walkhorn_Core.Configurations;
using Walkhorn_Core.Registries;

namespace Walkhorn_Core.Core
{
    class Program
    {
        public static Configuration GameConfiguration = new Configuration();
        public static GameRegistry GameRegistry= new GameRegistry();
        
        static void Main(string[] args)
        {
            Globals.Load();
            GameConfiguration.LoadFromFile(Globals.GetConfigurationDestination());
            GameRegistry.LoadRegistries(GameConfiguration);
            //TODO Load Processors
            ////TODO Load Window
            //TODO Load Proxy (Client/Server)
            //TODO Ensure Integrity
        }
    }
}