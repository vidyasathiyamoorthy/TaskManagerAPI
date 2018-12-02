using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaskManagerAPIService.Context
{
    public class TasksContext : DbContext, ITasksContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TasksContext() : base("name=TasksContext")
        {
        }

        public System.Data.Entity.DbSet<TaskManagerAPIModels.Tasks> Tasks { get; set; }

        public System.Data.Entity.DbSet<TaskManagerAPIModels.ParentTasks> ParentTasks { get; set; }

        public void MarkAsModified(TaskManagerAPIModels.Tasks item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public void MarkAsModified(TaskManagerAPIModels.ParentTasks item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}
