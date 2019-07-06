using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using Microsoft.Scripting;
using IronPython.Runtime;
using IronPython.Runtime.Exceptions;

namespace LusongControl
{
    public class UniIronPython
    {
        public UniIronPython()
        {
            this._engine = Python.CreateEngine();
            this._scope = this._engine.CreateScope();
        }

        ScriptEngine _engine;
        ScriptScope _scope;


        // single python
        private static UniIronPython _def;
        public static UniIronPython Default
        {
            get
            {
                if (_def == null)
                    _def = new UniIronPython();
                return _def;
            }
        }

        // execute python script
        public void Exec(string script)
        {
            try
            {
                this._engine.CreateScriptSourceFromString(script, SourceCodeKind.AutoDetect).Execute(_scope);
            }
            catch (MissingMemberException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(UnboundNameException ex)
            {
                Console.WriteLine(ex.Message);
            }catch(SyntaxErrorException ex)
            {
                //Books.Select(book=>book)
                Console.WriteLine(ex.Message);
            }catch(ImportException ex)
            {
                //import Linq
                Console.WriteLine(ex.Message);
            }
        }

        // register or unregister C# obj
        public void Register(object obj,string name)
        {
            this._scope.SetVariable(name, obj);
        }
        public void UnRegister(string name)
        {
            this._scope.RemoveVariable(name);
        }
    }
    public class UniIronPythonHelper
    {
        public static void ImportWinForm(UniIronPython py)
        {
            py.Exec("import clr");
            py.Exec("clr.AddReference(\"System.Drawing\")");
            py.Exec("clr.AddReference(\"System.Windows.Forms\")");
            py.Exec("from System.Drawing import Color");
            py.Exec("from System.Windows.Forms import Form");
            py.Exec("from System.Windows.Forms import Button");
            py.Exec("from System.Windows.Forms import DockStyle");
        }
    }
}
