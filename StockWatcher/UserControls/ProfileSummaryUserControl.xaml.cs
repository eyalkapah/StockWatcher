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
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.UserControls
{
    /// <summary>
    /// Interaction logic for ProfileSummaryUserControl.xaml
    /// </summary>
    public partial class ProfileSummaryUserControl : UserControl
    {
        public static readonly DependencyProperty SelectedStockProperty = DependencyProperty.Register(
            "SelectedStock", typeof(StockViewModel), typeof(ProfileSummaryUserControl), new PropertyMetadata(default(StockViewModel)));

        public StockViewModel SelectedStock
        {
            get => (StockViewModel)GetValue(SelectedStockProperty);
            set => SetValue(SelectedStockProperty, value);
        }
        public ProfileSummaryUserControl()
        {
            InitializeComponent();
        }
    }
}
