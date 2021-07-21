using DictionaryKit.Services;
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

namespace DictionaryKit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            comboType.ItemsSource = Enum.GetValues(typeof(DataFetcher.DataType_Localization)).Cast<DataFetcher.DataType>();
            comboType.SelectedItem = (DataFetcher.DataType_Localization)DataFetcher.DataType.Word;

            buttonSearch.Click += (sender, e) =>
            {
                switch ((DataFetcher.DataType)comboType.SelectedItem)
                {
                    case DataFetcher.DataType.Ci:
                        break;
                    case DataFetcher.DataType.Idiom:
                        break;
                    case DataFetcher.DataType.Word:
                        break;
                    case DataFetcher.DataType.Xiehouyu:
                        break;
                    default:
                        break;
                }
            };
        }
    }
}
