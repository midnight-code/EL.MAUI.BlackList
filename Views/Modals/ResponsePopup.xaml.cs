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
                ErrorText.Text = "����� ������ �� ����� ���� ����� ������ ��������!";
                break;
            case "regex":
                ErrorText.Text = "����� ��������� � ������� e-mail, ������ ������ ��������� ������ ��������� ����� [a-z], ����� 8 ��������, ����� ���� ������{!,.+-_] ����� [0-9] � ���� ��������� ����� [A-Z]!";
                break;
            case "confirm":
                ErrorText.Text = "������ ������ ���������";
                break;
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		Close();
    }
}