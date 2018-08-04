using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoCheckListDetailsHelper
    {
        Task<ToDochecklistDetailsViewModel> SaveToDochecklistDetailsDescription(ToDochecklistDetailsViewModel toDochecklistViewModel);

        Task<List<ToDochecklistDetailsViewModel>> GetAllCheclistDetailsDescription(int todoDetailsID = 0);
    }
}
