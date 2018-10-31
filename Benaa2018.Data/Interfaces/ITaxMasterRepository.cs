﻿using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Interfaces
{
    public interface ITaxMasterRepository : IRepository<TaxMaster>
    {
        Task<List<TaxMaster>> GetListByTaxMasterId(int projectID);


    }
}