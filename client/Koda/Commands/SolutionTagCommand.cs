using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi.VisualStudio.Integration;
using EnvDTE;
using JianLi.UI;
using EnvDTE80;

namespace JianLi.Commands
{
    class SolutionTagCommand: VsCommand
    {
        private Window solutionTagToolWindow;

        public SolutionTagCommand()
            : base("解决方案标签视图", "MenuBar.Tools", 1)
        {
        }

        public override void OnExecute(VsCommandEventArgs e)
        {
            if (this.solutionTagToolWindow == null)
            {
                object temp = null;
                Windows2 windows = (Windows2)e.DTE.Windows;
                this.solutionTagToolWindow = windows.CreateToolWindow2(e.AddIn, System.Reflection.Assembly.GetExecutingAssembly().Location, "JianLi.UI.SolutionTagView", "解决方案标签视图", "{786FD1AF-97BA-4f44-B73C-021FA6E174BC}", ref temp);

                SolutionTagView codeOutlineView = (SolutionTagView)temp;
                codeOutlineView.DTE = e.DTE;
                codeOutlineView.ParentWindow = this.solutionTagToolWindow;

                this.solutionTagToolWindow.Visible = true;
            }
            else
            {
                this.solutionTagToolWindow.Activate();
            }
        }
    }
}
