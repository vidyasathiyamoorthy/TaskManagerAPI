using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskManagerAPIModels;
using TaskManagerAPIService.Controllers;

namespace TaskManagerAPIService.Tests.Controllers
{
    [TestClass]
    public class TasksControllerTest
    {
        [TestMethod]
        public void GetAllTasks_ShouldGetAllTasks()
        {
            var context = new TestTasksContext();

            context.ParentTasks.Add(new ParentTasks { ParentID = 1, ParentTaskName = "Parent Task 1" });
            context.ParentTasks.Add(new ParentTasks { ParentID = 2, ParentTaskName = "Parent Task 2" });
            context.ParentTasks.Add(new ParentTasks { ParentID = 3, ParentTaskName = "This task has no parent Task" });

            context.Tasks.Add(new Tasks { TaskID = 1, TaskName = "Task 1", ParentID = 1, StartDate = DateTime.Parse("10/31/2018"), EndDate = DateTime.Parse("11/27/2018"), Priority = 10, Parent = new ParentTasks { ParentID = 1, ParentTaskName = "Parent 1"} });
            context.Tasks.Add(new Tasks { TaskID = 2, TaskName = "Task 2", ParentID = 2, StartDate = DateTime.Parse("10/09/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 20, Parent = new ParentTasks { ParentID = 2, ParentTaskName = "Parent 2" } });
            context.Tasks.Add(new Tasks { TaskID = 3, TaskName = "Task 3", ParentID = 3, StartDate = DateTime.Parse("10/10/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 30, Parent = new ParentTasks { ParentID = 3, ParentTaskName = "Parent 3" } });


            var controller = new TasksController(context);
            var result = controller.GetTasks() as IQueryable<TasksModel>;
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public async Task GetTaskById_ShouldGetTaskById()
        {
            var context = new TestTasksContext();

            context.ParentTasks.Add(new ParentTasks { ParentID = 1, ParentTaskName = "Parent Task 1" });
            context.ParentTasks.Add(new ParentTasks { ParentID = 2, ParentTaskName = "Parent Task 2" });
            context.ParentTasks.Add(new ParentTasks { ParentID = 3, ParentTaskName = "This task has no parent Task" });

            context.Tasks.Add(new Tasks { TaskID = 1, TaskName = "Task 1", ParentID = 1, StartDate = DateTime.Parse("10/31/2018"), EndDate = DateTime.Parse("11/27/2018"), Priority = 10, Parent = new ParentTasks { ParentID = 1, ParentTaskName = "Parent 1" } });
            context.Tasks.Add(new Tasks { TaskID = 2, TaskName = "Task 2", ParentID = 2, StartDate = DateTime.Parse("10/09/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 20, Parent = new ParentTasks { ParentID = 2, ParentTaskName = "Parent 2" } });
            context.Tasks.Add(new Tasks { TaskID = 3, TaskName = "Task 3", ParentID = 3, StartDate = DateTime.Parse("10/10/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 30, Parent = new ParentTasks { ParentID = 3, ParentTaskName = "Parent 3" } });


            var controller = new TasksController(context);
            var result = controller.GetTasksByID(1) as TasksModel;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.TaskID);
        }

        [TestMethod]
        public void DeleteProduct_ShouldReturnOK()
        {
            var context = new TestTasksContext();
            var item = GetDemoTask();
            context.Tasks.Add(item);

            var controller = new TasksController(context);
            var result = controller.DeleteTask(1);

            //Assert.IsNotNull(result);
            //Assert.AreEqual(item.TaskID, resu);
        }

        Tasks GetDemoTask()
        {
            return new Tasks { TaskID = 1, TaskName = "Task 1", ParentID = 1, StartDate = DateTime.Parse("10/31/2018"), EndDate = DateTime.Parse("11/27/2018"), Priority = 10, Parent = new ParentTasks { ParentID = 1, ParentTaskName = "Parent 1" } };
        }

        private List<TasksModel> GetTestTasks()
        {
            var tasks = new List<TasksModel>
            {
                new TasksModel { TaskID = 1, TaskName = "Task 1", ParentID = 1, StartDate = DateTime.Parse("10/31/2018"), EndDate = DateTime.Parse("11/27/2018"), Priority = 10 },
                new TasksModel { TaskID = 2, TaskName = "Task 2", ParentID = 2, StartDate = DateTime.Parse("10/09/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 20 },
                new TasksModel { TaskID = 3, TaskName = "Task 3", ParentID = 3, StartDate = DateTime.Parse("10/10/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 30 },
                new TasksModel { TaskID = 4, TaskName = "Task 4", ParentID = 4, StartDate = DateTime.Parse("10/11/2018"), EndDate = DateTime.Parse("11/10/2018"), Priority = 1 },
                new TasksModel { TaskID = 5, TaskName = "Task 5", ParentID = 5, StartDate = DateTime.Parse("10/22/2018"), EndDate = DateTime.Parse("11/10/2018"), Priority = 5 },
                new TasksModel { TaskID = 6, TaskName = "Task 6", ParentID = 6, StartDate = DateTime.Parse("10/22/2018"), EndDate = DateTime.Parse("11/20/2018"), Priority = 20},
                new TasksModel { TaskID = 7, TaskName = "Task 7", ParentID = 7, StartDate = DateTime.Parse("10/22/2018"), EndDate = DateTime.Parse("11/20/2018"), Priority = 11 },
                new TasksModel { TaskID = 8, TaskName = "Task 8", ParentID = 1, StartDate = DateTime.Parse("10/20/2018"), EndDate = DateTime.Parse("11/20/2018"), Priority = 25 },
                new TasksModel { TaskID = 9, TaskName = "Task 9", ParentID = 2, StartDate = DateTime.Parse("10/20/2018"), EndDate = DateTime.Parse("11/09/2018"), Priority = 20 },
                new TasksModel { TaskID = 10, TaskName = "Task 10", ParentID = 3, StartDate = DateTime.Parse("10/21/2018"), EndDate = DateTime.Parse("11/25/2018"), Priority = 5 },
                new TasksModel { TaskID = 11, TaskName = "Task 11", ParentID = 4, StartDate = DateTime.Parse("10/21/2018"), EndDate = DateTime.Parse("11/25/2018"), Priority = 5 },
                new TasksModel { TaskID = 12, TaskName = "Task 12", ParentID = 5, StartDate = DateTime.Parse("10/10/2018"), EndDate = DateTime.Parse("11/25/2018"), Priority = 10 },
                new TasksModel { TaskID = 13, TaskName = "Task 13", ParentID = 6, StartDate = DateTime.Parse("10/11/2018"), EndDate = DateTime.Parse("11/21/2018"), Priority = 30 },
                new TasksModel { TaskID = 14, TaskName = "Task 14", ParentID = 7, StartDate = DateTime.Parse("10/11/2018"), EndDate = DateTime.Parse("11/21/2018"), Priority = 15 }
            };
            return tasks;
        }
        private List<ParentTasks> GetTestParentTasks()
        {
            var parentTasks = new List<ParentTasks> {
                new ParentTasks { ParentID = 1, ParentTaskName = "Parent Task 1"},
                new ParentTasks { ParentID = 2, ParentTaskName = "Parent Task 2"},
                new ParentTasks { ParentID = 3, ParentTaskName = "This task has no parent Task"},
                new ParentTasks { ParentID = 4, ParentTaskName = "Task 1"},
                new ParentTasks { ParentID = 5, ParentTaskName = "Parent Task 3"},
                new ParentTasks { ParentID = 6, ParentTaskName = "Task 2"},
                new ParentTasks { ParentID = 7, ParentTaskName = "Task 2"},
            };
            return parentTasks;
        }
    }
}
