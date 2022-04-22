using Hrms.Repository.Models;
using Hrms.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.RepositoryInterfaces
{
   public interface IAddressRepositoryInterface
    {

        Task<AddressInfo> PostAddress(AddressInfo add1);

        Task<IList<UserAddress>> getUserAddresses();

        Task<IList<Country>> getAllCountries();

        Task<IList<State>> getAllStates();

        Task<IList<City>> getAllCities();

        Task<IList<Pincode>> getAllPincodes();

        Task<IList<AddressInfo>> getAddressByUserId(string id);

        Task<IList<State>> getAllStatesBycountryId(int id);

        Task<IList<ProfileInformation>> getUserProfileById(string id);

        Task<IList<CurrentUser>> getCurrentUserName(string id);


    }
}
