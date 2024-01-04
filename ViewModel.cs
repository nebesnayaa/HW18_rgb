using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HW18_arbg_editor
{
    internal class ViewModel : DependencyObject
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static readonly DependencyProperty AlphaProrerty =
            DependencyProperty.Register("Alpha", typeof(int), typeof(ViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        private static readonly DependencyProperty RedProrerty =
            DependencyProperty.Register("Red", typeof(int), typeof(ViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        private static readonly DependencyProperty GreenProrerty =
            DependencyProperty.Register("Green", typeof(int), typeof(ViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        private static readonly DependencyProperty BlueProrerty =
            DependencyProperty.Register("Blue", typeof(int), typeof(ViewModel),
                new PropertyMetadata(0, OnPropertyChanged));

        public int Alpha
        {
            get { return (int)GetValue(AlphaProrerty); }
            set { SetValue(AlphaProrerty, value); }
        }

        public int Red
        {
            get { return (int)GetValue(RedProrerty); }
            set { SetValue(RedProrerty, value); }
        }

        public int Green
        {
            get { return (int)GetValue(GreenProrerty); }
            set { SetValue(GreenProrerty, value); }
        }

        public int Blue
        {
            get { return (int)GetValue(BlueProrerty); }
            set { SetValue(BlueProrerty, value); }
        }

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public ObservableCollection<Color> ColorItems { get; set; }
            = new ObservableCollection<Color>();

        Commands addCommand;

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new Commands(AddColor, CanAddColor);
                }

                return addCommand;
            }
        }

        private void AddColor(object obj)
        {
            ColorItems.Add(Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue));
        }

        private bool CanAddColor(object obj)
        {
            return true;
        }
    }

    internal class Model
    {

    }
}
