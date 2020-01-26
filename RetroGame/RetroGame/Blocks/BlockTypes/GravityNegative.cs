using RetroGame.Engine.DataTypes;

namespace RetroGame.Blocks.BlockTypes
{
    public class GravityNegative
    {
        public static bool Main(Game game, Block currentBlock)
        {
            game.Gravity = false;

            return true;
        }
    }
}