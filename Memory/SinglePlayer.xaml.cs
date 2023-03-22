using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;

namespace Memory;

public partial class SinglePlayer : ContentPage
{
    //Dichiarazioni variabili che serviranno per il controllo . . .
    private int[] vett;
    private int[] indexFlags;
    private int[,] matrix;
    private int countForFlags = 0, countForFinish = 0;
    private ImageButton buttonBefore;
    private int appoggio;
    private ObservableCollection<ImageButton> notEnabledButtons = new ObservableCollection<ImageButton>();
    private static readonly Random rnd = new Random();
    public SinglePlayer()
    {
        InitializeComponent();
    }
    private void SceltaModalita_SelectedIndexChanged(object sender, EventArgs e)
    {
        int count = 0;
        // codice per gestire l'evento di selezione dell'item
        if (SceltaModalita.SelectedIndex == 0)
        {
            //numero di Coppie
            matrix = new int[2, 3];
        }
        else if (SceltaModalita.SelectedIndex == 1)
        {
            // codice da eseguire se l'item "Option 2" è selezionato
            matrix = new int[4, 3];
            for (count = 6; count < 12; count++)
                ((ImageButton)myGrid.Children[count]).IsVisible = true;
        }
        else if (SceltaModalita.SelectedIndex == 2)
        {
            // codice da eseguire se l'item "Option 3" è selezionato
            matrix = new int[6, 3];
            for (count = 6; count < 18; count++)
                ((ImageButton)myGrid.Children[count]).IsVisible = true;
        }
        vett = new int[(matrix.GetLength(0) * matrix.GetLength(1)) / 2];
        indexFlags = new int[matrix.Length];
        myGrid.IsVisible = true;
        SceltaModalita.IsVisible = false;
        Randomizzazione(vett, indexFlags, matrix, countForFlags);
    }

    private void Randomizzazione(int[] vett, int[] indexFlags, int[,] matrix, int countForFlags)
    {
        int countFinale = indexFlags.Length / 2, count = 0, countInziale = 0, indexVett = 0, countTimes = 0;
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

        //* Questa matrice conterrà le bandiere e le loro posizioni corrisponderanno alle posizioni dei buttons 

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = vett[indexFlags[countForFlags]];
                countForFlags++;
            }
        }
        countForFlags = 0;//Ripristinarlo
    }

    private void LeftArrow_Clicked(object sender, EventArgs e)
    {
        App.Current.MainPage = new MainPage();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        int count = 0;
        //Button premuto    
        var button = (ImageButton)sender;
        //Prendo la riga e la colonna dei buttons per poi assegnarli la giusta bandiera che si trova all'interno della matrice già riempita (matrix)
        int row = Grid.GetRow(button);
        int column = Grid.GetColumn(button);
        if (button.IsEnabled)
        {
            button.Source = ImageSource.FromFile("b" + Convert.ToString(matrix[row, column]) + ".png");
            if (countForFlags == 0) //Per disabilitare il primo button
                button.IsEnabled = false;
            else if (countForFlags % 2 != 0) //dispari pk quando ho scelto il secondo button il contatore sarà dispari
            {
                if (matrix[row, column] == appoggio) //Se la bandiera del button di ora è uguale a quella del button di prima => li disabiliti
                {
                    button.IsEnabled = false;
                    buttonBefore.IsEnabled = false;
                    countForFinish++;
                }
                else //Se la bandiera di ora è diversa da quella di prima => entrambi i button allora ritorneranno anonimi
                {
                    foreach (var child in myGrid.Children)
                    {
                        if (child is ImageButton button2 && button2.IsEnabled)
                            notEnabledButtons.Add(button2);
                    }
                    foreach (var button2 in notEnabledButtons)
                    {
                        button2.IsEnabled = false;
                        button2.Opacity = 1;
                    }

                    await Task.Delay(500); //Attesa prima che i buttons ritornano con la question

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
        if (countForFinish == (matrix.GetLength(0) * matrix.GetLength(1)) / 2) //Le bandiere sono state trovate tutte
        {
            countForFinish = 0;
            leftArrow.IsVisible = false;
            await Task.Delay(1000);//=>Attesa di un secondo prima che appaia il popUp
            leftArrow.IsVisible = true;
            this.ShowPopup(new PopupPage());
            //Ripristino tutto a prescindere che scegla di tornare alla home oppure di rimanere in single
            foreach (ImageButton child in myGrid.Children)
            {
                child.IsEnabled = true;
                child.Source = ImageSource.FromFile("questionmark.png");
                //Rendere invisibili i buttons dal sesto in poi
                if (count > 5)
                    child.IsVisible = false;
                count++; //Per capire a che punto mi trovo della grid
            }
            countForFlags = 0;
            countForFinish = 0;
            notEnabledButtons.Clear();
            myGrid.IsVisible = false;
            SceltaModalita.IsVisible = true;
        }
        //Randomizzazione(rnd, vett, indexFlags, matrix, countForFlags);
    }
}