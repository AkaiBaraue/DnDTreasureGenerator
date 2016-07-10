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
using DnDTreasureGenerator.Tables;

namespace DnDTreasureGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Main main;
        List<Tuple<string, TableType>> Lookup;

        public MainWindow()
        {
            InitializeComponent();
            this.main = new Main();
            this.Lookup = new List<Tuple<string, TableType>>();

            foreach (var t in TableCollection.TreasureTables)
            {
                var stringToShow = String.Format("{0} CR {1}", t.TableType.Type, t.TableType.Identifier.Replace('_', '-') );
                this.Lookup.Add(new Tuple<String, TableType>(stringToShow, t.TableType));

                this.cbTreasureTables.Items.Add(stringToShow);
            }

            this.cbTreasureTables.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tableToGenerateFor = this.Lookup[cbTreasureTables.SelectedIndex].Item2;
            generatedItems.Text = main.Run(tableToGenerateFor);
        }
    }
}
