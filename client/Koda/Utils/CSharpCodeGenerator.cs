using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp;

namespace JianLi.Utils
{
    public class CSharpCodeGenerator : CodeGenerator
    {
        public CSharpCodeGenerator() 
            : base(new CSharpCodeProvider()) 
        {
        }      
    }
}