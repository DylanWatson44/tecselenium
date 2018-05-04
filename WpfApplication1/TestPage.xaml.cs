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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class TestPage : MetroWindow
    {
        Grid MyGrid;
        ProgressBar pBar;
        public TestPage()
        {
            InitializeComponent();
            MyGrid = mygrid2;
            RowDefinition RowDef;
            StackPanel StackP;
            TextBlock TextA;
            TextBlock TextB;
            TextBlock TextC;
            Image MyImage;

            //Add 10 rows to Grid
            Random rnd = new Random();
            QueryObject QO = new QueryObject(null, null, null, 0);
            for (int i = 0; i < 10; i++)
            {
                //Define new Row to add
                RowDef = new RowDefinition();
                RowDef.Height = new GridLength(60);

                //Add row definition to Grid
                MyGrid.RowDefinitions.Add(RowDef);
                

                //Define the control that will be added to new row
                TextA = new TextBlock();
                TextA.Text = "Row: " + i.ToString() + "Column: A" ;
                TextA.SetValue(Grid.ColumnProperty, 0);
                TextA.SetValue(Grid.RowProperty, i + 1);
                TextA.Margin = new Thickness(10,10,10,10);

                TextB = new TextBlock();
                TextB.Text = "Row: " + i.ToString() + "Column: B";
                TextB.SetValue(Grid.ColumnProperty, 1);
                TextB.SetValue(Grid.RowProperty, i + 1);
                TextB.Margin = new Thickness(10, 10, 10, 10);

                //TextC = new TextBlock();
                //TextC.Text = "Row: " + i.ToString() + "Column: C";
                //TextC.SetValue(Grid.ColumnProperty, 2);
                //TextC.SetValue(Grid.RowProperty, i + 1);
                MyImage = new ImageSubscriber(QO);
                Uri uri;
                
                int someint = rnd.Next(0, 9);
                if(someint> 6){    
                    uri = new Uri(@"Resources/cross.png", UriKind.Relative);
                }
                else if (someint < 3)
                {
                    uri = new Uri(@"Resources/check.png", UriKind.Relative);
                }
                else
                {
                    uri = new Uri(@"Resources/unsure2.png", UriKind.Relative);
                }
                MyImage.Source = new BitmapImage(uri);
                MyImage.SetValue(Grid.ColumnProperty, 2);
                MyImage.SetValue(Grid.RowProperty, i + 1);
                MyImage.Margin = new Thickness(2, 2, 2, 2);
                //create stackpanel and define which row to add the stackpanel to
                //StackP = new StackPanel();
                //StackP.SetValue(Grid.RowProperty, i+1);

                ////add your control to the stackpanel
                //StackP.Children.Add(TextA);
                //StackP.Children.Add(TextB);
                //StackP.Children.Add(TextC);

                //add the stackpanel to the grid
                MyGrid.Children.Add(TextA);
                MyGrid.Children.Add(TextB);
                MyGrid.Children.Add(MyImage);
            }
            QO.setPassed(false);
            RowDefinitionCollection rowdefs = MyGrid.RowDefinitions;
            int numrows = rowdefs.Count;
            RowDef = new RowDefinition();
            RowDef.Height = new GridLength(1, GridUnitType.Star);

            //Add row definition to Grid
            MyGrid.RowDefinitions.Add(RowDef);
            pBar = myProgressBar2;
            pBar.Margin = new Thickness(0, 5, 0, 10);
            myProgressBar2.SetValue(Grid.RowProperty, numrows + 1);
            
        }
    }
}
