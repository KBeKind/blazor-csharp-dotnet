using BlazorBethanyPieShop.App.Components.Widgets;

namespace BlazorBethanyPieShop.App.Pages
{
	public partial class Index
	{

		public List<Type> Widgets { get; set; } = new List<Type>() {
			typeof(EmployeeCountWidget), typeof(InboxWidget)
		};




	}
}
