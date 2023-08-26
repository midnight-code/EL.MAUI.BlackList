using CommunityToolkit.Maui.Views;

namespace EL.MAUI.BlackList.Views.Modals;

public partial class ResponsePopup : Popup
{
	public ResponsePopup(string error)
	{
		InitializeComponent();
        GetErrorDetails(error);
	}

    public void GetErrorDetails(string value)
    {
        switch (value)
        {
            case "null":
                ErrorText.Text = "Логин Пароль не могут быть иметь пустое значение!";
                break;
            case "regex":
                ErrorText.Text = "Логин вводиться в формате e-mail, пароль должен содержать только латинские буквы [a-z], длина 8 символов, одиин спец символ{!,.+-_] цифры [0-9] и одну заглавную букву [A-Z]!";
                break;
            case "confirm":
                ErrorText.Text = "Пороли должны совподать";
                break;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}