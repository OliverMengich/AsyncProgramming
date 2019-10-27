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
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncProgramming
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Task.Factory.StartNew(() => StringLongMethod("Kemei")).ContinueWith(t => ResultantTextBlock.Text = t.Result,TaskScheduler.FromCurrentSynchronizationContext()); 
            //  ResultantTextBlock.Text = StringLongMethod("Oliver ");
            CallBigImportMethod();
 
        }
        private async void CallBigImportMethod()
        {
            var result = await BigLongImportMethodAsync("OLIVER KIPKEMEI");
            ResultantTextBlock.Text= result;
        }
        private Task<string> BigLongImportMethodAsync(string name)
        {
            return Task.Factory.StartNew(() => StringLongMethod(name));
        }

        public string StringLongMethod(string name)
        {
            Thread.Sleep(2000);
            return "Hello " + name;
        }
    }

}
