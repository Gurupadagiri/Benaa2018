using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoCheckListDetailsHelper
    {
        Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel, int todoCheckListID = 0);

        Task<List<ToDochecklistDetailsViewModel>> GetAllCheclistDetailsDescription(int todoCheckListID = 0);


        Task DeleteToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel);

        Task<ToDochecklistDetailsViewModel> UpdateToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel);
    }
}
