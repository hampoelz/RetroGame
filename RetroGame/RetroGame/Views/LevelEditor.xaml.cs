using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RetroGame.Views
{
    public partial class LevelEditor
    {
        private readonly Border _mouseSelection = new Border();
        //private Point? _lastCenterPositionOnTarget;
        //private Point? _lastDragPoint;
        //private Point? _lastMousePositionOnTarget;

        //public Game Level = new Game();

        public LevelEditor()
        {
            InitializeComponent();

            DefineZoomEvents();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //var regex = new Regex("^[^0-9 ]+$");
            //e.Handled = regex.IsMatch(e.Text);
        }

        public void LoadLevel()
        {
            //if (Level == null) return;

            //ZoomTools.Visibility = Level.VisibleArea.Enabled ? Visibility.Visible : Visibility.Collapsed;
            //MapWidth.Text = Level.Size.Width.ToString();
            //MapHeight.Text = Level.Size.Height.ToString();
            //MapAutoScale.IsChecked = !Level.VisibleArea.Enabled;

            //if (Level.VisibleArea.Enabled)
            //{
            //    BlockWidth.Text = Level.VisibleArea.BlockWidth.ToString();
            //    BlockHeight.Text = Level.VisibleArea.BlockHeight.ToString();
            //    ConcisionX.Text = Level.VisibleArea.ConcisionX.ToString();
            //    ConcisionY.Text = Level.VisibleArea.ConcisionY.ToString();
            //}


            //#region Size

            //Canvas.Width = double.NaN;
            //Canvas.Height = double.NaN;

            //if (Level.VisibleArea.Enabled)
            //{
            //    var width = Level.VisibleArea.BlockWidth * Level.Size.Width;
            //    var height = Level.VisibleArea.BlockHeight * Level.Size.Height;

            //    Canvas.Width = width;
            //    Canvas.Height = height;
            //}

            ////for (var x = 0; x != Level.Size.Width; ++x)
            ////{
            ////    var column = new ColumnDefinition();

            ////    Grid.ColumnDefinitions.Add(column);
            ////}

            ////for (var y = 0; y != Level.Size.Height; ++y)
            ////{
            ////    var row = new RowDefinition();

            ////    Grid.RowDefinitions.Add(row);
            ////}


            //for (var x = 0; x != Level.Size.Width; ++x)
            //{
            //    for (var y = 0; y != Level.Size.Height; ++y)
            //    {
            //        var border = new Border
            //        {
            //            Name = "BorderX" + x + "Y" + y,
            //            BorderBrush = Brushes.LightSlateGray,
            //            Background = Brushes.Transparent,
            //            BorderThickness = new Thickness(0.1)
            //        };

            //        Canvas.SetLeft(border, Level.VisibleArea.BlockWidth * x);
            //        Canvas.SetTop(border, Level.VisibleArea.BlockHeight * y);

            //        Canvas.Children.Add(border);
            //    }
            //}
            //#endregion

            //#region Blocks

            //foreach (var block in Level.Blocks) Canvas.Children.Add(block.Control);

            //#endregion

            //ScrollViewer.Focus();
        }

        private void ShowBorder_OnChecked(object sender, RoutedEventArgs e)
        {
            //if (Grid == null) return;

            //foreach (var child in Grid.Children)
            //{
            //    if (child is Border border && border.Name.StartsWith("Border"))
            //    {
            //        border.BorderBrush = Brushes.LightSlateGray;
            //    }
            //}
        }

        private void ShowBorder_OnUnchecked(object sender, RoutedEventArgs e)
        {
            //if (Grid == null) return;

            //foreach (var child in Grid.Children)
            //{
            //    if (child is Border border && border.Name.StartsWith("Border"))
            //    {
            //        border.BorderBrush = Brushes.Transparent;
            //    }
            //}
        }

        private void AddBlock_OnChecked(object sender, RoutedEventArgs e)
        {
            //ScrollViewer.Cursor = Cursors.Cross;
        }

        private void AddBlock_OnUnchecked(object sender, RoutedEventArgs e)
        {
            //ScrollViewer.Cursor = Cursors.Arrow;
        }

        private void Canvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            //var element = (UIElement)e.OriginalSource;

            //if (!(element is Border)) return;

            //Grid.SetColumn(_mouseSelection, Grid.GetColumn(element));
            //Grid.SetRow(_mouseSelection, Grid.GetRow(element));

            //Grid.SetColumnSpan(_mouseSelection, Grid.GetColumnSpan(element));
            //Grid.SetRowSpan(_mouseSelection, Grid.GetRowSpan(element));
        }

        private void Canvas_OnMouseEnter(object sender, MouseEventArgs e)
        {
            //Grid.Children.Add(_mouseSelection);
            //Panel.SetZIndex(_mouseSelection, 10);
        }

        private void Canvas_OnMouseLeave(object sender, MouseEventArgs e)
        {
            //Grid.Children.Remove(_mouseSelection);
        }

        #region Zoom

        public void DefineZoomEvents()
        {
            //ScrollViewer.ScrollChanged += ScrollViewerOnScrollChanged;
            //ScrollViewer.MouseLeftButtonUp += ScrollViewerOnMouseLeftButtonUp;
            //ScrollViewer.PreviewMouseLeftButtonUp += ScrollViewerOnMouseLeftButtonUp;
            //ScrollViewer.PreviewMouseWheel += ScrollViewerOnMouseWheel;

            //ScrollViewer.PreviewMouseLeftButtonDown += ScrollViewerOnMouseLeftButtonDown;
            //ScrollViewer.MouseMove += ScrollViewerOnMouseMove;

            //Zoom.ValueChanged += ZoomOnValueChanged;
        }

        //private bool _ctrl;
        //private bool _shift;

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //if (!Level.VisibleArea.Enabled) return;

            //if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            //{
            //    _ctrl = true;
            //}
            //else if (e.Key == Key.LeftShift)
            //{
            //    _shift = true;
            //}
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            //_ctrl = false;
            //_shift = false;
        }

        private void ZoomOnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if (!Level.VisibleArea.Enabled) return;

            //ScaleTransform.ScaleX = e.NewValue;
            //ScaleTransform.ScaleY = e.NewValue;

            //var centerOfViewport = new Point(ScrollViewer.ViewportWidth / 2, ScrollViewer.ViewportHeight / 2);
            //_lastCenterPositionOnTarget = ScrollViewer.TranslatePoint(centerOfViewport, Grid);
        }

        private void ScrollViewerOnMouseMove(object sender, MouseEventArgs e)
        {
            //if (Drag.IsChecked == null || !Drag.IsChecked.Value || !Level.VisibleArea.Enabled ||
            //    !_lastDragPoint.HasValue) return;

            //var posNow = e.GetPosition(ScrollViewer);

            //var dX = posNow.X - _lastDragPoint.Value.X;
            //var dY = posNow.Y - _lastDragPoint.Value.Y;

            //_lastDragPoint = posNow;

            //ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset - dX);
            //ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - dY);
        }

        private void ScrollViewerOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (Drag.IsChecked == null || !Drag.IsChecked.Value || !Level.VisibleArea.Enabled) return;

            //var mousePos = e.GetPosition(ScrollViewer);
            //if (!(mousePos.X <= ScrollViewer.ViewportWidth) || !(mousePos.Y < ScrollViewer.ViewportHeight)) return;
            //ScrollViewer.Cursor = Cursors.SizeAll;
            //_lastDragPoint = mousePos;
            //Mouse.Capture(ScrollViewer);
        }

        private void ScrollViewerOnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            //if (!Level.VisibleArea.Enabled) return;

            //if (_ctrl)
            //{
            //    _lastMousePositionOnTarget = Mouse.GetPosition(Grid);

            //    if (e.Delta > 0)
            //    {
            //        if (Zoom.Value <= 1)
            //            Zoom.Value += 0.01;
            //        else
            //            Zoom.Value += 1;
            //    }

            //    if (e.Delta < 0)
            //    {
            //        if (Zoom.Value <= 1)
            //            Zoom.Value -= 0.01;
            //        else
            //            Zoom.Value -= 1;
            //    }
            //}
            //else if (_shift && ScrollViewer.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
            //{
            //    ScrollViewer.ScrollToHorizontalOffset(ScrollViewer.HorizontalOffset - e.Delta);
            //}
            //else
            //{
            //    ScrollViewer.ScrollToVerticalOffset(ScrollViewer.VerticalOffset - e.Delta);
            //}

            //e.Handled = true;
        }

        private void ScrollViewerOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //ScrollViewer.Cursor = Cursors.Arrow;
            //ScrollViewer.ReleaseMouseCapture();
            //_lastDragPoint = null;
        }

        private void ScrollViewerOnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            //if (!_ctrl || e.ExtentHeightChange == 0 && e.ExtentWidthChange == 0 || !Level.VisibleArea.Enabled) return;

            //Point? targetBefore = null;
            //Point? targetNow = null;

            //if (!_lastMousePositionOnTarget.HasValue)
            //{
            //    if (_lastCenterPositionOnTarget.HasValue)
            //    {
            //        var centerOfViewport = new Point(ScrollViewer.ViewportWidth / 2, ScrollViewer.ViewportHeight / 2);
            //        var centerOfTargetNow = ScrollViewer.TranslatePoint(centerOfViewport, Grid);

            //        targetBefore = _lastCenterPositionOnTarget;
            //        targetNow = centerOfTargetNow;
            //    }
            //}
            //else
            //{
            //    targetBefore = _lastMousePositionOnTarget;
            //    targetNow = Mouse.GetPosition(Grid);

            //    _lastMousePositionOnTarget = null;
            //}

            //if (!targetBefore.HasValue) return;

            //var dXInTargetPixels = targetNow.Value.X - targetBefore.Value.X;
            //var dYInTargetPixels = targetNow.Value.Y - targetBefore.Value.Y;

            //var multiplicatorX = e.ExtentWidth / Grid.Width;
            //var multiplicatorY = e.ExtentHeight / Grid.Height;

            //var newOffsetX = ScrollViewer.HorizontalOffset - dXInTargetPixels * multiplicatorX;
            //var newOffsetY = ScrollViewer.VerticalOffset - dYInTargetPixels * multiplicatorY;

            //if (double.IsNaN(newOffsetX) || double.IsNaN(newOffsetY)) return;

            //ScrollViewer.ScrollToHorizontalOffset(newOffsetX);
            //ScrollViewer.ScrollToVerticalOffset(newOffsetY);
        }

        #endregion

        #region WorldGeneration PopUp

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            //e.Handled = e.Key == Key.Space;
        }

        private void AutoScale_Checked(object sender, RoutedEventArgs e)
        {
            //if (AutoScaleExpander == null) return;
            //AutoScaleExpander.IsExpanded = false;
        }

        private void AutoScale_Unchecked(object sender, RoutedEventArgs e)
        {
            //if (AutoScaleExpander == null) return;
            //AutoScaleExpander.IsExpanded = true;
        }

        private void MapSize_Click(object sender, RoutedEventArgs e)
        {
            //PopUp.IsOpen = true;
        }

        private void MapSize_Save_Click(object sender, RoutedEventArgs e)
        {
            //if (MapAutoScale.IsChecked == null) MapAutoScale.IsChecked = true;

            //if (string.IsNullOrEmpty(MapWidth.Text) || string.IsNullOrEmpty(MapHeight.Text) ||
            //    !MapAutoScale.IsChecked.Value &&
            //    (string.IsNullOrEmpty(BlockWidth.Text) || string.IsNullOrEmpty(BlockHeight.Text))) return;

            //Level.Size = (int.Parse(MapWidth.Text), int.Parse(MapHeight.Text));

            //Level.VisibleArea = !MapAutoScale.IsChecked.Value
            //    ? (true, int.Parse(BlockWidth.Text), int.Parse(BlockHeight.Text),
            //        string.IsNullOrEmpty(ConcisionX.Text) ? 0 : int.Parse(ConcisionX.Text),
            //        string.IsNullOrEmpty(ConcisionY.Text) ? 0 : int.Parse(ConcisionY.Text))
            //    : (false, 0, 0, 0, 0);

            //var blocks = new List<Block>();
            //blocks.Add(new Block
            //{
            //    Id = blocks.Count + 1, Position = ((170, 80), (10, 1)), CompiledCode = typeof(Wall),
            //    Background = Brushes.DarkOrange
            //});
            //Level.Blocks = blocks;

            //LoadLevel();

            //PopUp.IsOpen = false;
        }

        #endregion
    }
}