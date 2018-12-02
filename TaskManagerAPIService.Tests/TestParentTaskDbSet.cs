using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPIModels;

namespace TaskManagerAPIService.Tests
{
    class TestParentTaskDbSet : TestDbSet<ParentTasks>
    {
        public override ParentTasks Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.ParentID == (int)keyValues.Single());
        }
    }
}
