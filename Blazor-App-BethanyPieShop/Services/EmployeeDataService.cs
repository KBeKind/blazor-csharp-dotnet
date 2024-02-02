using BethanysPieShopHRM.Shared.Domain;
using BlazorBethanyPieShop.App.Helper;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BlazorBethanyPieShop.App.Services
{
	public class EmployeeDataService : IEmployeeDataService
	{

		private readonly HttpClient _httpClient;

		private readonly ILocalStorageService _localStorageService;

		public EmployeeDataService(HttpClient httpClient, ILocalStorageService localStorageService)
		{
			_httpClient = httpClient;
			_localStorageService = localStorageService;
		}


		public async Task<IEnumerable<Employee>> GetAllEmployees(bool refreshRequired = false)
		{
			// CHECK IF THE EXPIRATION KEY EXISTS AND IF IT IS PASSED THE EXPIRATION TIME IF IT IS STILL VALID THEN USE THE STORED DATA

			if (!refreshRequired)
			{

				bool employeeExpirationExists = await _localStorageService.ContainKeyAsync
					(LocalStorageConstants.EmployeesListExpirationKey);
				if (employeeExpirationExists)
				{

					DateTime employeeListExpiration = await _localStorageService.GetItemAsync<DateTime>
						(LocalStorageConstants.EmployeesListExpirationKey);

					if (employeeListExpiration > DateTime.Now)
					{
						if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeesListKey))
						{
							Console.WriteLine("using stored data");

							return await
								_localStorageService.GetItemAsync<IEnumerable<Employee>>
								(LocalStorageConstants.EmployeesListKey);
						}
					}
				}

			}

			// IF DATA IS PASSED EXPIRATION REFRESH THE LIST LOCALLY FROM THE API AND SET EPIRATION TO 1 MUNUTE IN THE FUTURE

			var list = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
				await _httpClient.GetStreamAsync($"api/employee"),
				new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

			await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListKey, list);

			await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListExpirationKey, DateTime.Now.AddMinutes(1));

			return list;

		}

		public async Task<Employee> GetEmployeeDetails(int employeeId)
		{
			return await JsonSerializer.DeserializeAsync<Employee>(
				await _httpClient.GetStreamAsync($"api/employee/{employeeId}"),
				new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
		}

		public Task<Employee> AddEmployee(Employee employee)
		{
			throw new NotImplementedException();
		}

		public Task DeleteEmployee(int employeeId)
		{
			throw new NotImplementedException();
		}

		public Task UpdateEmployee(Employee employee)
		{
			throw new NotImplementedException();
		}
	}
}
