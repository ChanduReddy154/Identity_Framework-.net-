using AutoMapper;
using Hrms.Business.BusinessInterfaces;
using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Hrms.Business.Implementations
{
   public class AddressBusiness : IAddressInterface
    {

        private readonly IAddressRepositoryInterface _addressRepositoryInterface;
        private readonly IMapper _mapper;

        public AddressBusiness(IAddressRepositoryInterface addressRepositoryInterface, IMapper mapper)
        {
           _addressRepositoryInterface = addressRepositoryInterface;
            _mapper = mapper;
        }

        public async Task<IList<AddressViewModel>> getAddressByUserId(string id)
        {
            var result = await _addressRepositoryInterface.getAddressByUserId(id);
            return _mapper.Map<IList<AddressViewModel>>(result);
        }

        public async Task<IList<CitiesViewModel>> getAllCities()
        {
            var result = await _addressRepositoryInterface.getAllCities();
            return _mapper.Map<IList<CitiesViewModel>>(result);
        }

        public async Task<IList<CountriesViewModel>> getAllCountries()
        {
           
            var result = await _addressRepositoryInterface.getAllCountries();
            return _mapper.Map<IList<CountriesViewModel>>(result);
        }

        public async Task<IList<PinCodeViewModel>> getAllPinCodes()
        {
            var result = await _addressRepositoryInterface.getAllPincodes();
            return _mapper.Map<IList<PinCodeViewModel>>(result);
        }

        public async Task<IList<StatesViewModel>> getAllStates()
        {
            var result = await _addressRepositoryInterface.getAllStates();
            return _mapper.Map<IList<StatesViewModel>>(result);
        }

        public async Task<IList<CurrentUserViewModel>> getCurrentUserName(string id)
        {
            var result = await _addressRepositoryInterface.getCurrentUserName(id);
            return _mapper.Map<IList<CurrentUserViewModel>>(result);
        }

        public async Task<IList<ProfileViewModel>> getProfileById(string id)
        {
            var result = await _addressRepositoryInterface.getUserProfileById(id);
            return _mapper.Map<IList<ProfileViewModel>>(result);
        }

        public async Task<IList<StatesViewModel>> getStatesByCountryId(int id)
        {
            var result = await _addressRepositoryInterface.getAllStatesBycountryId(id);
            return _mapper.Map<IList<StatesViewModel>>(result);
        }

        public async Task<IList<UserAddressViewModel>> getUsersAddresses()
        {
            var result = await _addressRepositoryInterface.getUserAddresses();
            return _mapper.Map<IList<UserAddressViewModel>>(result);
        }

        public async Task<AddressViewModel> PostAddress(AddressViewModel add1)
        {
            var result = await _addressRepositoryInterface.PostAddress(_mapper.Map<AddressInfo>(add1));
            return _mapper.Map<AddressViewModel>(result);
        }
    }
}
