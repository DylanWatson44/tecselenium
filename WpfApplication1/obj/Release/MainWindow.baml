   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls      WpfApplication1.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication1     PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro       � Title$  TEC KPI Test program��$	��550��$	��470�� � Icon$ Resources/baskets.ico��.���� -   $��
TabControl��.@��� -   $
��Tab1��$��Setup��$��
19,0,-19,0q�.��� -   $��mygrid�� � ColumnDefinitions �� $	��58* ��� $
��325* ��� $	��79* � � RowDefinitions �� $��0 ��� $��28 ��� $
��auto �$��40���� $
��auto �$��39���� $
��auto �$��71���� $
��auto �$��71���� $
��auto �$��71���� $
��auto �$��71���� $
��auto �$��49��.+��� -   $��
TitleBlock��$��16(�$��3�� �� TextAlignment$ Center=�$��
-10,0,10,0q�$��2��&$Select options for Qlik KPI test run�� -   $��UsernameBox��*  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .    	Watermark$  Please enter your username��$��	10,5,10,5q�$��2��$��1��.�� ^� ToolTip _� $��1��$��0��$"��Use your normal TEC username��.��G� -   $��PasswordBox�� .  G� PasswordChar$ *��$��3��$��1��$ Password��$��	10,5,10,5q� _� $��1��$��0��$<��6Provide the password associated with your TEC username��)  #MahApps.Metro.Controls.ToggleSwitch  -   $��OverrideSwitch��$��Override dataload?��	   OnLabel$		 Yes��
   OffLabel$
 No��$��4��$��1��$��2��$
��10,5q� _� $��1��$��0��$����This option will force the program to recalculate the values for each KPI if set to 'Yes' 
Use this if you have changed the SQL queries in the master table or the program was terminated before finishing��  -   $��HeadlessSwitch��$��Run in headless mode?��$		 Yes��$
 No��$��5��$��1��$��2��$��	10,5,10,4q� _� $��1��$��0��$����Running in headless mode will cause the program to run without opening a browser.
Use if visual feedback of the test is not needed��  -	   $��DevProdSwitch��$%��Test development or production?��$	 
Production��$
 Development��$��6��$��2��$��1��$
��10,5q� _� $��1��$��0��$^��XDetermines whether the Development URLs and values should be used or the production ones���� $��Apps to filter��$��18(�$��7��$��1��$	��5,5q� _� $��1��$��0��$i��cBy providing comma separated app ids here, the program will skip processing each of the listed apps���� -
   $��	FilterBox�� . $ '132,233,243'��$��	10,0,10,5q�$��7��$��1��$��Bottom=�$��26��.�� _� $��1��$��0��$i��cBy providing comma separated app ids here, the program will skip processing each of the listed apps��.���� -   $��StartButton��$��8��$��1��$��81,25,78,-13q�   AccentedSquareButtonStyle#��[  .��Start _� $��1��$��0��$$��Press to initiate test program��-  'MahApps.Metro.Controls.MetroProgressBar  -   $��myProgressBar�� � IsIndeterminate . $��8��$��3��$��Bottom=�$��5,0,10,0q�$��6��$��0�� _� $��1��$��0��$��yThis is a progress bar put here solely because it looks nice and lets you know that the program hasn't crashed (probably)���� -   $
��Tab2��$��Results��$��277,0,-277,0q�.���� $
��Auto��$
��Auto��$
��Auto=�$
��Auto=�.��� -   $��mygrid2��$��3,8,3,0q� �� $
��173* ��� $
��210* ��� $	��79* � �� $
��auto �$��27��.+��� $��0��$��0��$��3��
�������$��0,0,0,2q��� -   $��TitleBlock2��$��3��$
 Left=�42Results will be displayed here upon test start-up.  -   $��myProgressBar2�� .  $��7��$��3��$��Bottom=�$��5,0,10,0q�$��6��$��0�� _� $��1��$��0��$��yThis is a progress bar put here solely because it looks nice and lets you know that the program hasn't crashed (probably)��