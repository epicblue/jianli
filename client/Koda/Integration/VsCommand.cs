using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;

namespace JianLi.VisualStudio.Integration
{
    public abstract class VsCommand
    {
        private string title;
        private string commandBarName;
        private int position;

        public virtual int Position
        {
            get
            {
                return this.position;
            }
        }

        public virtual string CommandBarName
        {
            get 
            { 
                return this.commandBarName;
            }
        }

        public virtual string Title
        {
            get
            {
                return this.title;
            }
        }

        public virtual string CommandName
        {
            get
            {
                return this.GetType().Name;
            }
        }

        public VsCommand(string title, string commandBarName, int position)
        {
            this.title = title;
            this.commandBarName = commandBarName;
            this.position = position;            
        }

        public virtual bool OnQueryStatus(VsCommandEventArgs e)
        {
            return true;
        }

        public abstract void OnExecute(VsCommandEventArgs e);
    }
}
