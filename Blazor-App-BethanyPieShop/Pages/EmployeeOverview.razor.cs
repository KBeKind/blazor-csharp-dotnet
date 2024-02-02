using BethanysPieShopHRM.Shared.Domain;
using BlazorBethanyPieShop.App.Models;
using BlazorBethanyPieShop.App.Services;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorBethanyPieShop.App.Pages
{
	public partial class EmployeeOverview
	{

		[Inject]
		public IEmployeeDataService? EmployeeDataService { get; set; }

		public List<Employee>? Employees { get; set; } = default!;

		private Employee? _selectedEmployee;

		private string Title = "Employee Overview";

		protected override async Task OnInitializedAsync()
		{
			Employees = (await EmployeeDataService.GetAllEmployees()).ToList();
		}



		public void ShowQuickViewPopup(Employee selectedEmployee)
		{
			_selectedEmployee = selectedEmployee;
		}

	}
}
