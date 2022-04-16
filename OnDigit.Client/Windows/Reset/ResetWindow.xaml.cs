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
using OnDigit.Client.Windows.Reset.Steps;
using OnDigit.Core.Interfaces.Services;

namespace OnDigit.Client.Windows.Reset
{
    /// <summary>
    /// Interaction logic for RestoreAccess.xaml
    /// </summary>
    public partial class ResetWindow : Window
    {
        public ResetWindow(MainWindow reference, IAuthenticationService authenticationService)
        {
            InitializeComponent();
            ResetFrame.Content = new GetCode(reference, authenticationService);
        }
    }
}
