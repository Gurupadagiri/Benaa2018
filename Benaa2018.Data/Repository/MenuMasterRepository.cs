using Microsoft.EntityFrameworkCore;
using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Data.Repository
{
    public class MenuMasterRepository : Repository<MenuMaster>, IMenuMasterRepository
    {
        public MenuMasterRepository(SBSDbContext context) : base(context) { }

        public async Task<List<MenuMaster>> GetMenuItemsById(int menuId)
        {
            return await Task.Factory.StartNew(() => _context.MenuMasters.Where(a => a.PatentId == menuId).ToList());            
        }
    }
}
