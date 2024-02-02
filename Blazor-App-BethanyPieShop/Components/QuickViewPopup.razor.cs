using BethanysPieShopHRM.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace BlazorBethanyPieShop.App.Components
{
	public partial class QuickViewPopup
	{

		[Parameter]
		public Employee? Employee { get; set; }

		private Employee? _employee;
	}
}
