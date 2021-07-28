using DictionaryKit.Models;
using DictionaryKit.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

            textTones.Text = Models.Condition.Tones;

            comboType.ItemsSource = Enum.GetValues(typeof(DataFetcher.DataType_Localization)).Cast<DataFetcher.DataType>();
            comboType.SelectedItem = (DataFetcher.DataType_Localization)DataFetcher.DataType.Word;

            buttonAdd.Click += (sender, e) =>
            {
                var conditionDialog = new ConditionDialog()
                {
                    Owner = this,
                };

                if (conditionDialog.ShowDialog() ?? false)
                {
                    listConditions.Items.Add(conditionDialog.Result);
                }
            };

            buttonRemove.Click += (sender, e) =>
            {
                if (listConditions.SelectedItems?.Count > 0)
                {
                    while (listConditions.SelectedIndex != -1)
                    {
                        listConditions.Items.RemoveAt(listConditions.SelectedIndex);
                    }
                }
            };

            buttonClear.Click += (sender, e) =>
            {
                listConditions.Items.Clear();
            };

            buttonSearch.Click += (sender, e) =>
            {
                var queryableConditions = listConditions.Items.Cast<Models.Condition>();

                var requireds = queryableConditions
                    .Where(c => c.Type == Models.Condition.ConditionType.Required)
                    .Select(c => c.Content)
                    .ToList();

                var optionals = queryableConditions
                    .Where(c => c.Type == Models.Condition.ConditionType.Optional)
                    .Select(c => c.Content)
                    .ToList();

                var contentPool = new List<IChineseObject>();

                switch ((DataFetcher.DataType)comboType.SelectedItem)
                {
                    case DataFetcher.DataType.Ci:
                        contentPool.AddRange(DataFetcher.GetCis());
                        break;
                    case DataFetcher.DataType.Idiom:
                        contentPool.AddRange(DataFetcher.GetIdioms());
                        break;
                    case DataFetcher.DataType.Word:
                        contentPool.AddRange(DataFetcher.GetWords());
                        break;
                    case DataFetcher.DataType.Xiehouyu:
                        contentPool.AddRange(DataFetcher.GetXiehouyus());
                        break;
                    default:
                        break;
                }

                var result = contentPool
                    .Where(ch =>
                    {
                        foreach (var condition in requireds)
                        {
                            if (!ch.GetSearchContent(radioStrict.IsChecked ?? false).Contains(condition))
                                return false;
                        }
                        bool flag = optionals.Count == 0;

                        foreach (var condition in optionals)
                        {
                            if (ch.GetSearchContent(radioStrict.IsChecked ?? false).Contains(condition))
                            {
                                flag = true;
                                break;
                            }
                        }

                        return flag;
                    });

                textResult.Text = string.Join("\n====================================\n\n", result);
            };

            buttonExport.Click += (sender, e) =>
            {
                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    DefaultExt = "exe",
                    FileName = "Dictionary Export",
                    Filter = "Text file (*.txt)|*.txt",
                };

                if (saveDialog.ShowDialog() ?? false)
                {
                    File.WriteAllText(saveDialog.FileName, textResult.Text);
                }
            };
        }
    }
}
