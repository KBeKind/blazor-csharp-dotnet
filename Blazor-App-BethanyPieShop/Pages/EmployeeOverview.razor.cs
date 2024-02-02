using BethanysPieShopHRM.Shared.Domain;
using BlazorBethanyPieShop.App.Models;

namespace BlazorBethanyPieShop.App.Pages
{
	public partial class EmployeeOverview
	{

		public List<Employee>? Employees { get; set; } = default!;

		protected override void OnInitialized()
		{
			Employees = MockDataService.Employees;
		}

	}
}
