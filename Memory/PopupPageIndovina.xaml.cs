using CommunityToolkit.Maui.Views;

namespace Memory;

public partial class PopupPageIndovina : Popup
{
    
	public PopupPageIndovina()
	{
		InitializeComponent();
	}
    private void ReturnHome(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
        Close();
    }
    private void PlayAgain(object sender, EventArgs e)
    {
        Close();
        App.Current.MainPage = new Indovina();
    }
}