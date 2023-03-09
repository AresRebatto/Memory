namespace Memory;

public partial class MuliPlayer : ContentPage
{
	public MuliPlayer()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }
}