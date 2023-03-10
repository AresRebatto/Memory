namespace Memory;

public partial class SinglePlayer : ContentPage
{
	public SinglePlayer()
	{
		InitializeComponent();
		SceltaModalita.SelectedItem = "Facile";
        SceltaModalita.SelectedIndexChanged += (sender, args) =>
        {
            // codice per gestire l'evento di selezione dell'item
            if (SceltaModalita.SelectedIndex == 0)
            {
                //numero diCoppie
            }
            else if (SceltaModalita.SelectedIndex == 1)
            {
                // codice da eseguire se l'item "Option 2" è selezionato
            }
            else if (SceltaModalita.SelectedIndex == 2)
            {
                // codice da eseguire se l'item "Option 3" è selezionato
            }
        };
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }
}