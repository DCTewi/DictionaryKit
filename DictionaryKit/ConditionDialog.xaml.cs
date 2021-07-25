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
using System.Windows.Shapes;

namespace DictionaryKit
{
    /// <summary>
    /// ConditionDialog.xaml 的交互逻辑
    /// </summary>
    public partial class ConditionDialog : Window
    {
        public Models.Condition Result { get; set; } = new Models.Condition();

        public ConditionDialog()
        {
            InitializeComponent();

            comboType.ItemsSource = Enum.GetValues(typeof(Models.Condition.ConditionType_Localization)).Cast<Models.Condition.ConditionType>();
            comboType.SelectedItem = (Models.Condition.ConditionType_Localization)Models.Condition.ConditionType.Required;


            okButton.Click += (sender, e) =>
            {
                Result.Type = (Models.Condition.ConditionType)comboType.SelectedItem;
                Result.Content = textCondition.Text;

                DialogResult = true;
            };
        }
    }
}
