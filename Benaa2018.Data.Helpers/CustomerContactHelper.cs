using Benaa2018.Data.Interfaces;
using Benaa2018.Data.Model;
using Benaa2018.Helper.Interface;
using Benaa2018.Helper.ViewModels;
using System.Threading.Tasks;

namespace Benaa2018.Helper
{
    public class CustomerContactHelper : ICustomerContactHelper
    {
        ICustomerContactRepository _customerContactRepository;
        public CustomerContactHelper(ICustomerContactRepository customerContactRepository)
        {
            _customerContactRepository = customerContactRepository;
        }

        public async Task<int> SaveCustomerContactAsync(CustomerContactViewModel customerContactModel)
        {
            var objCustomerContact = new CustomerContactDetails
            {
                CustomerName= customerContactModel.CustomerName,
                CellEmail= customerContactModel.CellEmail,
                CompanyId= customerContactModel.CompanyId,
                CellPhone= customerContactModel.CellPhone,
                City= customerContactModel.City,
                Email = customerContactModel.Email,
                Name= customerContactModel.Name,
                Phone = customerContactModel.Phone,
                State = customerContactModel.State,
                StreetAddress = customerContactModel.StreetAddress,
                Zip = customerContactModel.Zip                
            };
            var customerContact = await _customerContactRepository.CreateAsync(objCustomerContact);
            return customerContact.CustomerContactId;
        }

        public async Task<int> UpdateCustomerContactAsync(CustomerContactViewModel customerContactModel)
        {
            var objCustomerContact = new CustomerContactDetails
            {
                CustomerContactId = customerContactModel.CustomerContactId,
                CustomerName = customerContactModel.CustomerName,
                CellEmail = customerContactModel.CellEmail,
                CompanyId = customerContactModel.CompanyId,
                CellPhone = customerContactModel.CellPhone,
                City = customerContactModel.City,
                Email = customerContactModel.Email,
                Name = customerContactModel.Name,
                Phone = customerContactModel.Phone,
                State = customerContactModel.State,
                StreetAddress = customerContactModel.StreetAddress,
                Zip = customerContactModel.Zip
            };
            var customerContact = await _customerContactRepository.UpdateAsync(objCustomerContact);
            return customerContact.CustomerContactId;
        }
    }
}
