using System;
using System.Collections.Generic;
using System.Text;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace JianLi.VisualStudio.Integration
{
    public abstract class VsAddin : IDTExtensibility2, IDTCommandTarget
    {
        EnvDTE.SolutionEvents solutionEvents;
        _dispSolutionEvents_OpenedEventHandler hOpened;
        private DTE2 dte;
        private AddIn addin;
        private object[] contextGUIDS;
        private Dictionary<string, VsCommand> vsCommands;

        public DTE2 DTE
        {
            get
            {
                return this.dte;
            }
        }

        public AddIn AddIn
        {
            get
            {
                return this.addin;
            }
        }

        public VsAddin()
        {
            this.vsCommands = new Dictionary<string, VsCommand>();
        }

        /// <summary>
        /// Occurs whenever an add-in is loaded or unloaded from the Visual Studio integrated development environment (IDE).
        /// </summary>
        /// <param name="custom">An empty array that you can use to pass host-specific data for use in the add-in.</param>
        void IDTExtensibility2.OnAddInsUpdate(ref Array custom)
        {
        }

        /// <summary>
        /// Occurs whenever the Visual Studio integrated development environment (IDE) shuts down while an add-in is running.
        /// </summary>
        /// <param name="custom">An empty array that you can use to pass host-specific data for use in the add-in.</param>
        void IDTExtensibility2.OnBeginShutdown(ref Array custom)
        {            
        }

        /// <summary>
        /// Occurs whenever an add-in is loaded into Visual Studio.
        /// </summary>
        /// <param name="Application">A reference to an instance of the integrated development environment (IDE), <see cref="T:EnvDTE.DTE"></see>, which is the root object of the Visual Studio automation model.</param>
        /// <param name="ConnectMode">An <see cref="T:Extensibility.ext_ConnectMode"></see> enumeration value that indicates the way the add-in was loaded into Visual Studio.</param>
        /// <param name="AddInInst">An <see cref="T:EnvDTE.AddIn"></see> reference to the add-in's own instance. This is stored for later use, such as determining the parent collection for the add-in.</param>
        /// <param name="custom">An empty array that you can use to pass host-specific data for use in the add-in.</param>
        void IDTExtensibility2.OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            this.dte = (DTE2)Application;
            this.addin = (AddIn)AddInInst;
            this.OnInitialize();


            if (ConnectMode == ext_ConnectMode.ext_cm_UISetup)
            {
                this.contextGUIDS = new object[] { };

                Commands2 commands = (Commands2)this.DTE.Commands;
                CommandBars commandBars = (CommandBars)this.dte.CommandBars;
                
                foreach (VsCommand vsCommand in this.vsCommands.Values)
                {
                    Command command = commands.AddNamedCommand2(
                        this.AddIn, 
                        vsCommand.CommandName, 
                        vsCommand.Title, 
                        String.Empty, 
                        true, 
                        -1,
                        ref this.contextGUIDS, 
                        (int)vsCommandStatus.vsCommandStatusSupported + (int)vsCommandStatus.vsCommandStatusEnabled, 
                        (int)vsCommandStyle.vsCommandStylePictAndText, 
                        vsCommandControlType.vsCommandControlTypeButton);                   

                    string[] temp = vsCommand.CommandBarName.Split('.');
                    CommandBar commandBar = commandBars[this.GetLocalizedName(temp[0])];

                    if (temp.Length == 1)
                    {
                        command.AddControl(commandBar, vsCommand.Position);
                    }
                    else if (temp.Length == 2)
                    {
                        CommandBarPopup commandBarPopup = (CommandBarPopup)commandBar.Controls[this.GetLocalizedName(temp[1])];
                        command.AddControl(commandBarPopup.CommandBar, vsCommand.Position);
                    }
                    else
                    {
                        throw new Exception();
                    }

                }
            }
        }

        /// <summary>
        /// Occurs whenever an add-in is unloaded from Visual Studio.
        /// </summary>
        /// <param name="RemoveMode">An <see cref="T:Extensibility.ext_DisconnectMode"></see> enumeration value that informs an add- why it was unloaded.</param>
        /// <param name="custom">An empty array that you can use to pass host-specific data for use after the add-in unloads.</param>
        void IDTExtensibility2.OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {            
        }

        /// <summary>
        /// Occurs whenever an add-in, which is set to load when Visual Studio starts, loads.
        /// </summary>
        /// <param name="custom">An empty array that you can use to pass host-specific data for use when the add-in loads.</param>
        void IDTExtensibility2.OnStartupComplete(ref Array custom)
        {
            this.solutionEvents = dte.Events.SolutionEvents;

            this.hOpened = new _dispSolutionEvents_OpenedEventHandler(SolutionEvents_Opened);// 为什么要这样？

            this.solutionEvents.Opened += this.hOpened;
        }


        void SolutionEvents_Opened()
        {
            JianLi3Data.JianLiLinq.Default.CreateSolution( dte.Solution.FullName);
        }
        /// <summary>
        /// Executes the specified named command.
        /// </summary>
        /// <param name="CmdName">The name of the command to execute.</param>
        /// <param name="ExecuteOption">A <see cref="T:EnvDTE.vsCommandExecOption"></see> constant specifying the execution options.</param>
        /// <param name="VariantIn">A value passed to the command.</param>
        /// <param name="VariantOut">A value passed back to the invoker Exec method after the command executes.</param>
        /// <param name="Handled">true indicates that the command was implemented. false indicates that it was not.</param>
        void IDTCommandTarget.Exec(string cmdName, vsCommandExecOption ExecuteOption, ref object VariantIn, ref object VariantOut, ref bool Handled)
        {
            Handled = false;
            if (ExecuteOption == vsCommandExecOption.vsCommandExecOptionDoDefault)
            {
                if (this.vsCommands.ContainsKey(cmdName))
                {
                    VsCommand vsCommand = this.vsCommands[cmdName];
                    vsCommand.OnExecute(new VsCommandEventArgs(this.dte, this.addin));
                    Handled = true;
                }
            }
        }

        /// <summary>
        /// Returns the current status (enabled, disabled, hidden, and so forth) of the specified named command.
        /// </summary>
        /// <param name="CmdName">The name of the command to check.</param>
        /// <param name="NeededText">A <see cref="T:EnvDTE.vsCommandStatusTextWanted"></see> constant specifying if information is returned from the check, and if so, what type of information is returned.</param>
        /// <param name="StatusOption">A <see cref="T:EnvDTE.vsCommandStatus"></see> specifying the current status of the command.</param>
        /// <param name="CommandText">The text to return if <see cref="F:EnvDTE.vsCommandStatusTextWanted.vsCommandStatusTextWantedStatus"></see> is specified.</param>
        void IDTCommandTarget.QueryStatus(string cmdName, vsCommandStatusTextWanted neededText, ref vsCommandStatus statusOption, ref object commandText)
        {
            if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
            {
                if (this.vsCommands.ContainsKey(cmdName))
                {
                    VsCommand vsCommand = this.vsCommands[cmdName];
                    if (vsCommand.OnQueryStatus(new VsCommandEventArgs(this.dte, this.addin)))
                    {
                        statusOption = (vsCommandStatus)vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        statusOption = (vsCommandStatus)vsCommandStatus.vsCommandStatusUnsupported;
                    }
                }
            }
        }

        protected virtual void OnInitialize()
        {         
        }

        protected void RegisterCommand(VsCommand command)
        {
            string fullCommandName = String.Format("{0}.{1}", this.GetType().FullName, command.CommandName);
            this.vsCommands.Add(fullCommandName, command);
        }
        
        private string GetLocalizedName(string name)
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager("Koda.Resources.CommandBar", Assembly.GetExecutingAssembly());
                CultureInfo cultureInfo = new CultureInfo(this.DTE.LocaleID);
                string resourceName = String.Concat(cultureInfo.TwoLetterISOLanguageName, name);
                string localizedName = resourceManager.GetString(resourceName);
                if (String.IsNullOrEmpty(localizedName))
                    return name;
                return localizedName;
            }
            catch
            {
                return name;
            }        
        }
    }
}
