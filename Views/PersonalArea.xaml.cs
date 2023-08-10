using EL.MAUI.BlackList.ViewModel;

namespace EL.MAUI.BlackList.Views;

public partial class PersonalArea : ContentPage
{
	public PersonalArea()
	{
		InitializeComponent();
		BindingContext = new PersonalAreaViewModel();

    }
}