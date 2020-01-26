using System.Collections.Generic;
using System.Windows;
using RetroGame.Engine.DataTypes;

namespace RetroGame.Blocks.BlockTypes
{
    public class Wall
    {
        public static bool Main(Game game, Block currentBlock)
        {
            var direction = game.Person.Direction;

            var blockCords = new List<Point>();
            var playerCords = new List<Point>();

            for (var width = 0; width < currentBlock.Position.Size.Width; width++)
            for (var height = 0; height < currentBlock.Position.Size.Height; height++)
                blockCords.Add(new Point(currentBlock.Position.Point.X + width,
                    currentBlock.Position.Point.Y + height));

            for (var width = 0; width < game.Person.Position.Size.Width; width++)
            for (var height = 0; height < game.Person.Position.Size.Height; height++)
                playerCords.Add(new Point(game.Person.Position.Point.X + width, game.Person.Position.Point.Y + height));

            if (game.Gravity)
                foreach (var blockPoint in blockCords)
                foreach (var playerPoint in playerCords)
                {
                    if (playerPoint.X == blockPoint.X && playerPoint.Y + 1 == blockPoint.Y)
                    {
                        game.Person.IsFalling = false;
                        game.Person.LockFalling = true;
                        break;
                    }

                    if (playerPoint.X == blockPoint.X && playerPoint.Y - 1 == blockPoint.Y)
                    {
                        game.Person.IsFalling = true;
                        game.Person.Jump = (false, game.Person.DefaultJumpHeight, 0);
                        break;
                    }
                }

            foreach (var blockPoint in blockCords)
            foreach (var playerPoint in playerCords)
                if (game.Gravity)
                {
                    if (playerPoint.X - 1 == blockPoint.X && playerPoint.Y == blockPoint.Y &&
                        direction == Directions.Left)
                    {
                        if (!game.Person.IsFalling && !game.Person.Jump.IsJumping) return false;

                        game.Person.Direction = null;
                    }

                    if (playerPoint.X + 1 == blockPoint.X && playerPoint.Y == blockPoint.Y &&
                        direction == Directions.Right)
                    {
                        if (!game.Person.IsFalling && !game.Person.Jump.IsJumping) return false;

                        game.Person.Direction = null;
                    }
                }
                else
                {
                    if (playerPoint.X - 1 == blockPoint.X && playerPoint.Y == blockPoint.Y &&
                        direction == Directions.Left ||
                        playerPoint.X + 1 == blockPoint.X && playerPoint.Y == blockPoint.Y &&
                        direction == Directions.Right ||
                        playerPoint.X == blockPoint.X && playerPoint.Y - 1 == blockPoint.Y &&
                        direction == Directions.Up ||
                        playerPoint.X == blockPoint.X && playerPoint.Y + 1 == blockPoint.Y &&
                        direction == Directions.Down)
                        return false;
                }

            return true;
        }
    }
}