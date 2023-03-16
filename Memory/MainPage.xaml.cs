using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
namespace Memory;

public partial class MainPage : ContentPage
{

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
        App.Current.MainPage = new MuliPlayer();
    }
    private void Indovina_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new Indovina();
    }
}

