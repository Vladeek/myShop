   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:CourseProject_WPF_.ViewCourseProject_WPF_.View  5   	   )    #CourseProject_WPF_.View.OfferWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   7local%clr-namespace:CourseProject_WPF_.View     5   	     � Title$  OfferWindow��5   	   $	��550��6   $	��600��6*   ���#0E53A7
������� � WindowStartupLocation$ CenterScreen=�6^   .��5	      ��  �� Orientation$ Vertical=�6   .+�5
   
   � $��50��6   ��5      ��5      #04346C��6+   .+�5      �� $
��Left=�6   $��20(�63   
�������$$��Форма для заказа��6T   $��Center=�6l   $��20,0,0,0q�6�   5      � 5   
   $��0, 50, 0, 0q�6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6     � ColumnDefinitions 5      �� 5      $
��Auto �6#   $	��113��60   �� 5      .+�5      �� $��16(�6   $��10, 10q�6&   $��Имя: ��66   �� 5       �� 	MaxLength$ 25��6   $��0��6%   $��16(�62   $��1��6@   $��10, 10q�6P   
���������5      �� *Name+ �� UpdateSourceTrigger$ PropertyChanged=�6R   �� 5      $��1��6   $��16(�6%   $��0��63   $��10, 10q�6C   $��Фамилия: ��6S   �� 5       $ 50��6   $��1��6%   $��16(�62   $��1��6@   $��10, 10q�6P   
���������5!      �� *
SecondName+$ PropertyChanged=�6Y   �� 5"      $��2��6   $��16(�6%   $��0��63   $��10, 10q�6C   $��Телефон: ��6S   �� 5#      $ 13��6   $��2��6%   $��16(�62   $��1��6@   $��10, 10q�6P   
���������5$      �� *Phone+$ PropertyChanged=�6S   �� 5%      $��3��6   $��16(�6%   $��0��63   $��10, 10q�6C   $��Email: ��6S   �� 5&      $��3��6   $��16(�6#   $��1��61   $��10, 10q�6A   
���������5'      �� *Email+$ PropertyChanged=�6S   �� 5(      $��4��6   $��16(�6%   $��0��63   $��10, 10q�6C   $��Адрес: ��6S   �� 5)      $��4��6   $��16(�6#   $��1��61   $��10, 10q�6A   
���������5*      �� *	Address+$ PropertyChanged=�6U   5+      �� 5,   
   $��Заказать��6   $��Center=�6$   $��0, 50, 0, 0q�6A      AuthButtonStyle#���   6V   ��6�   �� *OrderCommand+$ PropertyChanged=��� 5-   
   
�������$��Center=�6=   $��Center=�5.      $��18(�63   $��
10,25,10,0q�6A   $	��572��6U    �� Padding$ 10,0,0,0q�6a   ��5-      �� *Info+5.   a   5/      50      