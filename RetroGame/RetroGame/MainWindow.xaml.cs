using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using RetroGame.Blocks.BlockTypes;
using RetroGame.Engine;
using RetroGame.Engine.DataTypes;

namespace RetroGame
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var blocks = new List<Block>();

            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(0, 50), new Size(60, 2)), CompiledCode = typeof(Wall),
                Control = {Background = Brushes.OrangeRed}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(100, 50), new Size(15, 1)), CompiledCode = typeof(Wall),
                Control = {Background = Brushes.Orange}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(135, 60), new Size(10, 1)), CompiledCode = typeof(Wall),
                Control = {Background = Brushes.DarkOrange}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(150, 70), new Size(10, 1)), CompiledCode = typeof(Wall),
                Control = {Background = Brushes.Orange}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(170, 80), new Size(10, 1)), CompiledCode = typeof(Wall),
                Control = {Background = Brushes.DarkOrange}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(180, 70), new Size(10, 1)), CompiledCode = typeof(Jump),
                Control = {Background = Brushes.Green}
            });

            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(300, 85), new Size(2, 2)),
                CompiledCode = typeof(GravityNegative),
                Control = {Background = Brushes.BlueViolet}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(300, 50), new Size(2, 2)),
                CompiledCode = typeof(GravityPositive),
                Control = {Background = Brushes.GreenYellow}
            });

            var gradientBrushHorizontal1 =
                new LinearGradientBrush {StartPoint = new Point(0, 0.5), EndPoint = new Point(1, 0.5)};
            gradientBrushHorizontal1.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            gradientBrushHorizontal1.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));
            gradientBrushHorizontal1.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));
            gradientBrushHorizontal1.GradientStops.Add(
                new GradientStop(Colors.Green, 1.0));

            var gradientBrushHorizontal2 =
                new LinearGradientBrush {StartPoint = new Point(0, 0.5), EndPoint = new Point(1, 0.5)};
            gradientBrushHorizontal2.GradientStops.Add(
                new GradientStop(Colors.Green, 0.0));
            gradientBrushHorizontal2.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.25));
            gradientBrushHorizontal2.GradientStops.Add(
                new GradientStop(Colors.Red, 0.75));
            gradientBrushHorizontal2.GradientStops.Add(
                new GradientStop(Colors.Yellow, 1.0));

            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(0, 0), new Size(400, 2)), CompiledCode = typeof(Wall),
                Control = {Background = gradientBrushHorizontal1}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(0, 98), new Size(400, 2)), CompiledCode = typeof(Jump),
                Control = {Background = gradientBrushHorizontal2}
            });

            var gradientBrushVertical1 =
                new LinearGradientBrush {StartPoint = new Point(0.5, 0), EndPoint = new Point(0.5, 1)};
            gradientBrushVertical1.GradientStops.Add(
                new GradientStop(Colors.Yellow, 0.0));
            gradientBrushVertical1.GradientStops.Add(
                new GradientStop(Colors.Red, 0.25));
            gradientBrushVertical1.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.75));
            gradientBrushVertical1.GradientStops.Add(
                new GradientStop(Colors.Green, 1.0));

            var gradientBrushVertical2 =
                new LinearGradientBrush {StartPoint = new Point(0.5, 0), EndPoint = new Point(0.5, 1)};
            gradientBrushVertical2.GradientStops.Add(
                new GradientStop(Colors.Green, 0.0));
            gradientBrushVertical2.GradientStops.Add(
                new GradientStop(Colors.Blue, 0.25));
            gradientBrushVertical2.GradientStops.Add(
                new GradientStop(Colors.Red, 0.75));
            gradientBrushVertical2.GradientStops.Add(
                new GradientStop(Colors.Yellow, 1.0));

            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(0, 0), new Size(2, 100)), CompiledCode = typeof(Wall),
                Control = {Background = gradientBrushVertical1}
            });
            blocks.Add(new Block
            {
                Id = blocks.Count + 1, Position = (new Point(398, 0), new Size(2, 100)), CompiledCode = typeof(Wall),
                Control = {Background = gradientBrushVertical2}
            });


            blocks.Add(new Block
            {
                Id = blocks.Count + 1,
                Position = (new Point(390, 50), new Size(2, 2)),
                CompiledCode = typeof(Finish),
                Control = {Background = Brushes.CornflowerBlue}
            });

            var level = new Game
            {
                Gravity = true,
                Size = new Size(400, 100),
                Blocks = blocks,
                VisibleArea = (new Size(15, 15), new Point(45, 7)),
                Background = Brushes.Black,
                Person = new Person
                {
                    Position = (new Point(5, 5), new Size(5, 10)),
                    ShowHitBox = true,
                    Speed = 1,
                    AutoMove = false,
                    DefaultJumpHeight = 20
                }
            };

            EngineHelper.LoadGame(level, this);

            ////var levelEditor = new LevelEditor
            ////{
            ////    Level = level
            ////};
            ////levelEditor.LoadLevel();

            ////Index.Navigate(levelEditor);

            //IndexHelper.SetIndex("LevelEditor");
        }
    }
}