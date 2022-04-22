using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.BusinessInterfaces
{
    public interface IAddressInterface
    {
        Task<AddressViewModel> PostAddress(AddressViewModel add1);

        Task<IList<UserAddressViewModel>> getUsersAddresses();

        Task<IList<CountriesViewModel>> getAllCountries();

        Task<IList<CitiesViewModel>> getAllCities();

        Task<IList<StatesViewModel>> getAllStates();

        Task<IList<PinCodeViewModel>> getAllPinCodes();

        Task<IList<AddressViewModel>> getAddressByUserId(string id);

        Task<IList<ProfileViewModel>> getProfileById(string id);

        Task<IList<StatesViewModel>> getStatesByCountryId(int id);

        Task<IList<CurrentUserViewModel>> getCurrentUserName(string id);
    }
}
