namespace TaskManagerAPIService.Migrationstask
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManagerAPIModels;

    internal sealed class Configuration : DbMigrationsConfiguration<TaskManagerAPIService.Context.TasksContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TaskManagerAPIService.Context.TasksContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var parentTasks = new List<ParentTasks> {
                new ParentTasks { ParentID = 1, ParentTaskName = "Parent Task 1"},
                new ParentTasks { ParentID = 2, ParentTaskName = "Parent Task 2"},
                new ParentTasks { ParentID = 3, ParentTaskName = null},
                new ParentTasks { ParentID = 4, ParentTaskName = "Task 1"},
                new ParentTasks { ParentID = 5, ParentTaskName = "Parent Task 3"},
                new ParentTasks { ParentID = 6, ParentTaskName = "Task 2"},
                new ParentTasks { ParentID = 7, ParentTaskName = "Task 2"},
            };
            parentTasks.ForEach(pt => context.ParentTasks.AddOrUpdate(pt));
            context.SaveChanges();

            var tasks = new List<Tasks>
            {
                new Tasks { TaskID = 1, TaskName = "Task 1", ParentID = 1, StartDate = DateTime.Parse("10/31/2018"), EndDate = DateTime.Parse("11/27/2018"), Priority = 10 },
                new Tasks { TaskID = 2, TaskName = "Task 2", ParentID = 2, StartDate = DateTime.Parse("10/09/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 20 },
                new Tasks { TaskID = 3, TaskName = "Task 3", ParentID = 3, StartDate = DateTime.Parse("10/10/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 30 },
                new Tasks { TaskID = 4, TaskName = "Task 4", ParentID = 4, StartDate = DateTime.Parse("10/11/2018"), EndDate = DateTime.Parse("11/10/2018"), Priority = 1 },
                new Tasks { TaskID = 5, TaskName = "Task 5", ParentID = 5, StartDate = DateTime.Parse("10/22/2018"), EndDate = DateTime.Parse("11/10/2018"), Priority = 5 },
                new Tasks { TaskID = 6, TaskName = "Task 6", ParentID = 6, StartDate = DateTime.Parse("10/22/2018"), EndDate = DateTime.Parse("11/20/2018"), Priority = 20},
                new Tasks { TaskID = 7, TaskName = "Task 7", ParentID = 7, StartDate = DateTime.Parse("10/22/2018"), EndDate = DateTime.Parse("11/20/2018"), Priority = 11 },
                new Tasks { TaskID = 8, TaskName = "Task 8", ParentID = 1, StartDate = DateTime.Parse("10/20/2018"), EndDate = DateTime.Parse("11/20/2018"), Priority = 25 },
                new Tasks { TaskID = 9, TaskName = "Task 9", ParentID = 2, StartDate = DateTime.Parse("10/20/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 20 },
                new Tasks { TaskID = 10, TaskName = "Task 10", ParentID = 3, StartDate = DateTime.Parse("10/21/2018"), EndDate = DateTime.Parse("11/25/2018"), Priority = 5 },
                new Tasks { TaskID = 11, TaskName = "Task 11", ParentID = 4, StartDate = DateTime.Parse("10/21/2018"), EndDate = DateTime.Parse("11/25/2018"), Priority = 5 },
                new Tasks { TaskID = 12, TaskName = "Task 12", ParentID = 5, StartDate = DateTime.Parse("10/10/2018"), EndDate = DateTime.Parse("11/25/2018"), Priority = 10 },
                new Tasks { TaskID = 13, TaskName = "Task 13", ParentID = 6, StartDate = DateTime.Parse("10/11/2018"), EndDate = DateTime.Parse("11/21/2018"), Priority = 30 },
                new Tasks { TaskID = 14, TaskName = "Task 14", ParentID = 7, StartDate = DateTime.Parse("10/11/2018"), EndDate = DateTime.Parse("11/21/2018"), Priority = 15 }
            };
            tasks.ForEach(t => context.Tasks.AddOrUpdate(t));
            context.SaveChanges();
        }
    }
}
