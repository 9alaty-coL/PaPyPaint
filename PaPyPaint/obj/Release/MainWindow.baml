   M S B A M L   `   `   `  ���� D  @PaPyPaint, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PaPyPaint	PaPyPaint  M IFluent, Version=9.0.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent     PaPyPaint.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:PaPyPaint     7Fluent$clr-namespace:Fluent;assembly=Fluent     X TXceed.Wpf.Toolkit, Version=4.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  -     � Title$  	PaPyPaint��$	��700��$
��1100��.���  � RowDefinitions �� $	��125 ��� $��* �.+�  Fluent.Ribbon     Menu   Fluent.Backstage    Fluent.RibbonControl   Header$ 	Introduce��   Content.    Fluent.BackstageTabControl  .@�  Fluent.BackstageTabItem     Header$ Information��.���� .+��� $��30(�
 �� Top$ 20��$#��Họ tên: Trần Tấn Lộc���� $��30(�$	 100��$��Mssv: 19120564���� $��30(�$	 200��$ ��Môn: Lập trình Windows��   Tabs.   Fluent.RibbonTabItem     Header$
 Home��	   Groups.	   Fluent.RibbonGroupBox  $
��File��.@�  Fluent.Button  -   $��45��
   Icon$
 Images/save.png��   Header$
 Save��   	LargeIcon �� $��Images/save.png�� �� BitmapScalingMode$ HighQuality=�  -   $��45��$
 Images/save.png��$
 Load�� �� $��Images/save.png��$ HighQuality=�  -     Name$ Tools��$��Tools��.@�  -   $
 Images/clear.png��$��80��$ 	Clear all��$��6q� �� $��Images/clear.png��$ HighQuality=�  -   $
 Images/undo.jpg��$
 Undo��$��6q� �� $��Images/undo.jpg��$ HighQuality=�  -   $
 Images/redo.png��$
 Redo��$��6q� �� $��Images/redo.png��$ HighQuality=�  -   $ prototypesStackPanel��$��Shapes��  -	   $ prototypesStackPanel2��$��Preview��.@�� $��70��.+��� -
    ��Name$ PreviewCanvas��
��������� -   
������   $��	Thickness��.@��� -    ��Name$ 	thickness��$��50��  $��Colors��.@�#	  Xceed.Wpf.Toolkit.ColorCanvas	  -    	 Name$ colorPicker��]� $��1����. .+�� .+��� -   $ canvas��
��������� -   
������ 