namespace Memory;

public partial class MuliPlayer : ContentPage
{
    private int[] vett = new int[3];
    private int[] indexFlags = new int[6];
    private int[,] matrix = new int[2, 3];
    private int[,] matrixCheck = new int[2, 3];
    private int[] valueRndRows = new int[6];
    private int[] valueRndColumns = new int[6];
    private int countInziale = 0, countFinale, countTimes = 0, count = 0, indexVett = 0, countForFlags = 0;
    private ImageButton buttonBefore;

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        if(FrstPlayer !=  null && ScndPlayer != null)
        {

        }
    }

    private int appoggio;
    private List<ImageButton> notEnabledButtons = new List<ImageButton>();

    public MuliPlayer()
    {
        InitializeComponent();
        countFinale = indexFlags.Length / 2;
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
        /*
            * Questa matrice conterrà le bandiere e le loro posizioni corrisponderanno alle posizioni dei buttons 
         */
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = vett[indexFlags[countForFlags]];
                countForFlags++;
            }
        }
        countForFlags = 0;//Ripristinarlo
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

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //Button premuto    
        var button = (ImageButton)sender;
        //Prendo la riga e la colonna dei buttons per poi assegnarli la giusta bandiera che si trova all'interno della matrice già riempita (matrix)
        int row = Grid.GetRow(button);
        int column = Grid.GetColumn(button);
        if (button.IsEnabled == true)
        {
            button.Source = ImageSource.FromFile("b" + Convert.ToString(matrix[row, column]) + ".png");
            if (countForFlags == 0) //Per disabilitare il primo button
                button.IsEnabled = false;
            if (countForFlags > 0 && countForFlags % 2 != 0) //dispari pk quando ho scelto il secondo button il contatore sarà dispari
            {
                if (matrix[row, column] == appoggio) //Se la bandiera del button di ora è uguale a quella del button di prima => li disabiliti
                {
                    button.IsEnabled = false;
                    buttonBefore.IsEnabled = false;
                }
                else //Se la bandiera di ora è diversa da quella di prima => entrambi i button allora ritorneranno anonimi
                {
                    foreach (ImageButton button2 in myGrid.Children)
                    {
                        if (button2.IsEnabled == true)
                            notEnabledButtons.Add(button2);
                        if (button.IsEnabled == button2.IsEnabled) // Utilizza l'operatore di confronto invece di assegnamento
                            button2.IsEnabled = false;
                    }
                    await Task.Delay(250); //Attesa prima che i buttons ritornano con la question
                    foreach (var button3 in notEnabledButtons)
                        button3.IsEnabled = true;
                    button.Source = ImageSource.FromFile("questionmark.png");
                    buttonBefore.Source = ImageSource.FromFile("questionmark.png");
                    button.IsEnabled = true;
                    buttonBefore.IsEnabled = true;
                }
            }
        }
        countForFlags++; // => capire a che giro ci troviamo 
        appoggio = matrix[row, column]; //Appoggio assume la bandiera del button precedente 
        buttonBefore = button; //ButtonBefore assume le caratteristiche del button precedente
        button.Opacity = 1;
        notEnabledButtons.Clear(); //Clear della lista
    }

    

}