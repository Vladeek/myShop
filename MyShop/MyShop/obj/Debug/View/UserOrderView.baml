   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CourseProject.ModelCourseProject.Model  5      K*clr-namespace:CourseProject_WPF_.ViewModelCourseProject_WPF_.ViewModel  5      *    $CourseProject_WPF_.View.UserCartPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3model!clr-namespace:CourseProject.Model     5      8X*clr-namespace:CourseProject_WPF_.ViewModel     5        N� Title$  UserCartPage��5	      $	��680��6   $
��1175��6)    N� 
Foreground
 ����� N� 
Background �#0E53A7.��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��1* �6   .+�5   
   � $��0��6   ��5      ��5      #04346C��6+   .+�5      �� $
��Left=�6   $��20(�63   
�������$��
Заказ��6T   $��Center=�6a   $��20,0,0,0q�6|   5      �� 5   
   -   5        $��16(�5      $��0,0,0,0q�6    $��Stretch=�61   
�������$��1��6i    � Cursor$
 Hand��5   ]   ��6   �� *OrderedItems+ �� SelectedItem 67   �� *SelectedItem+��5      �� 5       �� DataType   CourseProject.Model.Item"  6   .R�5      ]� $��0,5,0,5q�6    .+�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� $��80��6C   $��80��6N   $��UniformToFill=�6Z   $��20,10,20,10q�5   $   ��5   $   �� *BitmapImage+5      �� 5      $ Vertical=�6)   $��
20,10,0,10q�6@   .+�5    "   �� $��18(�6B   $��SemiBold"�6P   $��5q�6f   ��6,   �� *Name+6f   �� 5!   "   $��15(�6F   $��5q�6T   ��6,   �� *
Category+6T   �� 5"   "   -   5        ��5"   *   �� *Count+6o   5#      5$      �� 5%      $ 
Horizontal=�6%   $��Right=�6>   $��Center=�6Z   $��0,0,30,0q�5&   %   .+�5'      �� $��0,0,0,5q�6(   $��16(�6O   $
��Bold"�6]   $��Right=�5(   (   $��Center=�6D   ��5'   9   �� *Cost+5(   D   �� 5)      $��руб.��6(   $��5,0,0,5q�64   $��16(�6E   $��SemiBold"�6S   $��Right=�5*   (   $��Center=�6D   �� 5+      $&�� Убрать из корзины��6%   $��60, 0, 0, 0q�6A   $��50��6V   $��Right=�6b   $��Center=�6~   ���#04346C��6�   ��  �� RelativeSource �� 	 �� Mode$	 FindAncestor=�
 �� AncestorType"
 �� �� Path$> 8DataContext.(X:UserOrderViewModel.DeleteFromCartCommand)���6R  �� 5,      5-      5.      50      �� 51   
   $��1��6   $��Заказать��6   $��Bottom=�61   $	��125��6L   $��Center=�6X   $��0, 0, 0, 25q�52   2      AuthButtonStyle#���   6G   ��6   �� *OrderCommand+6G   �� 53   
   $��Сумма заказа:��6   $��20(�6)   $��Center=�68   $��Bottom=�6U   $��226,0,807,11q�6p   $	��142��6�   6�   �� 54   
   
�������$��80��6<   $��20(�6G   $��Center=�6V   $��Bottom=�6s   $��362,0,733,11q�6�   ��6   �� *Sum+6�   55      56      