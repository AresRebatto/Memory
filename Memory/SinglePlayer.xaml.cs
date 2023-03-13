namespace Memory;

public partial class SinglePlayer : ContentPage
{
    private ImageButton[,] ButtonMatrix; //=> matrice che contiene i miei bottoni (passati con il nome)
    //Dichiarazioni variabili che serviranno per il controllo . . .
    private int[] vett = new int[3];
    private int[] indexFlags = new int[6];
    private int[,] matrix = new int[2, 3];
    private int[,] matrixCheck = new int[2, 3];
    private int[] valueRndRows = new int[6];
    private int[] valueRndColumns = new int[6];
    private int  countInziale = 0, countFinale, countTimes = 0, count = 0, indexVett = 0, countForFlags = 0;
    public SinglePlayer()
	{
		InitializeComponent();
        countFinale = indexFlags.Length / 2;
        ButtonMatrix = new ImageButton[2, 3]
        {
            {button00, button01, button02 },
            {button10, button11, button12 }
        };
        Random rnd = new Random();
        //Randomizzazione bandiere nelle posizioni del vettore
        for (int i = 0; i < vett.Length; i++)
        {
            do
            {
                vett[i] = rnd.Next(1, 43);
                for (int j = 0; j < i + 1; j++)
                {
                    if (j != i)
                    {
                        if (vett[j] == vett[i])
                            count++;
                    }
                }
            } while (count != 0);
        }
        foreach (var item in vett)
            Console.Write(item + "\t");
        //Randomizzazione posizioni del vettore. //3 randomizzazioni per 2 volte => devono venire fuori 6 posizioni, 3 uguali
        for (int giro = 0; giro < 2; giro++)
        {
            for (int parteVett = countInziale; parteVett < countFinale; parteVett++)
            {
                do
                {
                    count = 0;
                    indexVett = rnd.Next(0, vett.Length);
                    indexFlags[countTimes] = rnd.Next(0, vett.Length);
                    for (int j = countInziale; j < countTimes + 1; j++)
                    {
                        if (j != countTimes)
                        {
                            if (indexFlags[j] == indexFlags[countTimes])
                                count++;
                        }
                    }
                } while (count != 0);
                countTimes++;
            }
            countInziale = (indexFlags.Length / 2);
            countFinale = indexFlags.Length;
        }
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

    private void LeftArrow_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        //Button premuto
        var button = (ImageButton)sender;  
        //Ottengo la riga e la colonna
        int row = Grid.GetRow(button);
        int column = Grid.GetColumn(button);
        if(button.IsEnabled == true)
        {
            if(countForFlags < indexFlags.Length) //Cosi se ritorno la singleplayer dopo aver giocato, l'applicazione non crasha 
            {
                button.Source = ImageSource.FromFile("b" + Convert.ToString(vett[indexFlags[countForFlags]]) + ".png");
                button.IsEnabled = false; //Cosi se è gia stato premuto se lo ripremerà non ci saranno errori e il button verrà disabilitato
            }
        }
        button.Opacity= 1; //In questo modo anche se il button è disabled non verrà modificata la sua opacity essendo che quella di base è = 1
        countForFlags++;
    }
}