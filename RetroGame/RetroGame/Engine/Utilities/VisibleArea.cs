using System.Windows;
using System.Windows.Controls;
using RetroGame.Engine.DataTypes;

namespace RetroGame.Engine.Utilities
{
    public static class VisibleArea
    {
        public static (Directions? X, Directions? Y) IsPlayerVisible(Game game, ScrollViewer scrollView)
        {
            if (!game.IsRunning) return (null, null);

            Directions? directionX = null;
            Directions? directionY = null;

            var concisionX = game.VisibleArea.Concision.X * game.VisibleArea.BlockSize.Width;
            var concisionY = game.VisibleArea.Concision.Y * game.VisibleArea.BlockSize.Height;

            var playerWidth = game.Person.Position.Size.Width * game.VisibleArea.BlockSize.Width;
            var playerHeight = game.Person.Position.Size.Height * game.VisibleArea.BlockSize.Height;

            if (!((Canvas) scrollView.Content).Children.Contains(game.Person.Control)) return (null, null);
            var childTransform = game.Person.Control.TransformToAncestor(scrollView);
            var childRectangle =
                childTransform.TransformBounds(new Rect(new Point(0, 0), game.Person.Control.RenderSize));

            var pointX = new Point(0, 0);
            var pointY = new Point(0, 0);

            if (game.Gravity)
            {
                if (game.Person.Direction == Directions.Left)
                {
                    pointX = new Point(playerWidth + concisionX, 0);
                    directionX = Directions.Left;
                }
                else if (game.Person.Direction == Directions.Right)
                {
                    pointX = new Point(-playerWidth - concisionX, 0);
                    directionX = Directions.Right;
                }

                if (game.Person.IsFalling)
                {
                    pointY = new Point(0, -playerHeight - concisionY);
                    directionY = Directions.Down;
                }
                else if (game.Person.Jump.IsJumping)
                {
                    pointY = new Point(0, playerHeight + concisionY);
                    directionY = Directions.Up;
                }
            }
            else
            {
                if (game.Person.Direction == Directions.Left)
                {
                    pointX = new Point(playerWidth + concisionX, 0);
                    directionX = Directions.Left;
                }
                else if (game.Person.Direction == Directions.Right)
                {
                    pointX = new Point(-playerWidth - concisionX, 0);
                    directionX = Directions.Right;
                }

                if (game.Person.Direction == Directions.Down)
                {
                    pointY = new Point(0, -playerHeight - concisionY);
                    directionY = Directions.Down;
                }
                else if (game.Person.Direction == Directions.Up)
                {
                    pointY = new Point(0, playerHeight + concisionY);
                    directionY = Directions.Up;
                }
            }

            var ownerRectangleX = new Rect(pointX, scrollView.RenderSize);
            var ownerRectangleY = new Rect(pointY, scrollView.RenderSize);

            if (ownerRectangleX.IntersectsWith(childRectangle)) directionX = null;
            if (ownerRectangleY.IntersectsWith(childRectangle)) directionY = null;

            return (directionX, directionY);
        }

        public static void ScrollToPlayer(Game game, ScrollViewer scrollView)
        {
            if (!game.IsRunning) return;

            var (x, y) = IsPlayerVisible(game, scrollView);

            if (x == Directions.Right)
                scrollView.ScrollToHorizontalOffset(scrollView.HorizontalOffset + game.VisibleArea.BlockSize.Width);
            else if (x == Directions.Left)
                scrollView.ScrollToHorizontalOffset(scrollView.HorizontalOffset - game.VisibleArea.BlockSize.Width);

            if (y == Directions.Down)
                scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset + game.VisibleArea.BlockSize.Height);
            else if (y == Directions.Up)
                scrollView.ScrollToVerticalOffset(scrollView.VerticalOffset - game.VisibleArea.BlockSize.Height);
        }
    }
}