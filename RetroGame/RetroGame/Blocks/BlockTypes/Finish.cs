using System.Threading.Tasks;
using System.Windows;
using RetroGame.Engine;
using RetroGame.Engine.DataTypes;

namespace RetroGame.Blocks.BlockTypes
{
    public class Finish
    {
        public static bool Main(Game game, Block currentBlock)
        {
            game.IsRunning = false;

            Task.Delay(1000);

            EngineHelper.UnloadGame(game, Application.Current.MainWindow as MainWindow);

            return true;
        }
    }
}