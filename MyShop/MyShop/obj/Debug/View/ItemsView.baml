   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CourseProject.ViewCourseProject.View  5      A%clr-namespace:CourseProject.ViewModelCourseProject.ViewModel  5      (    "CourseProject.View.AllAnnouncement   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:CourseProject.View     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      5	viewmodel%clr-namespace:CourseProject.ViewModel  5        N� Title$  AllAnnouncement��5      $��Stretch=�6   $��Stretch=�6=    N� 
Background �#0E53A7 N� 
Foreground
 �����.��5      �  � ColumnDefinitions 5   
   �� 5      $	��300 �6   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $��1* �6   6*   .+�5   
   �� 
�������$��0,0,1,0q�6%   $��2��6?   ._�5      � $��0��6   .+�5      ��  �� Orientation$ Vertical=�6   $��0,70,0,0q�64   .+�5      �� $��50��6    $��20,40,0,-10q�6,   $(��"Поиск по критериям��6A   $��20(�6[   
�������6i   �� 5       �� 	MaxLength$	 100��6:   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Поиск��6J   $��20,30,20,20q�6q   $��16(�5      $��40��6,   
�������
���������5      �� *
SearchText+5      �� 5      $ Категория��5        �� 
IsEditable .  &  "MaterialDesignFloatingHintComboBox#��[  5!      $��16(�6[   $��20q�6i   
�������
���������5      �� *
Categories+	 �� Text	 6B   �� *
Category+5"   2   �� 5#      $ 
Horizontal=�6!   $��	0,20,0,20q�6:   .+�5$      �� $��Цена��6    $��
20,20,20,0q�6/   $��16(�6C   
�������6Q   �� 5%      $��85��6;   $��10,0,0,0q�6F   $ Мин��5&   "   
 �� 
CaretBrush
 �	#FF104774
�������
���������5%   "   �� *	MinCost+5'   "   �� 5(      $��85��6;   $��10,0,0,0q�6F   $ Макс��5)   "   
 �	#FF104774
�������
���������5(   "   �� *	MaxCost+5*   "   5+      �� 5,      -   5         ��Name$ searchButton��5,      $	��120��63   $��40��6?   ���#04346C$��	0,50,20,0q�6`   $��Right=�5-      $��
Поиск��69   ���#04346C
�������5.   3   5/      50      51      � 54   
   $��1��6   .+�55      � $��0��6   ���#04346C.+�56      �� -   5        $
 down��56      $��60��6'   $��0q�6H   $��30��6\   $��Right=�57      $	��Top=�61   $y�Hidden=�6I   $��	0,25,50,0q�6]   ��56   2   Z� .��59      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ 
ExpandMore=�6.   
�������$��Center=�6S   5:      �� 5;      -   5        $ up��5;      $��60��6%   $��0q�6F   $��30��6Z   $��Right=�5<      $	��Top=�61   $��	0,25,50,0q�6I   ��5;   0   Z� .��5=        $ 
ExpandLess=�6.   
�������$��Center=�6S   5>      �� 5?      $��Все товары��6   
�������$��24(�6@   $��	0,15,20,0q�6N   $	��Top=�6a   $��Center=�6y   �� 5@      
�������$��16(�6D   $��0,20,140, 0q�6R   $	��Top=�6g   $��Right=�6   ��6   �� *Info+6   5A      �� 5C      -   5        $��16(�5C      $��0,70,0,0q�6$   $��Stretch=�66    � Cursor$
 Hand��5E      ��5D      �� *Announcements+ �� SelectedItem 6<   �� *SelectedItem+��5F      �� 5G      .R�5H      ]� $��0,5,0,5q�6$   
�������.+�5I      �� $ 
Horizontal=�6)   .+�5J   "   �� $��80��6G   $��80��6R   $��UniformToFill=�6^   $��20,10,20,10q�5K   (   ��5J   (   �� *BitmapImage+5L   #   �� 5M   "   $ Vertical=�6-   $��	20,10,0,0q�6D   .+�5N   &   �� $��18(�6F   $��SemiBold"�6T   $��	0,5,60,20q�6j   ��60   �� *Name+6j   �� 5P   &   $��15(�6J   $��	0,5,60,20q�6X   ��60   �� *
Category+6X   �� 5Q   &   $��15(�6c   $��	0,5,60,20q�6r   ��60   �� *	Quntity+ �� StringFormat$ Кол-во: {0}��6r   5R   #   5S      �� 5T      $ 
Horizontal=�6)   $��Right=�6B   $��Center=�6^   $��0,0,30,0q�5U   )   .+�5V   "   �� $��0,0,0,1q�6,   $��16(�6S   $
��Bold"�6a   $��Right=�5W   ,   ��5V   =   �� *Cost+5W   ,   �� 5X   "   $��руб.��6,   $��5,0,0,0q�68   $��16(�6I   $��SemiBold"�6W   $��Right=�5Y   ,   5Z      �� 5[      $��Добавить��6%   $	��150��6�   $��50��6�   $��Right=�6�   $��Center=�6�   
����������#04346C$��0,0,40,0q�6)  {�68   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ ListBoxL� �� Path$ DataContext.IsNotAdmin���5\   %   ��  �� $ FindAncestor=�$ ListBoxL�$6 0DataContext.(viewmodel:ItemsViewModel.AddInCart)���5]   %   �� 5^      5_      5a      5c      5d      5e      