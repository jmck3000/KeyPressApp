using Autofac;
using KeyPressApp.Engine;
using KeyPressApp.Managers;
using KeyPressApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace KeyPressApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClosable
    {

        private readonly KeyPressViewModel _viewModel;
        private IManager  _manager;
        private IKeyPress _keyPress;
        private ILogger _logger;

        public MainWindow()
        {
            InitializeComponent();

            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                _manager = scope.Resolve<IManager>();
                _keyPress = scope.Resolve<IKeyPress>();
                _logger = scope.Resolve<ILogger>();
            }
     
            _viewModel = new KeyPressViewModel(_manager, _keyPress, _logger);       
            DataContext = _viewModel;
        }



        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
