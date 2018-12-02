using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace PowerPlatformCommandConsole
{
    public class Location
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool Enabled { get; set; } = true;

        public override string ToString()
        {
            if (!String.IsNullOrEmpty(Path))
                return  Path;
            return Name;
        }



    }

    public class Command
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string Cmd { get; set; }
        public string IconName { get; set; }
        public bool ConfirmCommand { get; set; } = false;
        public bool RequiresShell { get; set; } = true;
        public string Args { get; set; }
        public bool? Refresh { get; set; } = false;
        }

    public class Configuration
    {
        public string LocalBuildStrategyFolder { get; set; }
        public string BatFolder { get; set; }
        public string PartialEnvBatFile { get; set; }
        public bool ConfirmCommand { get; set; } = false;

        public IList<Location> Locations { get; set; }
        public IList<Command> Commands { get; set; }


        public static Configuration Deserialize(string configFile)
        {
            if (String.IsNullOrEmpty(configFile) || !System.IO.File.Exists(configFile))
                return null;

            try
            {
                JObject jsonData = JObject.Parse(System.IO.File.ReadAllText(configFile));

                return jsonData.ToObject<Configuration>();
            }
            catch(Exception ex)
            {
                throw new Exception(String.Format("Unable to parse json file: {0}", configFile), ex);
            }
        }




    }
}
