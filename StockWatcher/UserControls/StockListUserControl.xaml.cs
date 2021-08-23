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
    /// Interaction logic for StockListUserControl.xaml
    /// </summary>
    public partial class StockListUserControl : UserControl
    {
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(MainWindowViewModel), typeof(StockListUserControl), new PropertyMetadata(default(MainWindowViewModel)));

        public MainWindowViewModel ViewModel
        {
            get => (MainWindowViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        public StockListUserControl()
        {
            InitializeComponent();
        }
    }
}
