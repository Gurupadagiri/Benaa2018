using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper.ViewModels
{
    public class MenuViewModel
    {
        public MenuViewModel()
        {
            Menus = new List<MenuViewModel>();
        }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public string ImageUrl { get; set; }
        public string CssClass { get; set; }
        public List<MenuViewModel> Menus { get; set; }
    }
}
