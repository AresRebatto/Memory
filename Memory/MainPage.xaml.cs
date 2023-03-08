namespace Memory;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

    private void SinglePlayer(object sender, EventArgs e)
    {
        App.Current.MainPage = new SinglePlayer();
    }

    private void MultiPlayer_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new SinglePlayer();
    }
}

