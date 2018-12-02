using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlatformCommandConsole
{

    public class Utilities
    {
        public System.Diagnostics.Process CurrentProcess { get; set; }
        public IntPtr LastHandle { get; set; }

        private static volatile Utilities instance;
        private static object syncRoot = new Object();

        private Utilities() { }

        public static Utilities Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Utilities();
                    }
                }

                return instance;
            }
        }

        public void RunCommand(string cmd, string sourceFolder)
        {
            CurrentProcess = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            if (!string.IsNullOrEmpty(sourceFolder))
                startInfo.WorkingDirectory = sourceFolder;
            startInfo.FileName = @"cmd.exe";

            if (!string.IsNullOrEmpty(cmd))
                //startInfo.Arguments = "/c " + cmd; // kills window
                startInfo.Arguments = "/k " + cmd;

            startInfo.Verb = "runas";
            CurrentProcess.StartInfo = startInfo;
            try
            {
                CurrentProcess.Start();
                LastHandle = CurrentProcess.Handle;
            }
            catch { }

        }
        public void RunProcess (string processName, string args)
        {
            if (String.IsNullOrEmpty(processName))
                return;

            //if (String.IsNullOrEmpty(args))
            //{
            //    RunProcess(processName);
            //    return;
            //}

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();

            startInfo.FileName = processName;

            startInfo.Arguments = args;

            startInfo.Verb = "";
            process.StartInfo = startInfo;
            try
            {
                process.Start();
                LastHandle = process.Handle;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        public void RunProcess(string processName)
        {
            if (String.IsNullOrEmpty(processName))
                return;

            try
            {
                System.Diagnostics.Process.Start(processName);
            }
            catch (Exception ex)
            {
                
            }
            return;


        }


        public Command FindCommandByName(IList<Command> commands, string cmdName)
        {
            if (commands == null)
                return null;

            if (String.IsNullOrEmpty(cmdName))
                return null;

            foreach(Command cmd in commands)
            {
                if (cmd.Name.Equals(cmdName, StringComparison.InvariantCultureIgnoreCase))
                    return cmd;
            }

            return null;
        }

        public Location FindLocationByName (IList<Location> locs, string name)
        {
            if (locs == null)
                return null;

            if (String.IsNullOrEmpty(name))
                return null;

            foreach (Location loc in locs)
            {
                if (loc.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return loc;
            }

            return null;
        }

        public IList<string> FindPowerPlatformFolders(string baseFolder, string ppEnvBatFileName)
        {
            IList<string> ppDirs = null;
            if(String.IsNullOrEmpty(baseFolder) || !System.IO.Directory.Exists(baseFolder))
                return null;

            string[] subDirs = System.IO.Directory.GetDirectories(baseFolder);

            foreach(string subDir in subDirs)
            {
                if(System.IO.File.Exists(System.IO.Path.Combine(subDir, ppEnvBatFileName)))
                {
                    if(ppDirs == null)
                        ppDirs = new List<string>();
                    string folderName = System.IO.Path.GetFileName(subDir);
                    ppDirs.Add(folderName);
                }
            }

            return ppDirs;
        }
    }
}
