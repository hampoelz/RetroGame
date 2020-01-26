using System;
using System.Threading.Tasks;
using System.Windows;
using RetroGame.Engine.DataTypes;

namespace RetroGame.Engine.Utilities
{
    public static class Gravity
    {
        public static async Task Fall(Game game)
        {
            if (!game.IsRunning) return;

            var interval = 10 / game.Person.Speed / 20;

            var direction = game.Person.Direction;

            var point = game.Person.Position.Point;
            var size = game.Person.Position.Size;

            if (point.Y == game.Size.Height - size.Height)
            {
                game.Person.IsFalling = false;
            }
            else
            {
                await Task.Delay(TimeSpan.FromTicks((long) (interval * 10000)));

                switch (direction)
                {
                    case Directions.Left:
                        game.Person.Position = (new Point(point.X - 1, point.Y + 1), size);
                        break;

                    case Directions.Right:
                        game.Person.Position = (new Point(point.X + 1, point.Y + 1), size);
                        break;

                    case null:
                        game.Person.Position = (new Point(point.X, point.Y + 1), size);
                        break;
                }
            }
        }

        public static async Task Jump(Game game)
        {
            if (!game.IsRunning) return;

            var interval = 10 / game.Person.Speed / 20;

            var direction = game.Person.Direction;

            var point = game.Person.Position.Point;
            var size = game.Person.Position.Size;

            if (point.Y == 0)
            {
                game.Person.IsFalling = true;
                game.Person.Jump = (false, game.Person.DefaultJumpHeight, 0);
            }
            else if (game.Person.Jump.ActualHeight <= game.Person.Jump.Height)
            {
                await Task.Delay(TimeSpan.FromTicks((long) (interval * 10000)));

                switch (direction)
                {
                    case Directions.Left:
                        game.Person.Position = (new Point(point.X - 1, point.Y - 1), size);
                        break;

                    case Directions.Right:
                        game.Person.Position = (new Point(point.X + 1, point.Y - 1), size);
                        break;

                    case null:
                        game.Person.Position = (new Point(point.X, point.Y - 1), size);
                        break;
                }

                if (!game.Person.Jump.IsJumping) return;

                game.Person.Jump = (true, game.Person.Jump.Height, game.Person.Jump.ActualHeight + 1);
            }
            else
            {
                game.Person.IsFalling = true;
                game.Person.Jump = (false, game.Person.DefaultJumpHeight, 0);
            }
        }
    }
}