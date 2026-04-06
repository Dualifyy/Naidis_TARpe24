using Naidis_TARpe24.TTTViews;
public class GameService
{
    public string[,] Board { get; private set; } = new string[3, 3];
    public string CurrentPlayer { get; set; } = "X";
    public bool vsAI { get; set; } = false;

    public void ResetGame()
    {
        Board = new string[3, 3];
        CurrentPlayer = (CurrentPlayer == "X") ? "X" : "O";
    }

    public bool MakeMove(int row, int col)
    {
        if (Board[row, col] != null)
            return false;

        
        Board[row, col] = CurrentPlayer;
        if (vsAI)
        {
            CurrentPlayer = (CurrentPlayer == "X") ? "X" : "O";
        }
        else
        {
            CurrentPlayer = (CurrentPlayer == "X") ? "O" : "X";
        }
        
        
        Console.WriteLine($"(MSG FROM GameService.cs) Current player is: {CurrentPlayer}");
        return true;
    }

    public string CheckWinner()
    {
        // read
        for (int i = 0; i < 3; i++)
        {
            if (Board[i, 0] != null && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
                return Board[i, 0];

            if (Board[0, i] != null && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])
                return Board[0, i];
        }

        // diagonaalid
        if (Board[0, 0] != null && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            return Board[0, 0];

        if (Board[0, 2] != null && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            return Board[0, 2];

        return null;
    }

    public bool IsDraw()
    {
        foreach (var cell in Board)
            if (cell == null)
                return false;

        return CheckWinner() == null;
    }
    public (int row, int col) GetAIMove()
    {
        Random rnd = new Random();

        List<(int, int)> emptyCells = new List<(int, int)>();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (Board[i, j] == null)
                    emptyCells.Add((i, j));
            }
        }

        if (emptyCells.Count == 0)
            return (-1, -1);

        return emptyCells[rnd.Next(emptyCells.Count)];
    }
}