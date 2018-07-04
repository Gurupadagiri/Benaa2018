using Benaa2018.Data.Interfaces;
using Benaa2018.Helper.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class WarrentyAlertHelper : IWarrentyAlertHelper
    {
        public IWarrentyAlertRepoisitory _warrentyAlertRepoisitory;
        public WarrentyAlertHelper(IWarrentyAlertRepoisitory warrentyAlertRepoisitory)
        {
            _warrentyAlertRepoisitory = warrentyAlertRepoisitory;
        }

        public async Task<List<WarrentyAlertViewModel>> GetAllWarrenties()
        {
            List<WarrentyAlertViewModel> lstWarrentyModel = new List<WarrentyAlertViewModel>();
            var warrenties = await _warrentyAlertRepoisitory.GetAllAsync();
            warrenties.ToList().ForEach(item =>
            {
                lstWarrentyModel.Add(new WarrentyAlertViewModel
                {
                    UserID = item.User_ID,
                    WarrentAlertId = item.Warrent_Alert_Id,
                    WarrentyName = item.Warrenty_Name,
                    WarrentyYear = item.Warrenty_Year                   
                });
            });
            return lstWarrentyModel;
        }
    }
}
