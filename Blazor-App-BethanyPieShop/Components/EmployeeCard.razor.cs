using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorBethanyPieShop.App.Components
{
	public partial class EmployeeCard
	{
		[Parameter]
		public Employee Employee { get; set; } = default!;

	}
}
