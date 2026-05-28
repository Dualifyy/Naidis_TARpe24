using System;
using System.Collections.Generic;
using System.Text;

namespace Naidis_TARpe24.Models
{
    public class Game
    {
        public PlayerOOp CurrentPlayer { get; private set; }
        public Theme CurrentTheme { get; private set; }
        public double DurationMs { get; private set; }

        public event Action<string>? OnShowSymbol;
        public event Action? OnHideSymbol;
        public event Action? OnGameFinished;

        private bool isRunning;
        private Random rng = new Random();  

        public Game(PlayerOOp player, Theme theme, double durationMs)
        {
            CurrentPlayer = player;
            CurrentTheme = theme;
            DurationMs = durationMs;
        }

        public async void Start()
        {
            isRunning = true;
            var start = DateTime.Now;

            while (isRunning && (DateTime.Now - start).TotalMilliseconds < DurationMs)
            {
                OnShowSymbol?.Invoke(CurrentPlayer.Symbol);

                await Task.Delay(500);
                OnHideSymbol?.Invoke();

                int pause = rng.Next(500, 2000);
                await Task.Delay(pause);
            }

            isRunning = false;
            OnGameFinished?.Invoke();
        }

        public void Stop() => isRunning = false;
    }
}
