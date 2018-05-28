using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls;
using SeleniumDemo;
using System.Security;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        ProgressBar pBar;
        ProgressBar pBar2;
        Button startButton;
        string DevProd;
        bool Override = false;
        ToggleSwitch DevProdswitch;
        string headless;
        string[] filterArray;
        string user;
        string pass;
        Grid MyGrid;

        MasterSqlTableObj mst;
        BackgroundWorker myWorker;
        public MainWindow()
        {
            InitializeComponent();

            myWorker = new BackgroundWorker();
            myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
        
            pBar = myProgressBar;
            startButton = StartButton;
            pBar.IsIndeterminate = false;
            pBar2 = myProgressBar2;
            DevProdswitch = DevProdSwitch;
            MyGrid = mygrid2;
        }


        /// <summary>
        /// Script to change UI elements (hide button, show load bars, etc) and begin tests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pBar.IsIndeterminate = true;
            pBar2.IsIndeterminate = true;
            startButton.Visibility = Visibility.Hidden;
            TitleBlock.Text = "Running task...";
            TitleBlock2.Text = null;

            TextBlock col1 = new TextBlock();
            col1.Text = "App Name";
            col1.SetValue(Grid.RowProperty, 0);
            col1.SetValue(Grid.ColumnProperty, 0);
            MyGrid.Children.Add(col1);

            TextBlock col2 = new TextBlock();
            col2.Text = "Kpi Name";
            col2.SetValue(Grid.RowProperty, 0);
            col2.SetValue(Grid.ColumnProperty, 1);
            MyGrid.Children.Add(col2);

            TextBlock col3 = new TextBlock();
            col3.Text = "Result";
            col3.SetValue(Grid.RowProperty, 0);
            col3.SetValue(Grid.ColumnProperty, 2);
            col3.HorizontalAlignment = HorizontalAlignment.Center;
            MyGrid.Children.Add(col3);

            DevProd = DevProdswitch.IsChecked == true ? "Prod" : "Dev";
            Override = (bool)OverrideSwitch.IsChecked;
            headless = HeadlessSwitch.IsChecked == true ? "headless" : "browser";

            //default password and user, this should Ideally be removed
            if (UsernameBox.Text == "" && PasswordBox.Password == "")
            {
                user = "dwatson";
                pass = "1silverfireNEW!";
            }
            else
            {
                user = UsernameBox.Text;
                pass = PasswordBox.Password;
            }
            
            if (FilterBox.Text != "" || FilterBox.Text != "'132,233,243'")
            {
                filterArray = FilterBox.Text.Split(',');
                if (filterArray.Count() == 0)
                {
                    filterArray = new string[1] { FilterBox.Text };
                }
            }
            else
            {
                filterArray = null;
            }
            TabControl.SelectedItem = Tab2;

            List<int> filterListints = null;
            if (filterArray != null)
            {
                List<string> filterliststring = new List<string>(filterArray);
                //catch formatting errors in the filter list. The filter list should ideally be turned into a drop down checkbox list, if possible.
                try
                {
                    filterListints = filterliststring.Select(s => Convert.ToInt32(s)).ToList();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error: filters not formatted correctly, proceeding as though no filters were set (Have you made sure you have formatted the filters with numbers and commas only? No spaces) ");
                }
            }
            mst = new MasterSqlTableObj(DevProd, Override, filterListints);
            List<KPIpage> kpis = mst.KPIpages;
            populateResultGrid(kpis);
            myWorker.RunWorkerAsync();         
        }
        /// <summary>
        /// Method to populate the result page with imagesubscriber objects and app names along with their kpis.
        /// </summary>
        /// <param name="KPages"></param>
        public void populateResultGrid(List<KPIpage> KPages)
        {
            TextBlock TextA;
            TextBlock TextB;
            Image MyImage;
            RowDefinition RowDef;
            int numrows = 0;
            GridLength gl = new GridLength(60);
            GridLength ge = new GridLength(20);
            foreach (KPIpage KP in KPages)
            {
                List<QueryObject> QOs = KP.getKPIs();
                for (int i = 0; i < KP.getKPIs().Count; i++)
                {
                    QueryObject QO = QOs[i];
                    RowDef = new RowDefinition();
                    RowDef.Height = gl;
                    MyGrid.RowDefinitions.Add(RowDef);

                    TextB = new TextBlock();
                    TextB.SetValue(Grid.ColumnProperty, 1);
                    TextB.SetValue(Grid.RowProperty, numrows + 1);
                    TextB.VerticalAlignment = VerticalAlignment.Center;
                    TextB.Margin = new Thickness(0, 10, 10, 10);
                    TextB.Text = QO.GetName();

                    MyImage = new ImageSubscriber(QO);
                    Uri uri = new Uri(@"Resources/unsure2.png", UriKind.Relative);
                    MyImage.Source = new BitmapImage(uri);
                    MyImage.SetValue(Grid.ColumnProperty, 2);
                    MyImage.SetValue(Grid.RowProperty, numrows + 1);
                    MyImage.Margin = new Thickness(0, 2, 0, 2);

                    MyGrid.Children.Add(TextB);
                    MyGrid.Children.Add(MyImage);
                    numrows++;
                }

                TextA = new TextBlock();
                TextA.Text = KP.getAppName();
                TextA.SetValue(Grid.ColumnProperty, 0);
                TextA.FontSize = 13;
                TextA.VerticalAlignment = VerticalAlignment.Center;
                Grid.SetRowSpan(TextA, KP.getKPIs().Count);
                TextA.SetValue(Grid.RowProperty, numrows + 1 - KP.getKPIs().Count);
                TextA.Margin = new Thickness(0, 10, 10, 10);
                MyGrid.Children.Add(TextA);

                RowDef = new RowDefinition();
                RowDef.Height = ge;
                MyGrid.RowDefinitions.Add(RowDef);
                TextBlock emptytext = new TextBlock();
                emptytext.HorizontalAlignment = HorizontalAlignment.Center;
                emptytext.SetValue(Grid.ColumnSpanProperty, 3);
                emptytext.SetValue(Grid.RowProperty, numrows + 1);

                Border b = new Border();
                b.BorderBrush = Brushes.BlanchedAlmond;
                b.Margin = new Thickness(0, 8, 0, 0);
                b.SetValue(Grid.ColumnSpanProperty, 3);
                b.SetValue(Grid.RowProperty, numrows + 1);
                b.BorderThickness = new Thickness(0, 3, 0, 0);

                MyGrid.Children.Add(b);
                MyGrid.Children.Add(emptytext);
                numrows++;

            }
            RowDef = new RowDefinition();
            RowDef.Height = new GridLength(1, GridUnitType.Star);

            //Add row definition to Grid
            MyGrid.RowDefinitions.Add(RowDef);
            pBar2.Margin = new Thickness(0, 5, 0, 10);
            myProgressBar2.SetValue(Grid.RowProperty, numrows + 1);
        }

        /// <summary>
        /// Our background worker will use this method to run the main methods of our test, as well as display our consol window without blocking the UI thread of the wpf form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {          
            ConsoleManager.Show();
           
            seleniumHandler.doTests(user, pass, Override, DevProd, headless, mst);
        }

        void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // The background process is complete. We need to inspect
            // our response to see if an error occurred, a cancel was
            // requested or if we completed successfully.  
            if (e.Cancelled)
            {
                Console.WriteLine("Task Cancelled.");
            }

            // Check to see if an error occurred in the background process.

            else if (e.Error != null)
            {
                Console.WriteLine("Error while performing background operation. " + e.Result);
            }
            else
            {
                // Everything completed normally.
                Console.WriteLine("Task Completed...");
            }

            //Change the status of the buttons on the UI accordingly
            resetUI();

        }
        public void resetUI() {
            pBar.IsIndeterminate = false;
            pBar2.IsIndeterminate = false;
            startButton.Visibility = Visibility.Visible;
            TitleBlock.Text = "Set options for Qlik KPI tester";
        }
        /// <summary>
        /// Console Manager code taken from https://stackoverflow.com/questions/160587/no-output-to-console-from-a-wpf-application/41732584 
        /// </summary>
        [SuppressUnmanagedCodeSecurity]
        public static class ConsoleManager
        {
            private const string Kernel32_DllName = "kernel32.dll";

            [DllImport(Kernel32_DllName)]
            private static extern bool AllocConsole();

            [DllImport(Kernel32_DllName)]
            private static extern bool FreeConsole();

            [DllImport(Kernel32_DllName)]
            private static extern IntPtr GetConsoleWindow();

            [DllImport(Kernel32_DllName)]
            private static extern int GetConsoleOutputCP();

            public static bool HasConsole
            {
                get { return GetConsoleWindow() != IntPtr.Zero; }
            }

            /// <summary>
            /// Creates a new console instance if the process is not attached to a console already.
            /// </summary>
            public static void Show()
            {
                //#if DEBUG
                if (!HasConsole)
                {
                    AllocConsole();
                    InvalidateOutAndError();
                }
                //#endif
            }

            /// <summary>
            /// If the process has a console attached to it, it will be detached and no longer visible. Writing to the System.Console is still possible, but no output will be shown.
            /// </summary>
            public static void Hide()
            {
                //#if DEBUG
                if (HasConsole)
                {
                    SetOutAndErrorNull();
                    FreeConsole();
                }
                //#endif
            }

            public static void Toggle()
            {
                if (HasConsole)
                {
                    Hide();
                }
                else
                {
                    Show();
                }
            }

            static void InvalidateOutAndError()
            {
                Type type = typeof(System.Console);

                System.Reflection.FieldInfo _out = type.GetField("_out",
                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

                System.Reflection.FieldInfo _error = type.GetField("_error",
                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

                System.Reflection.MethodInfo _InitializeStdOutError = type.GetMethod("InitializeStdOutError",
                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);

                Debug.Assert(_out != null);
                Debug.Assert(_error != null);

                Debug.Assert(_InitializeStdOutError != null);

                _out.SetValue(null, null);
                _error.SetValue(null, null);

                _InitializeStdOutError.Invoke(null, new object[] { true });
            }

            static void SetOutAndErrorNull()
            {
                Console.SetOut(TextWriter.Null);
                Console.SetError(TextWriter.Null);
            }
        }

       
    }
}
