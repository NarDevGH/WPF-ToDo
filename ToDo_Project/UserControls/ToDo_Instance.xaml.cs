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

namespace ToDo_Project.Controls
{
    /// <summary>
    /// Interaction logic for ToDo_Instance.xaml
    /// </summary>
    public partial class ToDo_Instance : UserControl
    {
        public ToDo_Instance()
        {
            InitializeComponent();
        }

        private void Delete_Task(object sender, RoutedEventArgs e) 
        {
            StackPanel sp = (StackPanel)this.Parent;
            sp.Children.Remove(this);
        }
    }
}
