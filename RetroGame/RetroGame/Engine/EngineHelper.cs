using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using RetroGame.Engine.DataTypes;
using RetroGame.Engine.Utilities;
using RetroGame.Utilities;
using RetroGame.Views;

namespace RetroGame.Engine
{
    public class EngineHelper
    {
        private static readonly DispatcherTimer Timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(1)};

        public static void LoadGame(Game game, MainWindow mainWindow)
        {
            IndexHelper.SetIndex("LoadingScreen");

            var gameView = new GameView();

            Build(game, gameView.ScrollView, gameView.GameCanvas);

            gameView.GameCanvas.Children.Add(game.Person.Control);
            game.Person = game.Person;

            IndexHelper.SetIndex(gameView);

            Timer.Tick += delegate(object s, EventArgs e) { TimerEvent.OnTick(s, e, game); };
            mainWindow.KeyDown += delegate(object s, KeyEventArgs e) { KeyEvents.OnKeyDown(s, e, game); };
            mainWindow.KeyUp += delegate(object s, KeyEventArgs e) { KeyEvents.OnKeyUp(s, e, game); };

            Timer.Start();
        }

        // ----------------- //
        // ----| To-Do |---- //
        // ----------------- //

        #region To-Do

        public static void UnloadGame(Game game, MainWindow mainWindow)
        {
            var gameView = mainWindow.Index.Content as GameView;

            Timer.Stop();

            mainWindow.KeyDown -= delegate(object s, KeyEventArgs e) { KeyEvents.OnKeyDown(s, e, game); };
            mainWindow.KeyUp -= delegate(object s, KeyEventArgs e) { KeyEvents.OnKeyUp(s, e, game); };
            Timer.Tick -= delegate(object s, EventArgs e) { TimerEvent.OnTick(s, e, game); };

            Break(game, gameView.ScrollView, gameView.GameCanvas);
        }

        #endregion

        public static void Build(Game game, ScrollViewer scrollView, Canvas canvas)
        {
            if (game == null || canvas == null || scrollView == null) return;

            canvas.Width = double.NaN;
            canvas.Height = double.NaN;

            var width = game.VisibleArea.BlockSize.Width * game.Size.Width;
            var height = game.VisibleArea.BlockSize.Height * game.Size.Height;

            canvas.Width = width;
            canvas.Height = height;

            Blocks_PropertyChanged(game, canvas);

            // ----------------- //
            // ----| To-Do |---- //
            // ----------------- //

            game.PropertyChanged += delegate(object s, PropertyChangedEventArgs e)
            {
                Game_PropertyChanged(s, e, scrollView, canvas);
            };

            canvas.Focus();

            game.Blocks = game.Blocks;
        }

        public static void Break(Game game, ScrollViewer scrollView, Canvas canvas)
        {
            if (game == null || canvas == null || scrollView == null) return;

            game.Person.PropertyChanged -= delegate(object s, PropertyChangedEventArgs e)
            {
                Person_PropertyChanged(s, e, game, scrollView);
            };
            game.PropertyChanged -= delegate(object s, PropertyChangedEventArgs e)
            {
                Game_PropertyChanged(s, e, scrollView, canvas);
            };

            canvas.Children.Clear();

            canvas.ClearValue(Panel.BackgroundProperty);

            canvas.Width = double.NaN;
            canvas.Height = double.NaN;
        }

        private static void Game_PropertyChanged(object sender, PropertyChangedEventArgs args, ScrollViewer scrollView,
            Canvas canvas)
        {
            if (!(sender is Game game)) return;

            switch (args.PropertyName)
            {
                case "Size":
                    break;
                case "VisibleArea":
                    Person_PropertyChanged(sender, args, game, scrollView);
                    Blocks_PropertyChanged(game, canvas);
                    break;
                case "Person":
                    game.Person.PropertyChanged += delegate(object s, PropertyChangedEventArgs e)
                    {
                        Person_PropertyChanged(s, e, game, scrollView);
                    };
                    break;
                case "Blocks":
                    Blocks_PropertyChanged(game, canvas);
                    break;
            }
        }

        private static void Person_PropertyChanged(object sender, PropertyChangedEventArgs e, Game game,
            ScrollViewer scrollView)
        {
            for (var i = 1; i <= game.VisibleArea.BlockSize.Width; i++)
                Canvas.SetLeft(game.Person.Control, game.Person.Position.Point.X * i);

            for (var i = 1; i <= game.VisibleArea.BlockSize.Height; i++)
                Canvas.SetTop(game.Person.Control, game.Person.Position.Point.Y * i);

            game.Person.Control.Width = game.VisibleArea.BlockSize.Height * game.Person.Position.Size.Width;
            game.Person.Control.Height = game.VisibleArea.BlockSize.Width * game.Person.Position.Size.Height;

            VisibleArea.ScrollToPlayer(game, scrollView);
        }

        private static void Blocks_PropertyChanged(Game game, Canvas canvas)
        {
            foreach (var block in game.Blocks)
            {
                Canvas.SetLeft(block.Control, game.VisibleArea.BlockSize.Width * block.Position.Point.X);
                Canvas.SetTop(block.Control, game.VisibleArea.BlockSize.Height * block.Position.Point.Y);

                block.Control.Width = game.VisibleArea.BlockSize.Width * block.Position.Size.Width;
                block.Control.Height = game.VisibleArea.BlockSize.Height * block.Position.Size.Height;

                if (!canvas.Children.Contains(block.Control))
                    canvas.Children.Add(block.Control);
            }
        }
    }
}