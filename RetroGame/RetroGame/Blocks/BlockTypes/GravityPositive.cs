using RetroGame.Engine.DataTypes;

namespace RetroGame.Blocks.BlockTypes
{
    public class GravityPositive
    {
        public static bool Main(Game game, Block currentBlock)
        {
            game.Gravity = true;
            game.Person.Direction = null;

            return true;
        }
    }
}