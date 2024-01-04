using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HW18_arbg_editor
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow view = new MainWindow();
            ViewModel viewModel = new ViewModel();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
