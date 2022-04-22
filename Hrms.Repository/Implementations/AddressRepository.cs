using Hrms.Repository.Models;
using Hrms.Repository.RepositoryInterfaces;
using Hrms.Repository.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Repository.Implementations
{
    public class AddressRepository : IAddressRepositoryInterface
    {

        private readonly MyContext _myContext;

        public AddressRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<IList<AddressInfo>> getAddressByUserId(string id)
        {
            var result = await _myContext.AddressInfos.Where(x => x.UserId == id).ToListAsync();
            return result;
        }

        public async Task<IList<City>> getAllCities()
        {
            var result = await _myContext.Cities.ToListAsync();
            return result;
        }

        public async Task<IList<Country>> getAllCountries()
        {
            List<Country> countries = new List<Country>();
            var result = await _myContext.Countrys.ToListAsync();
            foreach (var item in result)
            {
               var states = await _myContext.States.Where(x => x.CountryId == item.CountryId).ToListAsync();
                //var states = new Country()
                //{
                //    CountryId = item.CountryId,
                //    ThreeCharCountryCode = item.ThreeCharCountryCode,
                //    TwoCharCountryCode = item.TwoCharCountryCode,
                //    StatesList = await _myContext.States.Where(x => x.CountryId == item.CountryId).ToListAsync()
                //};
               // countries.Add(states);

            }
            return result;
        }

        public async Task<IList<Pincode>> getAllPincodes()
        {
            var result = await _myContext.Pincodes.ToListAsync();
            return result;
        }

        public async Task<IList<State>> getAllStates()
        {
            var result = await _myContext.States.ToListAsync();
            return result;
        }

        public async Task<IList<State>> getAllStatesBycountryId(int id)
        {
         // var result =  await _myContext.States.ToListAsync();
            var countryId = await _myContext.Countrys.FindAsync(id);
            var result =   await _myContext.States.FindAsync(countryId.CountryId);
            var result1 = await _myContext.States.Where(x => x.CountryId == id).ToListAsync();
            return (IList<State>)result1;
           
        }

        public async Task<IList<CurrentUser>> getCurrentUserName(string id)
        {
            var result = await _myContext.CurrentUserName.FromSqlRaw("Exec usp_getCurrentUserName {0} ", id).ToListAsync();
            return result;
        }

        public async Task<IList<UserAddress>> getUserAddresses()
        {
            IList<UserAddress> list = await _myContext.AddressUsers.FromSqlRaw(" exec usp_AddressInfo ").ToListAsync();
            return list;
        }

        public async Task<IList<ProfileInformation>> getUserProfileById(string id)
        {
            var result = await _myContext.ProfileInformations.Where(x => x.UserId == id).ToListAsync();
            return result;
        }

        public async Task<AddressInfo> PostAddress(AddressInfo add1)
        {
            var result = await _myContext.AddressInfos.AddAsync(add1);
            await _myContext.SaveChangesAsync();
            return result.Entity;

        }
    }
}
