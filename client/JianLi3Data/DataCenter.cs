using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JianLi3Data
{
    public class DataCenter
    {
        /// <summary>
        /// 建立项目
        /// 不允许项目同名。
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static Project CreateProject(string name,string desc)
        {
            var prj = from project in JianLiLinq.Default.DB.Projects
                      where project.Name == name
                      select project;

            if (prj.Count() > 0)
                throw new Exception("项目 "+name+" 已经存在，请换个名称。");

            // 先保证项目有一个根模块，以便添加模块和任务。
            // 新建一个模块。
            Guid pmguid = Guid.NewGuid();
            Guid pguid = Guid.NewGuid();

            ProjectModule pm = new ProjectModule();
            pm.ID = pmguid;
            pm.Name = name;// 初始化时跟项目同名
            pm.Comment = "";
            pm.Parent = pguid;
            JianLiLinq.Default.DB.ProjectModules.InsertOnSubmit(pm);


            Project p = new Project();
            p.ID = pguid;
            p.Name = name;
            p.Desc = desc;
            p.ProjectModule = pm;// 此后不能改变
            JianLiLinq.Default.DB.Projects.InsertOnSubmit(p);

            // 必须新建一个ProjectIteration,否则新建的任务无法分配周期。
            ProjectIteration pi = new ProjectIteration();
            pi.ID = Guid.NewGuid();
            pi.Name = "周期 1";
            pi.Order = 0;
            pi.Project = p;
            pi.Comment = "默认建立的周期，请填写描述。";
            JianLi3Data.JianLiLinq.Default.DB.ProjectIterations.InsertOnSubmit(pi);

            JianLiLinq.Default.DB.SubmitChanges();
            return p;
        }

        public static Task CreateTask(ProjectModule module,ProjectIteration iteration,string name ,string comment,byte priority)
        {
            Task t = new Task();
            t.ID = Guid.NewGuid();
            t.Parent = module.ID;
            t.Comment = comment;
            t.Priority = priority;
            t.ProjectIteration = iteration;
            t.Title = name;
            JianLiLinq.Default.DB.Tasks.InsertOnSubmit(t);

            JianLiLinq.Default.DB.SubmitChanges();
            return t;
        }

        internal static ProjectModule CreateModule(ProjectModule parentModule, string name, string comment)
        {
            ProjectModule newmodule = new ProjectModule();
            newmodule.ID = Guid.NewGuid();
            newmodule.Name = name;
            newmodule.Comment = comment;
            newmodule.Parent = parentModule.ID;
            JianLiLinq.Default.DB.ProjectModules.InsertOnSubmit(newmodule);

            JianLiLinq.Default.DB.SubmitChanges();

            return newmodule;
        }



        // 设定Task Iteration 2
        internal static void SetTaskIteration(ref Task t, ProjectIteration pi)
        {
            t.ProjectIteration = pi;
            JianLiLinq.Default.DB.SubmitChanges();
        }

        // 设定Task Iteration 1
        internal static ProjectIteration GetProjectIteration(Project project, string iterationname)
        {
            foreach (ProjectIteration pi in project.ProjectIterations)
                if (pi.Name == iterationname)
                    return pi;

            throw new Exception("没有为项目：" + project.Name + ",找到迭代：" + iterationname);
        }
    }
}
