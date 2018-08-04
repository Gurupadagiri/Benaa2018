using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
   public  class ToDoCheckListDetailsHelper : IToDoCheckListDetailsHelper
    {
        private readonly IToDochecklistDetailsRepository _toDchecklistDetailsHelper;

        public ToDoCheckListDetailsHelper(IToDochecklistDetailsRepository toDochecklistDetailsRepository)
        {
            _toDchecklistDetailsHelper = toDochecklistDetailsRepository;
        }

        public Task<List<ToDochecklistDetailsViewModel>> GetAllCheclistDetailsDescription(int todoDetailsID = 0)
        {
            throw new NotImplementedException();
        }

        public Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
