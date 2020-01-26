using System;
using System.Collections.Generic;
using System.Windows;
using RetroGame.Engine.DataTypes;

namespace RetroGame.Engine.Utilities
{
    public static class Intersection
    {
        public static bool Check(Game game)
        {
            if (!game.IsRunning) return false;

            foreach (var block in game.Blocks)
            {
                var playerRect = new Rect
                {
                    Location = game.Person.Control.PointToScreen(new Point(0, 0)),
                    Height = game.Person.Control.ActualHeight,
                    Width = game.Person.Control.ActualWidth
                };

                var blockRect = new Rect
                {
                    Location = block.Control.PointToScreen(new Point(0, 0)),
                    Height = block.Control.ActualHeight,
                    Width = block.Control.ActualWidth
                };

                if (Rect.Intersect(playerRect, blockRect) != Rect.Empty) return true;
            }

            return false;
        }

        public static bool ExecuteBlockCode(Game game)
        {
            if (!game.IsRunning) return false;

            var returns = new List<bool>();

            // ----------------- //
            // ----| To-Do |---- //
            // ----------------- //

            #region To-Do

            try
            {
                for (var i = 0; i < game.Blocks.Count; i++)
                {
                    var playerRect = new Rect
                    {
                        Location = game.Person.Control.PointToScreen(new Point(0, 0)),
                        Height = game.Person.Control.ActualHeight,
                        Width = game.Person.Control.ActualWidth
                    };

                    var blockRect = new Rect
                    {
                        Location = game.Blocks[i].Control.PointToScreen(new Point(0, 0)),
                        Height = game.Blocks[i].Control.ActualHeight,
                        Width = game.Blocks[i].Control.ActualWidth
                    };

                    if (Rect.Intersect(playerRect, blockRect) == Rect.Empty) continue;

                    var blockFunction = game.Blocks[i].CompiledCode.GetMethod("Main");
                    var function = blockFunction?.Invoke(null, new object[] {game, game.Blocks[i]});

                    if (!(function is bool b)) continue;

                    returns.Add(b);
                    if (!b) break;
                }

                if (returns.Contains(false)) return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            #endregion

            return true;
        }
    }
}