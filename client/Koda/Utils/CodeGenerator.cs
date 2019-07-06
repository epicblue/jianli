using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;

namespace JianLi.Utils
{
    public abstract class CodeGenerator
    {
        private CodeDomProvider codeDomProvider;

        public CodeGenerator(CodeDomProvider codeDomProvider)
        {
            if (codeDomProvider == null)
                throw new ArgumentNullException("codeDomProvider");
            
            this.codeDomProvider = codeDomProvider;
        }

        public virtual string GenerateAssignStatement(string left, string right)
        {
            CodeFieldReferenceExpression codeField = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), left);

            CodeAssignStatement codeAssignStatement = new CodeAssignStatement();
            codeAssignStatement.Left = codeField;
            codeAssignStatement.Right = new CodeArgumentReferenceExpression(right);
            
            return this.Generate(codeAssignStatement);
        }

        public virtual string GenerateReturnStatement(string name)
        {
            CodeFieldReferenceExpression codeField = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), name);

            CodeMethodReturnStatement returnStatement = new CodeMethodReturnStatement();
            returnStatement.Expression = codeField;

            return this.Generate(returnStatement);
        }

        protected virtual string Generate(CodeStatement codeStatement)
        {
            CodeGeneratorOptions options = new CodeGeneratorOptions();

            using (StringWriter sw = new StringWriter())
            {
                this.codeDomProvider.GenerateCodeFromStatement(codeStatement, sw, options);
                return sw.ToString().Trim();
            }        
        }        
    }
}