using System;
using System.Collections.Generic;
using System.Text;
using EnvDTE80;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using System.Runtime.InteropServices;
using System.Drawing;

namespace JianLi.VisualStudio
{
    public static class VsUtilities
    {
        public static readonly Guid CSharpLibrary = new Guid("58f1bad0-2288-45b9-ac3a-d56398f7781d");
        public static readonly Guid VBLibrary = new Guid("414AC972-9829-4B6A-A8D7-A08152FEB8AA");

        public static uint IVsObjectList2Count(IVsObjectList2 list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
                        
            uint count;
            list.GetItemCount(out count);
            return count;
        }

        public static IVsLibrary2[] GetIVsLibraries(DTE2 dte)
        { 
            List<IVsLibrary2> libraries = new List<IVsLibrary2>();

            IVsLibrary2 cSharpLibrary = GetIVsLibrary2(dte, VsUtilities.CSharpLibrary);
            if (cSharpLibrary != null)
                libraries.Add(cSharpLibrary);

            IVsLibrary2 vbLibrary = GetIVsLibrary2(dte, VsUtilities.VBLibrary);
            if (vbLibrary != null)
                libraries.Add(vbLibrary);

            return libraries.ToArray();
        }

        public static IVsObjectList2 SearchIVsLibrary(IVsLibrary2 library, string keyword, VSOBSEARCHTYPE searchType)
        {           
            VSOBSEARCHCRITERIA2[] searchCriteria = new VSOBSEARCHCRITERIA2[1];
            searchCriteria[0].eSrchType = searchType;
            searchCriteria[0].szName = keyword;

            IVsObjectList2 objectList = null;
            library.GetList2((uint)_LIB_LISTTYPE.LLT_CLASSES, (uint)_LIB_LISTFLAGS.LLF_USESEARCHFILTER, searchCriteria, out objectList);
            return objectList;        
        }

        public static Project[] GetAllProjectsInSolution(DTE2 dte)
        {
            List<Project> projects = new List<Project>();

            foreach (Project project in dte.Solution.Projects)
            {
                projects.Add(project);
                if (project.ProjectItems != null)
                {
                    GetAllProjectsInSolution(projects, project.ProjectItems);
                }
            }

            return projects.ToArray();
        }

        private static void GetAllProjectsInSolution(List<Project> projects, ProjectItems projectItems)
        {
            foreach (ProjectItem projectItem in projectItems)
            {
                if (projectItem.SubProject != null)
                {
                    projects.Add(projectItem.SubProject);
                    GetAllProjectsInSolution(projects, projectItem.SubProject.ProjectItems);
                }

                if (projectItem.ProjectItems != null)
                {
                    GetAllProjectsInSolution(projects, projectItem.ProjectItems);
                }
            }
        }

        public static ProjectItem[] GetAllProjectItemsInSolution(DTE2 dte)
        {
            List<ProjectItem> projectItems = new List<ProjectItem>();

            Project[] projects = GetAllProjectsInSolution(dte);
            foreach (Project project in projects)
            {
                if (project.ProjectItems != null)
                {
                    GetAllProjectItemsInSolution(projectItems, project.ProjectItems);
                }
            }

            return projectItems.ToArray();
        }

        private static void GetAllProjectItemsInSolution(List<ProjectItem> list, ProjectItems projectItems)
        {
            foreach (ProjectItem projectItem in projectItems)
            {
                list.Add(projectItem);

                if (projectItem.ProjectItems != null)
                {
                    GetAllProjectItemsInSolution(list, projectItem.ProjectItems);
                }
            }
        }
        
        //public static IVsLibrary2 GetCSharpLibrary(DTE2 dte)
        //{
        //    if (dte == null)
        //        throw new ArgumentNullException("dte");

        //    return GetIVsLibrary2(dte, VsUtilities.CSharpLibrary);
        //}

        public static IVsLibrary2 GetIVsLibrary2(DTE2 dte, Guid guid)
        {
            if (dte == null)
                throw new ArgumentNullException("dte");
            
            IVsObjectManager2 objectManager = GetIVsObjectManager2(dte);
            IVsLibrary2 library = null;
            objectManager.FindLibrary(ref guid, out library);
            return library;
        }

        private static IVsObjectManager2 GetIVsObjectManager2(DTE2 dte)
        {
            if (dte == null)
                throw new ArgumentNullException("dte");

            Microsoft.VisualStudio.OLE.Interop.IServiceProvider sp = (Microsoft.VisualStudio.OLE.Interop.IServiceProvider)dte;
            Guid iid = typeof(IVsObjectManager2).GUID;
            Guid service = typeof(SVsObjectManager).GUID;
            IntPtr pUnk;
            sp.QueryService(ref service, ref iid, out pUnk);
            IVsObjectManager2 manager = (IVsObjectManager2)Marshal.GetObjectForIUnknown(pUnk);
            return manager;
        }

        public static void ShowContextMenu(DTE2 dte, string commandBarName, Point point)
        {
            if (dte == null)
                throw new ArgumentNullException("dte");

            if (commandBarName == null)
                throw new ArgumentNullException("commandBarName");
            
            Commands2 commands = (Commands2)dte.Commands;
            Microsoft.VisualStudio.CommandBars.CommandBars commandBars = (Microsoft.VisualStudio.CommandBars.CommandBars)dte.CommandBars;
            Microsoft.VisualStudio.CommandBars.CommandBar commandBar = commandBars[commandBarName];

            commandBar.ShowPopup(point.X, point.Y);
        }


        public static bool ShowCodeElement(CodeElement codeElement)
        {
            if (codeElement == null)
                throw new ArgumentNullException("codeElement");

            //Move cursor to beginning of the symbol. 
            //TODO: Find a better way ...
            Document document = codeElement.DTE.ActiveDocument;
            if (document == codeElement.ProjectItem.Document)
            {            
                TextPoint textPoint = codeElement.GetStartPoint(vsCMPart.vsCMPartNavigate);

                TextSelection ts = (TextSelection)document.Selection;
                ts.MoveToPoint(textPoint, false);
                ts.ActivePoint.TryToShow(vsPaneShowHow.vsPaneShowCentered, null);
                

                //ts.SelectLine();
                //string text = ts.Text;
                //int pos = text.IndexOf(codeElement.Name) + 1;
                //ts.MoveTo(codeElement.StartPoint.Line, pos, false);
                //codeElement.StartPoint.TryToShow(vsPaneShowHow.vsPaneShowCentered, null);
                return true;
            }
            return false;
        }

    }
}
