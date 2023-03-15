using System.Collections.Generic;

namespace Memory;

public partial class Indovina : ContentPage
{
    public Random rnd = new Random();
    public Dictionary<int, string> paesi = new Dictionary<int, string>();
    public int ciao;

    public Indovina()
    {
        ciao = rnd.Next(1, 44);
        paesi.Add(1, "città del vaticano");
        paesi.Add(16, "islanda");
        paesi.Add(40, "portogallo");
        paesi.Add(5, "macedonia");
        paesi.Add(17, "grecia");
        paesi.Add(29, "austria");
        paesi.Add(41, "spagna");
        paesi.Add(6, "montenegro");
        paesi.Add(18, "romania");
        paesi.Add(30, "svezia");
        paesi.Add(42, "francia");
        paesi.Add(7, "turchia");
        paesi.Add(19, "bulgaria");
        paesi.Add(31, "norvegia");
        paesi.Add(43, "italia");
        paesi.Add(8, "cipro");
        paesi.Add(20, "ungheria");
        paesi.Add(32, "danimarca");
        paesi.Add(9, "serbia");
        paesi.Add(21, "repubblica ceca");
        paesi.Add(33, "polonia");
        paesi.Add(10, "bosnia erzegovina");
        paesi.Add(22, "finlandia");
        paesi.Add(34, "russia");
        paesi.Add(11, "croazia");
        paesi.Add(23, "lituania");
        paesi.Add(35, "belgio");
        paesi.Add(12, "lussemburgo");
        paesi.Add(24, "lettonia");
        paesi.Add(36, "paesi bassi");
        InitializeComponent();
        bandiera.Source = ImageSource.FromFile("b" + ciao + ".png");
    }
    private void Invio(object sender, EventArgs e)
    {
        string testoInput = Input.Text.ToLower();
        if (testoInput == (string)paesi[Convert.ToInt32(ciao)])
        {
            DisplayAlert(Title, "cuuai", "Cancella");
        }
    }
}