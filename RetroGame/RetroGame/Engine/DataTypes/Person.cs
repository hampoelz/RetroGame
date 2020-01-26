using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RetroGame.Engine.DataTypes
{
    public enum Directions
    {
        Up,
        Down,
        Right,
        Left
    }

    public class Person : INotifyPropertyChanged
    {
        private (bool isEnabled, int HP) _health;
        private (Point Point, Size Size) _position;
        private bool _showHitBox;

        public Border Control { get; protected set; } = new Border();

        public bool IsEnabled { get; set; } = true;

        public bool AutoMove { get; set; }

        public double Speed { get; set; } = 0.001;

        public int DefaultJumpHeight { get; set; } = 10;
        public (bool IsJumping, int Height, int ActualHeight) Jump { get; set; } = (false, 0, 0);
        public bool IsFalling { get; set; }
        public bool LockFalling { get; set; }

        public bool ShowHitBox
        {
            get => _showHitBox;
            set
            {
                if (value == _showHitBox) return;

                if (value)
                {
                    Control.BorderBrush = Brushes.RoyalBlue;
                    Control.BorderThickness = new Thickness(1);
                }
                else
                {
                    Control.ClearValue(Border.BorderBrushProperty);
                    Control.ClearValue(Border.BorderThicknessProperty);
                }

                _showHitBox = value;
            }
        }

        public (bool isEnabled, int HP) Health
        {
            get => _health;
            set
            {
                if (value == _health) return;

                _health = value;
                OnPropertyChanged();
            }
        }

        public Directions? Direction { get; set; }

        public (Point Point, Size Size) Position
        {
            get => _position;
            set
            {
                if (value == _position) return;

                _position = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}