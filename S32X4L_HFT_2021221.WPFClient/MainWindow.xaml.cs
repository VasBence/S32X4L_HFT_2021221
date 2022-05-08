
using S32X4L_HFT_2021221.WPFClient.Windows;
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

namespace S32X4L_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void TanuloClick(object sender, RoutedEventArgs e)
        {
            Menu.Content = new StudentWindow();
        }
        public void TanarClick(object sender, RoutedEventArgs e)
        {
            Menu.Content = new TeacherWindow();
        }

        public void TantargyClick(object sender, RoutedEventArgs e)
        {
            Menu.Content = new SubjectWindow();
        }
    }
}
