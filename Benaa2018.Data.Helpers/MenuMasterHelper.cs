using Benaa2018.Data.Interfaces;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class MenuMasterHelper : IMenuMasterHelper
    {
        private readonly IMenuMasterRepository _menuMasterRepoisitory;
        public MenuMasterHelper(IMenuMasterRepository menuMasterRepoisitory)
        {
            _menuMasterRepoisitory = menuMasterRepoisitory;
        }
        public async Task<List<MenuViewModel>> GetMenuItems()
        {
            List<MenuViewModel> lstMenuItems = new List<MenuViewModel>();
            var menuItems = await _menuMasterRepoisitory.GetAllAsync();
            menuItems.Where(a => a.PatentId == 0).ToList().ForEach(item =>
            {
                MenuViewModel menuModel = new MenuViewModel
                {
                    ImageUrl = string.Empty,
                    MenuId = item.Menu_ID,
                    MenuName = item.Menu_Name,
                    MenuUrl = item.Url,
                    CssClass = item.CssClass
                };
                var menusByID = _menuMasterRepoisitory.GetMenuItemsById(item.Menu_ID);
                menusByID.ForEach(menu =>
                {
                    MenuViewModel subMenuModel = new MenuViewModel
                    {
                        ImageUrl = string.Empty,
                        MenuId = menu.Menu_ID,
                        MenuName = menu.Menu_Name,
                        MenuUrl = menu.Url,
                        CssClass = menu.CssClass,
                    };
                    menuModel.Menus.Add(subMenuModel);
                });
                lstMenuItems.Add(menuModel);
            });
            return lstMenuItems;
        }
    }
}
