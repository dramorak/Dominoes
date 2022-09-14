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

namespace Dominoes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Graph g = new Graph(13);
        public MainWindow()
        {

            InitializeComponent();

            PopulateGrid();
        }

        public void PopulateGrid()
        {
            //populate grid with buttons
            for(int c = 1; c < 14; c++)
            {
                for(int r = c; r < 14; r++)
                {
                    CheckBox cb = new CheckBox();
                    InputSpace.Children.Add(cb);

                    //set grid col/row 
                    cb.SetValue(Grid.RowProperty, r);
                    cb.SetValue(Grid.ColumnProperty, c);

                    //set callback
                    cb.Checked += checkEvent;
                    cb.Unchecked += uncheckEvent;

                    // format
                    cb.HorizontalAlignment = HorizontalAlignment.Center;
                    cb.VerticalAlignment = VerticalAlignment.Center;
                }
            }
        }

        public void checkEvent(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            //Get row / col
            int r = (int)box.GetValue(Grid.RowProperty);
            int c = (int)box.GetValue(Grid.ColumnProperty);

            //Add corresponding edge to graph
            g.AddEdge(r, c);

        }
        public void uncheckEvent(object sender, RoutedEventArgs e)
        {
            CheckBox box = sender as CheckBox;
            //Get row / col
            int r = (int)box.GetValue(Grid.RowProperty);
            int c = (int)box.GetValue(Grid.ColumnProperty);

            //Add corresponding edge to graph
            g.DeleteEdge(r, c);

        }
    }
}
