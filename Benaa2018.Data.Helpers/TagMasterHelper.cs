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
   public  class TagMasterHelper : ITagMasterHelper
    {
        private readonly ITagMasterRepository _tagMasterHelper;
        public TagMasterHelper(ITagMasterRepository tagMasterRepository)
        {
            _tagMasterHelper = tagMasterRepository;
        }

        public async Task<List<TagMasterViewModel>> GetAllTagMasterDetails(int TagsId = 0)
        {
            List<TagMasterViewModel> lstTagMasterModel = new List<TagMasterViewModel>();
            var tagInfo = await _tagMasterHelper.GetAllAsync();

            tagInfo.ToList().ForEach(item =>
            {
                lstTagMasterModel.Add(new TagMasterViewModel
                {
                   TagId=item.TagId,
                   TagName=item.TagName
                });
            });
            if(TagsId > 0)
            {
                lstTagMasterModel = lstTagMasterModel.Where(a => a.TagId == TagsId).ToList();
             }
            return lstTagMasterModel;
        }

        public async Task<TagMasterViewModel> SaveTagMasterDetails(TagMasterViewModel tagMasterViewModel)
        {
            TagMaster tagMasterDatails = new TagMaster()
            {
                //TagId= tagMasterViewModel.TagId,
                TagName=tagMasterViewModel.TagName,
                Created_By = "aaaa",
                Modified_By = "aaa",
                Created_Date = DateTime.Today,
                Modified_Date = DateTime.Today
            };
            var tagObj = await _tagMasterHelper.CreateAsync(tagMasterDatails);
            TagMasterViewModel tagMasterDetailsViewModel = new TagMasterViewModel
            {
                TagId = Convert.ToInt32(tagObj.TagId)
            };

            return tagMasterDetailsViewModel;
        }
    }
}
