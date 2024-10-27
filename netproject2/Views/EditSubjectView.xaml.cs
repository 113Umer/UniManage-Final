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

namespace netproject2.Views
{
    /// <summary>
    /// Interaction logic for EditSubjectView.xaml
    /// </summary>
    public partial class EditSubjectView : Window
    {
        public EditSubjectView()
        {
            InitializeComponent();
        }
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;  // Closes the window and indicates success
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;  // Closes the window without saving
        }
    }
}
