using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi.VisualStudio.Integration;
using EnvDTE;
using EnvDTE80;
using JianLi.UI;

namespace JianLi.Commands
{
    class ProjectViewCommand: VsCommand
    {
        private Window ProjectViewToolWindow;

        public ProjectViewCommand()
            : base("项目任务", "MenuBar.Tools", 1)
        {
        }

        public override void OnExecute(VsCommandEventArgs e)
        {
            if (this.ProjectViewToolWindow == null)
            {
                object temp = null;
                Windows2 windows = (Windows2)e.DTE.Windows;
                this.ProjectViewToolWindow = windows.CreateToolWindow2(e.AddIn, System.Reflection.Assembly.GetExecutingAssembly().Location, "JianLi.UI.ProjectView", "项目任务", "{DD52FE78-3F3A-4c9d-8828-E78FC75B944F}", ref temp);

                ProjectView projectView = (ProjectView)temp;
                projectView.DTE = e.DTE;
                projectView.ParentWindow = this.ProjectViewToolWindow;

                this.ProjectViewToolWindow.Visible = true;
            }
            else
            {
                this.ProjectViewToolWindow.Activate();
            }
        }
    }
}
