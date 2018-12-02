using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerAPIModels;

namespace TaskManagerAPIService.Tests
{
    class TestTaskDbSet : TestDbSet<Tasks>
    {
        public override Tasks Find(params object[] keyValues)
        {
            return this.SingleOrDefault(x => x.TaskID == (int)keyValues.Single());
        }
    }
}
