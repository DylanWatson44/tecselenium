   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   H DMahApps.Metro, Version=1.6.1.4, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5   	        WpfApplication1.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	     � Title$  TEC KPI Test program��5	   	   $	��487��6&   $	��470��63   .��5+      � -   5        $��mygrid��5+       � ColumnDefinitions 5-   
   �� 5.      $	��58* �6   �� 5/      $
��319* �6   �� 50      $	��85* �6    � RowDefinitions 53   
   �� 54      $
��auto �6   $��27��6*   �� 55      $
��auto �6   $��40��6*   �� 56      $
��auto �6   $��39��6*   �� 57      $
��auto �6   $��71��6*   �� 58      $
��auto �6   $��71��6*   �� 59      $
��auto �6   $��71��6*   �� 5:      $
��auto �6   $��71��6*   �� 5;      $
��auto �6   $��49��6*   .+�5=   
   �� -   5        $��
TitleBlock��5=      $��3��6&    �� TextAlignment$ Center=�6:   !Set options for Qlik KPI tester6r   �� 5@   
   -   5        $��UsernameBox��5@      *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton .    	Watermark$  Please enter your username��6S   $��	10,5,10,5q�6�   $��1��6�   $��1��6�   .��6�    ^� ToolTip 5A      _� 5B      $��1��6   $��0��6'   $"��Use your normal TEC username��67   .��5C   &   5D      G� 5F   
   -   5        $��PasswordBox��5F       .  G� PasswordChar$ *��6W   $��2��6h   $��1��6u   $ Password��6�   $��	10,5,10,5q�6�    5G      _� 5H      $��1��6   $��0��6'   $<��6Provide the password associated with your TEC username��67   5J      )  #MahApps.Metro.Controls.ToggleSwitch  5L   
   -   5        $��OverrideSwitch��5L       $��Override dataload?��66      OnLabel$	 Yes��6R   	   OffLabel$	 No��6`   $��3��6n   $��1��6{   $��2��6�   $
��10,5q�6�    5M      _� 5N      $��1��6   $��0��6'   $����This option will force the program to recalculate the values for each KPI if set to 'Yes' 
Use this if you have changed the SQL queries in the master table or the program was terminated before finishing��67   5R        5T   
   -   5        $��HeadlessSwitch��5T       $��Run in headless mode?��66   $	 Yes��6U   $	 No��6c   $��4��6q   $��1��6~   $��2��6�   $��	10,5,10,4q�6�    5U      _� 5V      $��1��6   $��0��6'   $����Running in headless mode will cause the program to run without opening a browser.
Use if visual feedback of the test is not needed��67   5X        5Z   
   -   5        $��DevProdSwitch��5Z       $%��Test development or production?��65   $ 
Production��6^   $	 Development��6s   $��5��6�   $��2��6�   $��1��6�   $
��10,5q�6�    5[      _� 5\      $��1��6   $��0��6'   $^��XDetermines whether the Development URLs and values should be used or the production ones��67   5^      �� 5`   
   $��Apps to filter��6   $��18(�6)   $��6��67   $��1��6D   $	��5,5q�6T    5a      _� 5b      $��1��6   $��0��6'   $i��cBy providing comma separated app ids here, the program will skip processing each of the listed apps��67   5d      �� 5f   
   -   5        $��	FilterBox��5f       . $ '132,233,243'��6Q   $��	10,0,10,5q�6�   $��6��6�   $��1��6�   $��Bottom=�6�   $��26��6�   .��6�    5g      _� 5h      $��1��6   $��0��6'   $i��cBy providing comma separated app ids here, the program will skip processing each of the listed apps��67   .��5i   &   5j      �� 5l   
   -	   5        $��StartButton��5l      $��7��6$   $��1��61   $��
80,10,80,2q�6A      AccentedSquareButtonStyle#��[  6j   .��6�   Start 5m      _� 5n      $��1��6   $��0��6'   $$��Press to initiate test program��67   5p      -  'MahApps.Metro.Controls.MetroProgressBar  5r   
   -
   5        $��myProgressBar��5r   w   
 � IsIndeterminate
 . $��7��6;   $��3��6H   $��Bottom=�6\   $��5,0,10,0q�6�   $��6��6�   $��0��6�    5s      _� 5t      $��1��6   $��0��6'   $��yThis is a progress bar put here solely because it looks nice and lets you know that the program hasn't crashed (probably)��67   5v      5y      5{      