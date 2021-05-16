using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MementoApp
{
    public partial class MainWindow : Window
    {

        private string state;
        private MementoHelper mementoHelper = new();
        private Stack<DateTime> time = new();

        public MainWindow()
        {
            InitializeComponent();
            state = txbWords.Text;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveMemento();
        }

        public Memento SaveMemento()
        {
            state = txbWords.Text;
            return new Memento(state);
        }

        public void GetState(Memento memento)
        {
            state = memento.State;
            txbWords.Text = state;
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            Memento m = mementoHelper.GetMemento();
            GetState(m);
            lblStatus.Content = $"Status : Reverted content to {time.Pop()}";
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            Memento m = mementoHelper.PullQueue();
            GetState(m);
        }

        private void txbWords_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Space || e.Key == Key.OemPeriod)
            {
                mementoHelper.Add(SaveMemento());
                time.Push(DateTime.Now);
                lblStatus.Content = $"Status : Last Saved at {time.Peek()}";
            }
        }
    }
}
