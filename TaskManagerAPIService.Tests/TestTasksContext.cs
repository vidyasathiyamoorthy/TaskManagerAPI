using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPIModels;
using TaskManagerAPIService.Context;

namespace TaskManagerAPIService.Tests
{
    public class TestTasksContext : ITasksContext
    {
        public TestTasksContext()
        {
            this.Tasks = new TestTaskDbSet();
            this.ParentTasks = new TestParentTaskDbSet();
        }

        public System.Data.Entity.DbSet<Tasks> Tasks { get; set; }

        public System.Data.Entity.DbSet<ParentTasks> ParentTasks { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Tasks item) { }
        //public void MarkAsModified(ParentTasks item) { }
        public void Dispose() { }
    }
}
