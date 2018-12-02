using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using TaskManagerAPIModels;
using TaskManagerAPIService.Context;

namespace TaskManagerAPIService.Helpers
{
    public class TasksHelper
    {
        private ITasksContext db = new TasksContext();

        //for unit test - added constructors
        //private ITasksContext dbCon = new TasksContext();

        public TasksHelper() { }

        public TasksHelper(ITasksContext context)
        {
            db = context;
        }



        public IQueryable<TasksModel> GetAllTasks()
        {
            //var taskData = from t in db.Tasks join 
            //               pt in db.ParentTasks on
            //               t.ParentID equals pt.ParentID
            //               select new TasksModel
            //               {
            //                   TaskID = t.TaskID,
            //                   ParentID = t.Parent.ParentID,
            //                   TaskName = t.TaskName,
            //                   StartDate = DbFunctions.TruncateTime(t.StartDate),
            //                   EndDate = DbFunctions.TruncateTime(t.EndDate),
            //                   Priority = t.Priority,
            //                   ParentTaskName = t.Parent.ParentTaskName
            //               };
            var taskData = db.Tasks.Select(x=> new TasksModel { TaskID = x.TaskID, TaskName = x.TaskName, ParentID = x.ParentID, ParentTaskName = x.Parent.ParentTaskName, Priority = x.Priority, StartDate = x.StartDate, EndDate = x.EndDate});
            return taskData;
        }

        public TasksModel GetTasksByID(int tskID)
        {
            //var taskData = from t in db.Tasks join
            //                pt in db.ParentTasks on
            //                t.ParentID equals pt.ParentID
            //               where t.TaskID == tskID
            //                select new TasksModel
            //                {
            //                   TaskID = t.TaskID,
            //                   TaskName = t.TaskName,
            //                   ParentID = t.Parent.ParentID,
            //                   ParentTaskName = t.Parent.ParentTaskName,
            //                   Priority = t.Priority,
            //                   StartDate = DbFunctions.TruncateTime(t.StartDate),
            //                   EndDate = DbFunctions.TruncateTime(t.EndDate)                               
            //                };
            var taskData = db.Tasks.Select(x => new TasksModel { TaskID = x.TaskID, TaskName = x.TaskName, ParentID = x.ParentID, ParentTaskName = x.Parent.ParentTaskName, Priority = x.Priority, StartDate = x.StartDate, EndDate = x.EndDate }).Where(x=>x.TaskID == tskID).SingleOrDefault();

            return taskData;
        }

        public bool UpdateTask(TasksModel tsk)
        {
            ParentTasks pt = new ParentTasks();
            pt.ParentID = tsk.ParentID;
            pt.ParentTaskName = tsk.ParentTaskName;

            Tasks t = new Tasks();
            t.TaskID = tsk.TaskID;
            t.TaskName = tsk.TaskName;
            t.Priority = tsk.Priority;
            t.ParentID = pt.ParentID;
            if (tsk.StartDate.HasValue)
                t.StartDate = tsk.StartDate.Value;
            if (tsk.EndDate.HasValue)
                t.EndDate = tsk.EndDate.Value;
            //t.StartDate = DbFunctions.TruncateTime(tsk.StartDate.Value.Date);
            //t.EndDate = DbFunctions.TruncateTime(tsk.EndDate.Value.Date);
            //db.Entry(pt).State = EntityState.Modified;
            //db.MarkAsModified(t);
            //db.SaveChanges();
            //db.Entry(t).State = EntityState.Modified;
            db.MarkAsModified(t);
            db.SaveChanges();
            return true;
        }

        public IQueryable<ParentTasksModel> GetAllParents()
        {
            var parentData = from pt in db.ParentTasks
                           select new ParentTasksModel
                           {
                               ParentID = pt.ParentID,
                               ParentTaskName = pt.ParentTaskName
                           };
            return parentData;
        }
        public int GetNewTaskID()
        {
            var myTasks = db.Tasks.Select(x => x.TaskID);
            var tsk = from t in db.Tasks
                      orderby t.TaskID descending
                      select t.TaskID;
            int newTaskID = tsk.Take(1).Single();
            return newTaskID;
        }
        public bool AddTask(TasksModel tsk)
        {
            ParentTasks pt = new ParentTasks();
            pt.ParentID = tsk.ParentID;
            pt.ParentTaskName = tsk.ParentTaskName;

            Tasks t = new Tasks();
            t.TaskID = tsk.TaskID;
            t.TaskName = tsk.TaskName;
            t.Priority = tsk.Priority;
            t.ParentID = pt.ParentID;
            if (tsk.StartDate.HasValue)
                t.StartDate = tsk.StartDate.Value;
            if (tsk.EndDate.HasValue)
                t.EndDate = tsk.EndDate.Value;
            //db.Entry(pt).State = EntityState.Modified;
            //db.SaveChanges();
            db.MarkAsModified(t);
            //db.Entry(t).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public void DeleteTask(int tskid)
        {
            var tsk = db.Tasks.Where(tt => tt.TaskID == tskid).Single();
            //var parentTskID = db.Tasks.Where(t => t.TaskID == tskid).Select(u => u.ParentID).Single();
            //var parentTsk = db.ParentTasks.Where(pt => pt.ParentID == tsk.ParentID).Single();
            db.Tasks.Remove(tsk);
            //db.ParentTasks.Remove(parentTsk);
            db.SaveChanges();          
        }
    }
}