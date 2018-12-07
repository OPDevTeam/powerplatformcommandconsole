using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PowerPlatformCommandConsole
{
    public partial class Form1 : Form
    {
        public Configuration Configuration { get; set; }


        public Form1 ()
        {
            InitializeComponent();
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            Configuration = Configuration.Deserialize(@"C:\DevTools\PowerPlatformCommandConsole\Configuration\PowerPlatformConfiguration.json");
            if(Configuration == null)
                return;

            if((Configuration.Locations == null) || (Configuration.Locations.Count == 0))
                return;

            InitializeForm();
        }

        private PowerPlatformCommandConsole.Location SelectedLocation
        {
            get
            {
                return (PowerPlatformCommandConsole.Location)this.LocationsComboBox.SelectedItem;
                    
            }
        }

        private string Version
        {
            get
            {
                return (string)this.PPVerTextBox.Text;
                    
            }
        }

        private string UpdateVersion
        {
            get
            {
                return (string)this.UpdateToPPVerTextBox.Text;
                    
            }
        }

        private void InitializeForm()
        {
            string lastUsedPPVer = Properties.Settings.Default.LastUsedPPVer;
            if(String.IsNullOrEmpty(lastUsedPPVer))
                lastUsedPPVer = "10.12.0.20";
            this.PPVerTextBox.Text = lastUsedPPVer;

            this.PPVerRegexTextBox.Text = Configuration.PPVerRegex;

            PopulateLocationsComboBox();

        }

        private void PopulateLocationsComboBox()
        {
            if((Configuration == null) || (Configuration.Locations == null))
                return;

           string lastUsedLocation = Properties.Settings.Default.LastUsedLocation;
           this.LocationsComboBox.Items.Clear();
            foreach(PowerPlatformCommandConsole.Location loc in Configuration.Locations)
            {
                if(loc.Enabled && !String.IsNullOrEmpty(loc.Path))
                {
                    this.LocationsComboBox.Items.Add(loc);
                    if((this.LocationsComboBox.SelectedItem == null) || loc.Name.Equals (lastUsedLocation, StringComparison.InvariantCultureIgnoreCase))
                        this.LocationsComboBox.SelectedItem = loc;
                }
            }

            if(this.LocationsComboBox.SelectedItem == null)
                this.LocationsComboBox.SelectedItem = Configuration.Locations[0];

        }

        private SourceTree GetSourceTree()
        {
            return new SourceTree(SelectedLocation.Path, Version, UpdateVersion, Configuration);
        }

        private void ExecuteCommand(Command cmd, string startFolder)
            {
            if(cmd == null)
                return;

            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            if(!sourceTree.Bootstrapped)
                {
                BootStrap (sourceTree);
                // even though we bootstrap we need to return without executing the command, user has to pick it again
                return;
                }

            string cmdString = sourceTree.GetFullCommandString (cmd.Name);

            //if(!ConfirmCommand (sourceTree, cmd, cmdString))
            //    return;

            //if(!String.IsNullOrEmpty (cmd.Cmd))
            //    Clipboard.SetText (cmd.Cmd);

            //KillCurrentProcessButton.Enabled = true;
            if(startFolder == null)
                startFolder = sourceTree.RootFolder;

            if(cmd.RequiresShell)
                sourceTree.RunCommand (cmdString, startFolder);
            else
                {
                Utilities.Instance.RunProcess (cmd.Cmd, cmd.Args);
                }

            //if(cmd.Refresh)
            //    {
            //    //MessageBox.Show ("Select Ok to refresh", "refresh", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    System.Threading.Thread.Sleep (4500);
            //    RefreshConfiguration ();
            //    }

            }


        private void BootStrap(SourceTree sourceTree)
            {

            DialogResult dialogResult = MessageBox.Show (String.Format ("Source folder {0} does not exist.\nDo you want to bootstrap?", sourceTree.SourceFolder), "Source Folder Not Found", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
                sourceTree.Bootstrap ();
            }

        //private bool ConfirmCommand(SourceTree sourceTree, Command cmd, string cmdString)
        //    {
        //    if(!Configuration.ConfirmCommand || !cmd.ConfirmCommand)
        //        return true;

        //    System.Windows.Forms.DialogResult dialogResult =
        //        System.Windows.Forms.MessageBox.Show (
        //            String.Format ("{1} {2}{0}{3} {4}{0}{5} {6}{0}{7} {8}{0}{0}{9} {0}",
        //                            System.Environment.NewLine,
        //                            "Configuration:", Configuration.Description,
        //                            "Stream:", sourceTree.Stream,
        //                            "Application:", sourceTree.Application,
        //                            "Command:", cmdString,
        //                            "Proceed?"),
        //                "Command Confirmation",
        //                System.Windows.Forms.MessageBoxButtons.YesNo
        //        );
        //    if(dialogResult == System.Windows.Forms.DialogResult.Yes)
        //        return true;

        //    return false;

        //    }


        private void BootstrapButton_Click (object sender, EventArgs e)
        {
            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            if(!sourceTree.Bootstrapped)
                sourceTree.Bootstrap();
        }

        private void PullButton_Click (object sender, EventArgs e)
        {
            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            Command cmd = Utilities.Instance.FindCommandByName(Configuration.Commands, "pull");
            ExecuteCommand(cmd, sourceTree.SourceFolder);

        }

        private void BuildButton_Click (object sender, EventArgs e)
        {
            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            Command cmd = Utilities.Instance.FindCommandByName(Configuration.Commands, "build");
            ExecuteCommand(cmd, sourceTree.SourceFolder);

        }

        private void SaveLKGsButton_Click (object sender, EventArgs e)
        {
            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            Command cmd = Utilities.Instance.FindCommandByName(Configuration.Commands, "savelkgs");
            ExecuteCommand(cmd, sourceTree.SourceFolder);
        }

        private void UpdateButton_Click (object sender, EventArgs e)
        {
            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            Command cmd = Utilities.Instance.FindCommandByName(Configuration.Commands, "update");
            ExecuteCommand(cmd, sourceTree.SourceFolder);

        }

        private void button1_Click (object sender, EventArgs e)
        {
            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            IList<string> ppDirs = Utilities.Instance.FindPowerPlatformFolders(sourceTree.Path, sourceTree.EnvBatFileName);
        }

        private void LocationsComboBox_SelectedIndexChanged (object sender, EventArgs e)
        {
            SourceTree sourceTree = GetSourceTree();
            if(sourceTree == null)
                return;

            IList<string> ppDirs = Utilities.Instance.FindPowerPlatformFolders(sourceTree.Path, sourceTree.EnvBatFileName);

        }

        private async void FetchVersionsButton_Click (object sender, EventArgs e)
        {
            //IList<string> releases = new List<string>(new string[] { "10" });
            //IList<string> majorVersions = new List<string>(new string[] { "12", "11" });

            //IList<string> ppVersions = await BDFUtilities.GetPowerPlatformVersions(releases, majorVersions);

            string regExPattern = this.PPVerRegexTextBox.Text; // @"10.12.0.([2-9][6-9]|[3-9][0-9])|10.11.0.([3-9][6-9]|[4-9][0-9])";

             IList<string> ppVersions = await BDFUtilities.GetPowerPlatformVersions(regExPattern);

             this.PPVerListBox.Items.Clear();
             foreach(string ppVer in ppVersions)
                this.PPVerListBox.Items.Add(ppVer);
        }
    }
}
