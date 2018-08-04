using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benaa2018.Data.Repository
{
    public class ToDoScheduleItemRepository : Repository<ToDoScheduleItem>, IToDoScheduleItemRepository
    {
        public ToDoScheduleItemRepository(SBSDbContext context) : base(context) { }
    }
}
