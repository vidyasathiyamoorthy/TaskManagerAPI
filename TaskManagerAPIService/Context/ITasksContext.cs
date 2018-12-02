using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using TaskManagerAPIModels;

namespace TaskManagerAPIService.Context
{
    public interface ITasksContext : IDisposable
    {
        DbSet<Tasks> Tasks { get; }
        DbSet<ParentTasks> ParentTasks { get; }
        int SaveChanges();
        void MarkAsModified(Tasks item);
        //void MarkAsModified(ParentTasks item);
    }
}
