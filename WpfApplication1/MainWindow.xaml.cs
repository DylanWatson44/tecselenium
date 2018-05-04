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
using MahApps.Metro.Controls;
using MahApps.Metro.Actions;
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
        Button startButton;
        string DevProd;
        bool Override = false;
        ToggleSwitch DevProdswitch;
        string headless;
        string[] filterArray;
        string user;
        string pass;

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
            DevProdswitch = DevProdSwitch;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pBar.IsIndeterminate = true;
            startButton.Visibility = Visibility.Hidden;
            TitleBlock.Text = "Running task...";
            DevProd = DevProdswitch.IsChecked == true ? "Prod" : "Dev";
            Override = (bool)OverrideSwitch.IsChecked;
            headless = HeadlessSwitch.IsChecked == true ? "headless" : "browser";
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
            
            myWorker.RunWorkerAsync();
            
        }

        void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ConsoleManager.Show();
            seleniumHandler.doTests(user, pass, Override, DevProd, headless, filterArray);
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
                Console.WriteLine("Error while performing background operation.");
            }
            else
            {
                // Everything completed normally.
                Console.WriteLine("Task Completed...");
            }

            //Change the status of the buttons on the UI accordingly
            pBar.IsIndeterminate = false;
            startButton.Visibility = Visibility.Visible;
            TitleBlock.Text = "Set options for Qlik KPI tester";

        }

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
