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
using BinaryStudio.Modeling.Petal;
using BinaryStudio.Modeling.Petal.External;

namespace mdl
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {
        private const String RootPath = @"C:\TFS";
        public MainWindow()
            {
            InitializeComponent();
            }

        private void OnLoad(Object sender, RoutedEventArgs e)
            {
            //PetalDocument.ReadFrom(new Uri($@"file://{System.IO.Path.Combine(RootPath,@"mdl\docs\org.eclipse.emf.ecore.source_2.36.0.v20240203-0859.jar\model\Ecore.mdl")}"),null,out var o);
            //PetalModel.ReadFrom(o,out var r);
            var o = REIModel.ReadFrom(System.IO.Path.Combine(RootPath,@"mdl\docs\atl30.mdl"));
            }
        }
    }
