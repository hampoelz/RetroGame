using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace RetroGame.Engine.DataTypes
{
    public class Game : INotifyPropertyChanged
    {
        private Brush _background;
        private List<Block> _blocks;
        private Person _person;
        private Size _size;
        private (Size BlockSize, Point Concision) _visibleArea;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region Event Change Fields

        public Brush Background
        {
            get => _background;
            set
            {
                if (value == _background) return;

                _background = value;
                OnPropertyChanged();
            }
        }

        public Size Size
        {
            get => _size;
            set
            {
                if (value == _size) return;

                Blocks = Blocks;

                _size = value;
                OnPropertyChanged();
            }
        }

        public (Size BlockSize, Point Concision) VisibleArea
        {
            get => _visibleArea;
            set
            {
                if (value == _visibleArea) return;

                if (value.BlockSize != _visibleArea.BlockSize) Blocks = Blocks;

                _visibleArea = value;
                OnPropertyChanged();
            }
        }

        public Person Person
        {
            get => _person;
            set
            {
                if (value == null) return;

                _person = value;
                OnPropertyChanged();
            }
        }

        public List<Block> Blocks
        {
            get => _blocks;
            set
            {
                if (value == null) return;

                _blocks = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Auto Change Fields

        public bool Gravity { get; set; }

        public bool IsRunning { get; set; }

        #endregion
    }
}