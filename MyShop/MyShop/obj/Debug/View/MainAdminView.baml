   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CourseProjectCourseProject  5      #    CourseProject.View.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      *controlsclr-namespace:CourseProject  5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null6mah,http://metro.mahapps.com/winfx/xaml/controls  5        � Title$  
MainWindow��5      $	��720��6   $
��1280��6%    � WindowStartupLocation$ CenterScreen=�62    � WindowStyle$
 None=�6W    � 
ResizeMode$ CanResizeWithGrip=�5       � AllowsTransparency . ���#0E53A7
�������.��5      �  � RowDefinitions 5   
   �� 5      $	��79* �6   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $	��100 �6#   �� 5      .+�5      � $��1��6   /  )MahApps.Metro.Controls.ScrollViewerHelper%   IsHorizontalScrollWheelEnabled . $��2��6`    5      �� 5      $��50 �6$   �� 5      .+�5      �� $��0,0,0,1q�6   
�������._�5      � -   5         �Name$ GridBarTitle��5   (   $��0��6    5!      �� 5"      $	��79* �6/   �� 5#      $
��157* �6/   .+�5%      �� 	 �� Orientation$	 
Horizontal=�6%   $��Right=�6>   $��Bottom=�6Z   $��40��5&   !   $��0,0,10,0q�6-   $��1��6?   .+�5'      �� -   5           NavigationButtonStyle#���   5'   C   .��5(   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]
   Kind$
 WindowMinimize=�6:   $��25��6P   $��25��6\   $��Center=�5)   6   5*      �� 5+      -   5        #���   5+   D   .��5,   "     $
 ArrowExpandAll=�6:   $��25��6P   $��25��6\   $��Center=�5-   6   5.      �� 5/      -   5          CloseButtonStyle#���  5/   ?   .��50   "     $
 Close=�6:   $��25��6G   $��25��6S   $��Center=�6^   51      52      53      54      � 56      $��1��6   .+�57       � -   5          �Name$ MainContent��57        � NavigationUIVisibility$ Hidden=�58      $��Stretch=�6<   $��2��6Z   ��57   1   �� *	Content+ �� Mode$ TwoWay=�58   Z   59      5;      �� 5=      
�������$��0,0,1,0q�6)   $��2��6C   ._�5>      � $��0��6   .+�5?      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TransitionSlider��5?   :   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6T   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *FadeIn+   Duration$ 	0:0:0.100X�.��5@      � -   5        $ 
GridCursor��5@      $��	0,40,90,0q�63   
�������$��5��6Y   $
��Left=�5A      $	��Top=�6:   $	��100��6R   5B      �� 5C      -   5         ��Name$ menuList��5C      $��0,40,0,0q�6Y   $	��100��6k    � Cursor$
 Hand��5D   L    �� SelectedIndex 5C   1   �� *SelectedIndex+.@�5E      �� $	��100��6'   $	��100��64   .��5F      �� $��Center=�6)   .+�5G   "     $
 BookOpenVariant=�6:   $��25,0,0,0q�6Q   $��40��6c   $��40��6o   
�������5H   :   �� 5I   "   $��Каталог��6,   $��Center=�6;   $��20,5,0,0q�6X   $��14(�6j   
�������5J   ,   5K      5L      �� 5M      $	��100��6'   $	��100��64   .��5N      �� $��Center=�6)   .+�5O   "     $
 
AccountBox=�6:   $��25,0,0,0q�6L   $��40��6^   $��40��6j   
�������5P   :   �� 5Q   "   $��Кабинет��6,   $��Center=�6;   $��20,5,0,0q�6X   $��14(�6j   
�������5R   ,   5S      5T      �� 5U      $	��100��6'   $	��100��64   .��5V      �� $��Center=�6)   .+�5W   "     $

 Lock=�6:   $��25,0,0,0q�6F   $��40��6X   $��40��6d   
�������5X   :   �� 5Y   "   $��Управление��6,   $��Center=�6>   $��	10,5,-5,0q�6[   $��14(�5Z   ,   
�������6:   5[      5\      �� 5]      $	��100��6'   $	��100��64   .��5^      �� $��Center=�6)   .+�5_   "     $

 Cart=�6:   $��25,0,0,0q�6F   $��40��6X   $��40��6d   
�������5`   :   �� 5a   "   $��Заказы��6,   $��Center=�6:   $��	15,5,-5,0q�6W   $��14(�5b   ,   
�������6:   5c      5d      5e      �� 5f      -	   5         ��Name$ 	outButton��5f      $	��100��60   $	��100��6<   $��Bottom=�6I   ���#0E53A7.��5h      �� $	��100��6%   $��	-15,0,0,0q�61   .+�5i        $
 ExitRun=�66   $��40��6E   $��60��6Q   
�������$��Center=�5j   6   �� 5k      $��
Выйти��6(   $��Center=�65   $��20,5,0,0q�6R   $��14(�6d   
�������$��60��5l   ;   5m      5n      5o      5p      5q      5s      5t      