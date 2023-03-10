namespace Memory;

public partial class SinglePlayer : ContentPage
{
	public SinglePlayer()
	{
		InitializeComponent();
		SceltaModalita.SelectedItem = "Facile";
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }
}