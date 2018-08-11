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
    public class ToDoTagHelper : IToDoTagHelper
    {
        private readonly IToDoTagRepository _toDoTagHelper;

        public ToDoTagHelper(IToDoTagRepository toDoTagRepository)
        {
            _toDoTagHelper = toDoTagRepository;
        }
        public async Task<ToDoTagViewModel> SaveToDoTagDetails(ToDoTagViewModel toDoTagViewModel)
        {
            ToDoTag toDoTagDetails = new ToDoTag
            {
                ToDoTagid = toDoTagViewModel.ToDoTagid,
                Tagid = toDoTagViewModel.Tagid,
                TodoDetailsID = toDoTagViewModel.TodoDetailsID
            };
            var TagObj = await _toDoTagHelper.CreateAsync(toDoTagDetails);
            ToDoTagViewModel toDoTagDetailsViewModel = new ToDoTagViewModel
            {
                ToDoTagid = Convert.ToInt32(TagObj.ToDoTagid)
            };

            return toDoTagDetailsViewModel;
        }

        public async Task<List<ToDoTagViewModel>> GetAllTags(int TodoDetailID = 0)
        {
            List<ToDoTagViewModel> lstToDoTagModel = new List<ToDoTagViewModel>();
            IEnumerable<ToDoTag> lstToDoTag = null;
            lstToDoTag = await _toDoTagHelper.GetAllAsync();

            if (lstToDoTag != null)
            {
                if (TodoDetailID > 0)
                {
                    lstToDoTag = lstToDoTag.Where(a => a.TodoDetailsID == TodoDetailID).ToList();



                    if (lstToDoTag != null)
                    {
                        foreach (var item in lstToDoTag)
                        {
                            lstToDoTagModel.Add(new ToDoTagViewModel
                            {
                                ToDoTagid = item.ToDoTagid,
                                Tagid = item.Tagid,
                                TodoDetailsID = item.TodoDetailsID

                            });
                        }
                    }
                }

                //if(Tagids.Count()>0)
                //{
                //    lstToDoTag = lstToDoTag.Where(a => a.Tagid==Convert.ToInt32 ( Tagids[0])).ToList();
                //}
            }

            return lstToDoTagModel;
        }



    }
}
