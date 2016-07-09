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
using DnDTreasureGenerator.Program;

namespace DnDTreasureGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Main main;

        public MainWindow()
        {
            InitializeComponent();
            main = new Main();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            generatedItems.Text = main.Run();
        }
    }
}
