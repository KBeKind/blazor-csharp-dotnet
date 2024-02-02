using BethanysPieShopHRM.Shared.Domain;

namespace BlazorBethanyPieShop.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
