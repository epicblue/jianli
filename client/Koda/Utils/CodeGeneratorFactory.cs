using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE;

namespace JianLi.Utils
{
    public static class CodeGeneratorFactory
    {
        public static CodeGenerator Create(string language)
        {
            switch (language)
            {
                case CodeModelLanguageConstants.vsCMLanguageCSharp:
                    return new CSharpCodeGenerator();

                case CodeModelLanguageConstants.vsCMLanguageVB:
                    return new VBCodeGenerator();

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
