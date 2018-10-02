﻿using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class VarianceMasterRepository : Repository<VarianceMaster>, IVarianceMasterRepository
    {
        public VarianceMasterRepository(SBSDbContext context) : base(context) { }

        public override async Task<IEnumerable<VarianceMaster>> GetAllAsync()
        {
            var varianceMasters = _context.VarianceMasters.AsNoTracking().ToList();
            return varianceMasters;
        }
    }
}
