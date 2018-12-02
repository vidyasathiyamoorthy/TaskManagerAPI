using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPIModels
{
    public class TasksModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Priority { get; set; }
        public int ParentID { get; set; }
        public string ParentTaskName { get; set; }
    }

    public class ParentTasksModel
    {
        public int ParentID { get; set; }
        public string ParentTaskName { get; set; }
    }
}
