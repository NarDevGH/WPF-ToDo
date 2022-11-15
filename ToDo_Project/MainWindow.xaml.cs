using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Serialization;
using ToDo_Project.Controls;

namespace ToDo_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XmlSerializer xs;
        List<TaskData> ls;
        public MainWindow()
        {
            InitializeComponent();
            ls = new List<TaskData>();
            xs = new XmlSerializer(ls.GetType());
            On_Application_Started();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ToDo_Instance toDo_Instance = new ToDo_Instance();
            ToDo_List.Children.Add(toDo_Instance);
        }

        private void On_Application_Exit(object sender, CancelEventArgs e) 
        {
            FileStream fs = new FileStream("tasks.Xml",FileMode.Create,FileAccess.Write);
            ls.Clear();
            foreach (ToDo_Instance task in ToDo_List.Children) 
            {
                TaskData taskData = new TaskData();
                taskData.completed = task.CheckBox.IsChecked;
                taskData.description = task.TextBox.Text;
                ls.Add(taskData);
            }
            xs.Serialize(fs, ls);
            fs.Close();
        }

        private void On_Application_Started() 
        {
            FileStream fs;
            try
            {
                fs = new FileStream("tasks.Xml", FileMode.Open, FileAccess.Read);
            }
            catch
            {
                return;
            }

            ls = (List<TaskData>)xs.Deserialize(fs);

            foreach (TaskData task in ls) 
            {
                ToDo_Instance toDo_Instance = new ToDo_Instance();
                toDo_Instance.CheckBox.IsChecked = task.completed;
                toDo_Instance.TextBox.Text = task.description;
                ToDo_List.Children.Add(toDo_Instance);
            }
            fs.Close();
        }
    }
}
