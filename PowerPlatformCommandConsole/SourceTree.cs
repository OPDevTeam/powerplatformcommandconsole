using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlatformCommandConsole
{
    public class SourceTree
    {
        public string Path { get; set; }
        public string Version { get; set; }
        public string UpdateVersion { get; set; }
        public Configuration Configuration { get; set; }

        public string SourceFolderName { get; set; } = "src";

        public string EnvBatFileName { get; set; } = "pp_env.bat";

        public string Title { get; set; } = "PowerPlatform Command Console";

        public string RootFolder
        {
            get
            {
                return System.IO.Path.Combine(Path, Version);
            }
        }

        public string SourceFolder
        {
            get
            {
                return System.IO.Path.Combine(RootFolder, SourceFolderName);
            }
        }



        public SourceTree(string path, string version, string updateVersion, Configuration cfg)
        {
            if(String.IsNullOrEmpty(path))
                return;

            if(String.IsNullOrEmpty(version))
                return;

            if(cfg == null)
                return;

            Path = path;
            Version = version;
            UpdateVersion = updateVersion;
            Configuration = cfg;

            CreateEnvBatFile();
        }

        public bool Bootstrapped
        {
            get
            {
                return System.IO.Directory.Exists(SourceFolder);
            }
        }

       public void CreateEnvBatFile()
        {
            string envBatFileFolder = RootFolder;
            if (!System.IO.Directory.Exists(envBatFileFolder))
                System.IO.Directory.CreateDirectory(envBatFileFolder);
            if (!System.IO.Directory.Exists(envBatFileFolder))
            {
                // invalid path
                return;
            }
            string envBatFileFullPath = System.IO.Path.Combine(envBatFileFolder, EnvBatFileName);
            string paritalEnvBatFileFullPath = Configuration.PartialEnvBatFile;

            if (System.IO.File.Exists(envBatFileFullPath))
                    System.IO.File.Delete(envBatFileFullPath);

            IList<string> cmdFileContents = new List<string>();

            // Add the stream and application specific variables
            cmdFileContents.Add("@echo off");
            cmdFileContents.Add(String.Format("set PP_VER={0}", Version));
            cmdFileContents.Add(String.Format("set PP_UPD_VER={0}", UpdateVersion));
            cmdFileContents.Add(String.Format("set PP_DIR={0}", Path));
            cmdFileContents.Add(String.Format("set PP_BDF=bdfserver:PowerPlatform:{0}", Version));
            cmdFileContents.Add(String.Format("set PP_LocalBuildStrategyFolder={0}", Configuration.LocalBuildStrategyFolder));
            
            //foreach(ShellEnvVariable shellEnvVar in Configuration.ShellEnvVariables)
            //{
            //    cmdFileContents.Add (String.Format ("set {0}={1}", shellEnvVar.Name, shellEnvVar.Value));
            //}

           

            // call the baseEnvBat file
            cmdFileContents.Add("");
            if (System.IO.File.Exists(paritalEnvBatFileFullPath))
                cmdFileContents.Add(String.Format("call {0}", paritalEnvBatFileFullPath));
            else
                cmdFileContents.Add(String.Format("echo Warning: Unable to locate OpenPlant Base Env bat file: {0}", paritalEnvBatFileFullPath));

           // Add path to bat folder
            cmdFileContents.Add("");
            cmdFileContents.Add(String.Format("set Path={0};%PATH%", Configuration.BatFolder));

            // Title and Color
            cmdFileContents.Add("");
            cmdFileContents.Add(String.Format("Title {0}", Title));
            //cmdFileContents.Add(String.Format("color {0}", Color));
            cmdFileContents.Add("");

            //with this the cmd will exit
            string exit = " && exit";
            exit = string.Empty;

            // now add stuff for running commands
            cmdFileContents.Add("rem The following commands are defined in the configuration file");
            foreach (Command cmd in Configuration.Commands)
            {
                if (cmd.RequiresShell && !String.IsNullOrEmpty(cmd.Name) && !String.IsNullOrEmpty(cmd.Cmd))
                {
                    //string title = String.Format("{0} - {1}", Title, cmd.Name);
                    string title = String.Format ("{0} - {1}", Title, cmd.Label);
                    //cmdFileContents.Add(String.Format("if /i [%1]==[{0}] Title {2}&echo \"calling {1}\"&{1}", cmd.Name, cmd.Cmd, title));
                    cmdFileContents.Add(String.Format("if /i [%1]==[{0}] Title {2}&echo \"calling {1}\"&{1}{3}", cmd.Name, cmd.Cmd, title, exit));
                }
            }

            cmdFileContents.Add("");

            // write out the file
            System.IO.File.WriteAllLines(envBatFileFullPath, cmdFileContents);
        }

        public void Bootstrap()
        {
            string srcFolder = SourceFolder;
            if (!System.IO.Directory.Exists(srcFolder))
                System.IO.Directory.CreateDirectory(srcFolder);

            string bootstrapCmd = String.Format("bentleybootstrap.py PowerPlatform:{0}", Version);
            runCmd (bootstrapCmd, SourceFolder);
        }

        public void RunCommand(string cmd, string startFolder)
        {
            CreateEnvBatFile();
            runCmd(cmd, startFolder);
        }


        private void runCmd(string cmd, string startFolder)
        {
            if(String.IsNullOrEmpty(startFolder))
                startFolder = RootFolder;

            Utilities.Instance.RunCommand (cmd, startFolder);
        }

        public string GetFullCommandString(string cmd)
        {
            return String.Format("{0} {1}", System.IO.Path.Combine(RootFolder, EnvBatFileName), cmd);  // MappedApplicationFolder

        }

    }
}
