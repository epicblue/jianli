using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace JianLi.Utils
{
    public class VBCodeGenerator : CodeGenerator
    {
        public VBCodeGenerator()
            : base(new VBCodeProvider()) 
        {
        }

        public override string GenerateReturnStatement(string name)
        {
            return base.GenerateReturnStatement(name) + Environment.NewLine;
        }
    }
}
