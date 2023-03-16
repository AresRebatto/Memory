using System.Collections.Generic;

namespace Memory;

public partial class Indovina : ContentPage
{
    public Random rnd = new Random();
    public Dictionary<int, string> paesi = new Dictionary<int, string>();
    public int num, contoVite=3;
    public string[] dizionario = {"città del vaticano", "islanda", "portogallo", "macedonia",
                                  "grecia", "austria", "spagna", "montenegro", "romania", "svezia",
                                  "francia", "turchia", "bulgaria", "norvegia", "italia", "cipro",
                                  "ungheria","danimarca","serbia","repubblica ceca", "polonia", "bosnia erzegovina",
                                  "finlandia", "russia", "croazia", "lituania", "belgio", "lussemburgo", "lettonia",
                                  "paesi bassi","olanda", "regno unito"};
    public Indovina()
    {
        InitializeComponent();
        num = rnd.Next(1, 44);
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
        paesi.Add(39, "gran bretagna");
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
        paesi.Add(37, "germania");
        paesi.Add(2, "moldavia");
        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
    }
    private void Invio(object sender, EventArgs e)
    {
        int contoErrori = 0;
        string testoInput = Input.Text.ToLower().Trim();
        if (testoInput == paesi[num])
        {
            DisplayAlert("", "HAI VINTO!!!", "Cancella");
        }
        else
        {
            switch (num)
            {
                case 1:
                    if (testoInput == "vaticano")
                    {
                        DisplayAlert("", "HAI VINTO!!!", "Cancella");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                    }
                    break;
                case 36:
                    if (testoInput == "olanda")                  
                    {
                        DisplayAlert("", "HAI VINTO!!!", "Cancella");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                    }
                    break;
                case 10:
                    if (testoInput == "bosnia")
                    {
                        DisplayAlert("", "HAI VINTO!!!", "Cancella");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                    }
                    break;
                case 39:
                    if (testoInput == "regno unito")
                    {
                        DisplayAlert("", "HAI VINTO!!!", "Cancella");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                    }
                    break;
            }

            foreach (string parolacorretta in dizionario)
            {
                if (parolacorretta.Length == paesi[num].Length)
                {
                    for (int i = 0; i < parolacorretta.Length; i++)
                        if (Input.Text[i] != parolacorretta[i])
                            contoErrori++;
                    if (contoErrori <= (parolacorretta.Length / 3))
                    {
                        Attenzione.Text = "Attenzione, c'è qualcosa di sbagliato nella parola che hai scritto";
                    }
                }
            }
            if (paesi[num]!=testoInput)
            {
                Vite.Text = Convert.ToString(Convert.ToInt32(Vite) - 1);
            }
            else DisplayAlert("", "HAI VINTO!!!", "Cancella");
        }
        if (paesi[num] == testoInput)
        {
            num = rnd.Next(1, 44);
            bandiera.Source = ImageSource.FromFile("b" + num + ".png");
        }
    }
    private void LeftArrow_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }
}