using RetroGame.Engine.DataTypes;

namespace RetroGame.Blocks.BlockTypes
{
    public class Jump
    {
        public static bool Main(Game game, Block currentBlock)
        {
            game.Person.IsFalling = false;
            game.Person.Jump = (true, game.Person.Jump.Height, game.Person.Jump.ActualHeight);

            return true;
        }
    }
}