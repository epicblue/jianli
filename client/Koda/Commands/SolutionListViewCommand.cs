using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;
using EnvDTE80;
using JianLi.VisualStudio;
using JianLi.UI;
using JianLi.VisualStudio.Integration;

namespace JianLi.Commands
{
    public class SolutionListViewCommand : VsCommand
    {
        private Window SolutionListViewToolWindow;

        public SolutionListViewCommand()
            : base("解决方案列表", "MenuBar.Tools", 1)
        {
        }

        public override void OnExecute(VsCommandEventArgs e)
        {
            if (this.SolutionListViewToolWindow == null)
            {
                object temp = null;
                Windows2 windows = (Windows2)e.DTE.Windows;
                this.SolutionListViewToolWindow = windows.CreateToolWindow2(e.AddIn, System.Reflection.Assembly.GetExecutingAssembly().Location, "JianLi.UI.SolutionListView", "解决方案列表", "{6882BEB2-80BB-45f9-BF6F-60BC8DC77F25}", ref temp);

                SolutionListView codeOutlineView = (SolutionListView)temp;
                codeOutlineView.DTE = e.DTE;
                codeOutlineView.ParentWindow = this.SolutionListViewToolWindow;

                this.SolutionListViewToolWindow.Visible = true;
            }
            else
            {
                this.SolutionListViewToolWindow.Activate();
            }
        }
    }
}