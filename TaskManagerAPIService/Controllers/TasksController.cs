using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerAPIModels;
using TaskManagerAPIService.Context;
using TaskManagerAPIService.Helpers;
using System.Web.Http.Cors;

namespace TaskManagerAPIService.Controllers
{
    [EnableCors(origins:"http://localhost:4200", headers:"*", methods:"*")]
    public class TasksController : ApiController
    {
        //for unit test - added constructors
        private TasksHelper db;

        public TasksController() {
            db = new TasksHelper(); 
        }

        public TasksController(ITasksContext context)
        {
            db = new TasksHelper(context);
        }

        // GET: api/Tasks
        [HttpGet]
        [Route("api/tasks")]
        public IQueryable<TasksModel> GetTasks()
        {
            return db.GetAllTasks();
        }

        [HttpGet]
        [Route("api/tasksNew")]
        public IHttpActionResult GetTasksNew()
        {
            var tasks = db.GetAllTasks();
            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        [HttpGet]
        [Route("api/tasks/{tskID}")]
        public TasksModel GetTasksByID(int tskID)
        {
            return db.GetTasksByID(tskID); ;
        }


        [HttpGet]
        [Route("api/tasksNew/{tskID}")]
        public IHttpActionResult GetTasksByIDNew(int tskID)
        {
            var tasks =  db.GetTasksByID(tskID);
            if(tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpPut]
        [Route("api/tasks/update/{tskid}")]
        public IHttpActionResult UpdateTask(int tskid, TasksModel tsk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (tskid != tsk.TaskID)
            {
                return BadRequest();
            }

            var result = db.UpdateTask(tsk);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [Route("api/tasks/parents")]
        public IQueryable<ParentTasksModel> GetParentTasks()
        {
            return db.GetAllParents();
        }

        [HttpGet]
        [Route("api/tasks/getTaskID")]
        public int GetNewTaskID()
        {
            return db.GetNewTaskID(); ;

        }

        [HttpPost]
        [Route("api/tasks/add")]
        public IHttpActionResult AddTask(TasksModel tsk)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = db.AddTask(tsk);
            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        [Route("api/tasks/delete/{tskid}")]
        /// region start
        /// region end
        public IHttpActionResult DeleteTask(int tskid)
        {
            db.DeleteTask(tskid);
            return StatusCode(HttpStatusCode.NoContent);
        }

        //// GET: api/Tasks/5
        //[ResponseType(typeof(Tasks))]
        //public async Task<IHttpActionResult> GetTasks(int id)
        //{
        //    Tasks tasks = await db.Tasks.FindAsync(id);
        //    if (tasks == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(tasks);
        //}

        //// PUT: api/Tasks/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutTasks(int id, Tasks tasks)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tasks.TaskID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(tasks).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TasksExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Tasks
        //[ResponseType(typeof(Tasks))]
        //public async Task<IHttpActionResult> PostTasks(Tasks tasks)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Tasks.Add(tasks);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = tasks.TaskID }, tasks);
        //}

        //// DELETE: api/Tasks/5
        //[ResponseType(typeof(Tasks))]
        //public async Task<IHttpActionResult> DeleteTasks(int id)
        //{
        //    Tasks tasks = await db.Tasks.FindAsync(id);
        //    if (tasks == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Tasks.Remove(tasks);
        //    await db.SaveChangesAsync();

        //    return Ok(tasks);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool TasksExists(int id)
        //{
        //    return db.Tasks.Count(e => e.TaskID == id) > 0;
        //}
    }
}