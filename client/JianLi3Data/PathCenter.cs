using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JianLi3Data.ProjectView;
namespace JianLi3Data
{
    /// <summary>
    /// 包含交互
    /// </summary>
    public class PathCenter
    {
        /// <summary>
        /// 建立项目
        /// </summary>
        /// <returns>可能为null</returns>
        public static Project CreateProject()
        {
            ProjectCreateForm c = new ProjectCreateForm();
            c.ShowDialog();
            return c.Project;
        }
        // 给模块建立任务，任务相关（需要当前的所有的项目迭代，供选择）
        public static Task CreateTask(ProjectModule module,Project project)
        {
            TaskCreateForm f = new TaskCreateForm();
            f.Project = project;
            f.Module = module;
            f.ShowDialog();

            return f.Task;
        }

        // 给模块建立子模块
        public static ProjectModule CreateModule(ProjectModule pm)
        {
            ModuleCreateForm f = new ModuleCreateForm();
            f.ParentModule = pm;
            f.ShowDialog();

            return f.Module;
        }
        // 删除解决方案
        // 当发现解决方案在本地计算机上被移除的时候
        public static void DelSolution(string solutionpath)
        {
            var solutions = from s in JianLiLinq.Default.DB.Solutions
                    where s.SolutionPath == solutionpath && s.MachineName == Environment.MachineName.ToLower()
                    select s;
            JianLiLinq.Default.DB.Solutions.DeleteAllOnSubmit(solutions);
            JianLiLinq.Default.DB.SubmitChanges();
        }
    }
}
