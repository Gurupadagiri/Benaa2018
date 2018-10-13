using System.Collections.Generic;
using System.Threading.Tasks;
using Benaa2018.Helper.ViewModels;

namespace Benaa2018.Helper.Interface
{
    public interface IToDoCheckListHelper
    {
        Task<ToDochecklistViewModel> SaveToDochecklistDetails(ToDochecklistViewModel toDochecklistViewModel);

        Task<List<ToDochecklistViewModel>> GetAllCheclistDetails(int todoDetailsID = 0);

        Task<ToDochecklistViewModel> DeleteToDochecklistDetails(ToDochecklistViewModel toDochecklistViewModel);

        Task<ToDochecklistViewModel> UpdateToDochecklistDetails(ToDochecklistViewModel toDochecklistViewModel);
    }
}
