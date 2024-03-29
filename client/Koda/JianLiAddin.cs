using System;
using JianLi.Commands;
using JianLi.VisualStudio.Integration;

namespace JianLi.VSAddin
{ 
    public class JianLiAddin : VsAddin
    {
        protected override void OnInitialize()
        {
            this.RegisterCommand(new SolutionListViewCommand());
            this.RegisterCommand(new SolutionTagCommand());
            this.RegisterCommand(new ProjectViewCommand());
        }
    }
}