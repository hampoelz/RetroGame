using System;
using System.Threading.Tasks;
using System.Windows;
using RetroGame.Engine.DataTypes;

namespace RetroGame.Engine.Utilities
{
    public class TimerEvent
    {
        public static async void OnTick(object sender, EventArgs e, Game game)
        {
            if (!game.IsRunning) return;

            var interval = 10 / game.Person.Speed;

            var direction = game.Person.Direction;

            var point = game.Person.Position.Point;
            var size = game.Person.Position.Size;

            //GameView.PosX.Text = position.x.ToString();
            //GameView.PosY.Text = position.y.ToString();

            game.Person.LockFalling = false;

            if (!Intersection.ExecuteBlockCode(game)) return;

            if (game.Gravity)
            {
                if (!game.Person.IsFalling && !game.Person.Jump.IsJumping && point.Y != game.Size.Height - size.Height)
                    game.Person.IsFalling = true;

                if (point.X == 0 && direction == Directions.Left ||
                    point.X == game.Size.Width - size.Width && direction == Directions.Right)
                {
                    game.Person.Direction = null;
                    return;
                }

                if (game.Person.IsFalling && !game.Person.LockFalling)
                {
                    await Gravity.Fall(game);
                }
                else if (game.Person.Jump.IsJumping)
                {
                    await Gravity.Jump(game);
                }
                else if (direction == Directions.Left)
                {
                    await Task.Delay(TimeSpan.FromTicks((long) (interval * 10000)));

                    game.Person.Position = (new Point(point.X - 1, point.Y), size);
                }
                else if (direction == Directions.Right)
                {
                    await Task.Delay(TimeSpan.FromTicks((long) (interval * 10000)));

                    game.Person.Position = (new Point(point.X + 1, point.Y), size);
                }
            }
            else
            {
                if (point.X == 0 && direction == Directions.Left ||
                    point.X == game.Size.Width - size.Width && direction == Directions.Right ||
                    point.Y == 0 && direction == Directions.Up ||
                    point.Y == game.Size.Height - size.Height && direction == Directions.Down)
                    return;

                await Task.Delay(TimeSpan.FromTicks((long) (interval * 10000)));

                switch (direction)
                {
                    case Directions.Down:
                        game.Person.Position = (new Point(point.X, point.Y + 1), size);
                        break;

                    case Directions.Up:
                        game.Person.Position = (new Point(point.X, point.Y - 1), size);
                        break;

                    case Directions.Right:
                        game.Person.Position = (new Point(point.X + 1, point.Y), size);
                        break;

                    case Directions.Left:
                        game.Person.Position = (new Point(point.X - 1, point.Y), size);
                        break;
                }
            }
        }
    }
}