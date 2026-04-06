namespace Naidis_TARpe24.TTTViews;

public partial class TripsTrapsTrullPage : ContentPage
{
    GameService game = new GameService();
    bool vsAI = false;
    string playerSymbol = "X";
    string aiSymbol = "O";
    Button[,] buttons;
    public TripsTrapsTrullPage()
	{
		InitializeComponent();
	}
    

    protected override void OnAppearing()
    {
        base.OnAppearing();
        CreateGrid();
    }

    void CreateGrid()
    {
        buttons = new Button[3,3];
        GameGrid.RowDefinitions.Clear();
        GameGrid.ColumnDefinitions.Clear();
        GameGrid.Children.Clear();
        

        for (int i = 0; i < 3; i++)
        {
            GameGrid.RowDefinitions.Add(new RowDefinition());
            GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                var btn = new Button
                {
                    BackgroundColor = Colors.White,
                    BorderColor = Colors.Black,
                    BorderWidth = 5,
                    FontSize = 32,
                };

                buttons[row, col] = btn;

                int r = row;
                int c = col;

                btn.Clicked += async (s, e) =>
                {
                    if (!game.MakeMove(r, c))
                        return;

                    btn.Text = game.Board[r, c];

                    var winner = game.CheckWinner();

                    if (winner != null)
                    {
                        await DisplayAlert("Võit!", $"{winner} võitis!", "OK");
                        game.ResetGame();
                        CreateGrid();
                        return;
                    }

                    if (game.IsDraw())
                    {
                        await DisplayAlert("Viik", "Keegi ei võitnud!", "OK");
                        game.ResetGame();
                        CreateGrid();
                        return;
                    }

                    // mängid boti vastu kui valitud
                    if (vsAI)
                    {
                        var (aiRow, aiCol) = game.GetAIMove();

                        if (aiRow != -1)
                        {
                            game.Board[aiRow, aiCol] = aiSymbol;
                            game.CurrentPlayer = playerSymbol;

                            buttons[aiRow, aiCol].Text = aiSymbol;

                            winner = game.CheckWinner();

                            if (winner == "X")
                            {
                                int xWins = Preferences.Get("xWins", 0);
                                Preferences.Set("xWins", xWins + 1);
                                game.ResetGame();
                                CreateGrid();
                            }
                            else if (winner == "O")
                            {
                                int oWins = Preferences.Get("oWins", 0);
                                Preferences.Set("oWins", oWins + 1);
                                game.ResetGame();
                                CreateGrid();
                            }
                            if (game.IsDraw())
                            {
                                int draws = Preferences.Get("draws", 0);
                                Preferences.Set("draws", draws + 1);
                                game.ResetGame();
                                CreateGrid();
                            }
                        }
                    }
                };

                GameGrid.Add(btn, col, row);
            }
        }
    }
    void OnNewGameClicked(object sender, EventArgs e)
    {
        game.ResetGame();
        CreateGrid();
    }

    void OnSwitchSymbol(object sender, EventArgs e)
    {
        if (playerSymbol == "X")
        {
            playerSymbol = "O";
            aiSymbol = "X";
        }
        else
        {
            playerSymbol = "X";
            aiSymbol = "O";
        }

        game.ResetGame();
        CreateGrid();

        DisplayAlert("Sümbol", $"Mängija: {playerSymbol}", "OK");
    }
    void OnPlayWithAIClicked(object sender, EventArgs e)
    {
        vsAI = true;
        game.ResetGame();
        CreateGrid();
        DisplayAlert("Režiim", "Mängid boti vastu!", "OK");
    }
    void OnTwoPlayerClicked(object sender, EventArgs e)
    {
        vsAI = false;
        game.ResetGame();
        CreateGrid();
        DisplayAlert("Režiim", "2 mängijat", "OK");
    }
}