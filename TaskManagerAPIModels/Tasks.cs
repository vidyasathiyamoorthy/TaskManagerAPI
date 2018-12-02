using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPIModels
{
    public partial class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int ParentID { get; set; }
        [ForeignKey("ParentID")]
        public virtual ParentTasks Parent { get; set; }
    }

    public partial class ParentTasks
    {
        [Key]
        public int ParentID { get; set; }
        public string ParentTaskName { get; set; }
    }
}
