using System.Windows.Input;
using RetroGame.Engine.DataTypes;

namespace RetroGame.Engine.Utilities
{
    public class KeyEvents
    {
        public static void OnKeyUp(object sender, KeyEventArgs e, Game game)
        {
            if (!game.Person.IsEnabled || !game.IsRunning || game.Person.AutoMove) return;

            if (game.Gravity)
            {
                if ((e.Key == Key.D || e.Key == Key.Right) && game.Person.Direction == Directions.Right)
                    game.Person.Direction = null;
                else if ((e.Key == Key.A || e.Key == Key.Left) && game.Person.Direction == Directions.Left)
                    game.Person.Direction = null;
            }
            else
            {
                if ((e.Key == Key.S || e.Key == Key.Down) && game.Person.Direction == Directions.Down)
                    game.Person.Direction = null;
                else if ((e.Key == Key.W || e.Key == Key.Up) && game.Person.Direction == Directions.Up)
                    game.Person.Direction = null;
                else if ((e.Key == Key.D || e.Key == Key.Right) && game.Person.Direction == Directions.Right)
                    game.Person.Direction = null;
                else if ((e.Key == Key.A || e.Key == Key.Left) && game.Person.Direction == Directions.Left)
                    game.Person.Direction = null;
            }
        }

        public static void OnKeyDown(object sender, KeyEventArgs e, Game game)
        {
            if (!game.Person.IsEnabled) return;

            if (!game.IsRunning) game.IsRunning = true;

            if (game.Gravity)
            {
                if ((e.Key == Key.W || e.Key == Key.Up || e.Key == Key.Space) && !game.Person.Jump.IsJumping)
                    game.Person.Jump = (true, game.Person.DefaultJumpHeight, 0);

                if (e.Key == Key.D || e.Key == Key.Right) game.Person.Direction = Directions.Right;
                else if (e.Key == Key.A || e.Key == Key.Left) game.Person.Direction = Directions.Left;
            }
            else
            {
                switch (e.Key)
                {
                    case Key.S:
                    case Key.Down:
                        game.Person.Direction = Directions.Down;
                        break;
                    case Key.W:
                    case Key.Up:
                        game.Person.Direction = Directions.Up;
                        break;
                    case Key.D:
                    case Key.Right:
                        game.Person.Direction = Directions.Right;
                        break;
                    case Key.A:
                    case Key.Left:
                        game.Person.Direction = Directions.Left;
                        break;
                    case Key.Space:
                        game.Person.Direction = null;
                        break;
                }
            }
        }
    }
}