   M S B A M L   `   `   `  ����D  @PaPyPaint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PaPyPaint	PaPyPaint  5   	   M IFluent, Version=9.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent 6/       PaPyPaint.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:PaPyPaint     5   	   7Fluent$clr-namespace:Fluent;assembly=Fluent     6/   X TXceed.Wpf.Toolkit, Version=4.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      -   5          � Title$  	PaPyPaint��5	   	   $	��450��6   $	��800��6(   .��5
      �  � RowDefinitions 5   
   �� 5      $	��125 �6   �� 5      $��* �6   .+�5   
     Fluent.Ribbon     Menu 5        Fluent.Backstage  5        Fluent.RibbonControl   Header$ 	Introduce��6#      Content. 5         Fluent.BackstageTabControl  .@�5        Fluent.BackstageTabItem     Header$ Information��62   .��5      �� .+�5   "   �� $��30(�6,   
 �� Top$ 20��6:   $#��Họ tên: Trần Tấn Lộc��6J   6h   �� 5   "   $��30(�6,   $	 100��6:   $��Mssv: 19120564��6K   6c   �� 5   "   $��30(�6,   $	 200��6:   $ ��Môn: Lập trình Windows��6K   6k   5      5      5      5         Tabs. 5        Fluent.RibbonTabItem     Header$
 Home��6#   	   Groups.	 5        Fluent.RibbonGroupBox  $
��File��6(   .@�5         Fluent.Button  -   5        $��45��5    $   
   Icon$
 Images/save.png��6/      Header$
 Save��6F      	LargeIcon 5!      �� 5"      $��Images/save.png��6$    �� BitmapScalingMode$ HighQuality=�6=   6m   5$        5%      -   5        $��45��5%   $   $
 Images/save.png��6/   $
 Load��6F    5&      �� 5'      $��Images/save.png��6$   $ HighQuality=�6=   6m   5)      5*        5,      -   5          Name$ Tools��5,   7   $��Tools��6(   .@�5-        -   5        $
 Images/clear.png��5-   $   $��80��6<   $ 	Clear all��6H   $��6q�6s    5.      �� 5/      $��Images/clear.png��6$   $ HighQuality=�6>   6n   51        52      -   5        $
 Images/undo.jpg��52   $   $
 Undo��6;   $��6q�6I    53      �� 54      $��Images/undo.jpg��6$   $ HighQuality=�6=   6m   56        57      -   5        $
 Images/redo.png��57   $   $
 Redo��6;   $��6q�6I    58      �� 59      $��Images/redo.png��6$   $ HighQuality=�6=   6m   5;      5<        5>      -   5        $ prototypesStackPanel��5>   8   $��Shapes��6(   5D        5E      -	   5        $ prototypesStackPanel2��5E   9   $��Preview��6(   .@�5F      � $��70��6   .+�5G      �� -
   5         ��Name$ PreviewCanvas��5G   !   
�������5I      �� 5J      -   5        
������ 5M      5N      5O        5Q      $��	Thickness��6(   .@�5S      �� -   5         ��Name$ 	thickness��5S      $��50��62   6=   5T        5U      $��Colors��6(   .@�5V      #	  Xceed.Wpf.Toolkit.ColorCanvas	  -   5         	 Name$ colorPicker��5V   '   6=   5W      5X      5Y      ]� 5[   
   $��1��6   ��. .+�5^      � .+�5_      �� -   5        $ canvas��5_      
�������5a      �� 5b      -   5        
������ 5f      5g      5i      5k      5l      