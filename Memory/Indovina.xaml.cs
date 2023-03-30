using CommunityToolkit.Maui.Views;
using System.Collections.Generic;

namespace Memory;

public partial class Indovina : ContentPage
{
    public Random rnd = new();
    public int vite;
    public int punteggio;
    public Dictionary<int, string> paesi = new();
    public int num, contoVite=3;
    //Dizionario per parole di controllo
    public string[] dizionario = {"città del vaticano", "islanda", "portogallo", "macedonia",
                                  "grecia", "austria", "spagna", "montenegro", "romania", "svezia",
                                  "francia", "turchia", "bulgaria", "norvegia", "italia", "cipro",
                                  "ungheria","danimarca","serbia","repubblica ceca", "polonia", "bosnia erzegovina",
                                  "finlandia", "russia", "croazia", "lituania", "belgio", "lussemburgo", "lettonia",
                                  "paesi bassi","olanda", "regno unito", "san marino", "malta", "monaco", "svizzera",
                                  "bielorussia", "estonia", "albania", "slovacchia", "slovenia", "irlanda"};
    public Indovina()
    {
        InitializeComponent();
        num = rnd.Next(1, 44);
        //Assegnazione dictionary
        paesi.Add(1, "città del vaticano");
        paesi.Add(3, "san marino");
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
        paesi.Add(4, "malta");
        paesi.Add(36, "paesi bassi");
        paesi.Add(37, "germania");
        paesi.Add(2, "moldavia");
        paesi.Add(13, "monaco");
        paesi.Add(14, "svizzera");
        paesi.Add(15, "bielorussia");
        paesi.Add(25, "estonia");
        paesi.Add(26, "albania");
        paesi.Add(27, "slovacchia");
        paesi.Add(28, "slovenia");
        paesi.Add(38, "irlanda");
        vite = Convert.ToInt32(Vite.Text);
        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
    }
    private async void Invio(object sender, EventArgs e)
    {
        int contoErrori=0;
        bool control = false;
        //Eliminazione spazi e LowerCase per il testo in input
        string testoInput = "Questo Testo è Inutile";
        if(Input.Text!= null)
            testoInput = Input.Text.ToLower().Trim();
        //Vittoria con input corretto
        if (testoInput == paesi[num])
        {
            await DisplayAlert("", "CORRETTOO!!!", "CONTINUA");
            control = true;
        }
        else
        {
            //Aggiunti casi per paesi nominabili in più modi
            switch (num)
            {
                case 1:
                    if (testoInput == "vaticano")
                    {
                        await DisplayAlert("", "CORRETTOO!!!", "CONTINUA");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                        control = true;
                    }
                    break;
                case 36:
                    if (testoInput == "olanda")
                    {
                        await DisplayAlert("", "CORRETTOO!!!", "CONTINUA");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                        control = true;
                    }
                    break;
                case 10:
                    if (testoInput == "bosnia")
                    {
                        await DisplayAlert("", "CORRETTOO!!!", "CONTINUA");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                        control = true;
                    }
                    break;
                case 39:
                    if (testoInput == "regno unito")
                    {
                        await DisplayAlert("", "CORRETTOO!!!", "CONTINUA");
                        num = rnd.Next(1, 44);
                        bandiera.Source = ImageSource.FromFile("b" + num + ".png");
                        control = true;
                    }
                    break;
            }
            if (control == false)
            {
                //Controllo sulla parola se non è corretta
                foreach (string parolacorretta in dizionario)
                {
                    if (parolacorretta.Length == testoInput.Length)
                    {
                        if (parolacorretta == paesi[num])
                        {
                            //Conteggio numero errori
                            for (int i = 0; i < parolacorretta.Length; i++)
                                if (testoInput[i] != parolacorretta[i])
                                    contoErrori++;
                            //Se c'è un basso numero di errori in base alla lunghezza della parola la si da buona
                            if (contoErrori <= (parolacorretta.Length / 3))
                            {
                                await DisplayAlert("CORRETTOO!!!", "C'erano " + contoErrori + " errore/i nella parola", "CONTINUA");
                                testoInput = parolacorretta;
                                control = true;
                            }
                        }
                    }
                    else
                    {
                        if (parolacorretta == paesi[num])
                        {
                            if (testoInput!=parolacorretta)
                                await DisplayAlert("", "QUELLO CHE HAI INSERITO NON E' CORRETTO RIPROVA!", "RIPROVA");   
                        }
                    }
                }

            }
        }
        //Se si vince incrementa la var punteggio e cambia la sorgente dell'immagine
        if (control == true)
        {
            punteggio+=1;
            Score.Text = punteggio.ToString();
            num = rnd.Next(1, 44);
            bandiera.Source = ImageSource.FromFile("b" + num + ".png");
        }
        //Se si sbaglia decrementano le vite
        else
        { 
            vite--;
            Vite.Text = (vite).ToString();
        }
        // Quando finiscono le vite si apre il popup
        if (vite == 0)
        {
            await Task.Delay(500);//Attesa di mezzo secondo prima che appaia il popUp
            this.ShowPopup(new PopupPageIndovina());
        }
        //Testo ripristinato
        Input.Text = "";
    }
    private void LeftArrow_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }
}