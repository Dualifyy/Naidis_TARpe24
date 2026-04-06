namespace Naidis_TARpe24.TTTViews;

public partial class TripsTrapsTrullPage : ContentPage
{
    bool vsAI = false;
    string playerSymbol = "X";
    string aiSymbol = "O";
    Button[,] buttons;
    public TripsTrapsTrullPage()
	{
		InitializeComponent();
	}
    GameService game = new GameService();

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
                            game.MakeMove(aiRow, aiCol);

                            buttons[aiRow, aiCol].Text = aiSymbol;

                            winner = game.CheckWinner();

                            if (winner != null)
                            {
                                await DisplayAlert("Võit!", $"{winner} võitis!", "OK");
                                game.ResetGame();
                                CreateGrid();
                            }
                            else if (game.IsDraw())
                            {
                                await DisplayAlert("Viik", "Keegi ei võitnud!", "OK");
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

    void OnRandomStartClicked(object sender, EventArgs e)
    {
        Random rnd = new Random();
        game.CurrentPlayer = rnd.Next(2) == 0 ? "X" : "O";
    }
    void OnPlayWithAIClicked(object sender, EventArgs e)
    {
        vsAI = true;
        DisplayAlert("Režiim", "Mängid boti vastu!", "OK");
    }
    void OnTwoPlayerClicked(object sender, EventArgs e)
    {
        vsAI = false;
        DisplayAlert("Režiim", "2 mängijat", "OK");
    }
}