   M S B A M L   `   `   `  ����
  MyShop(    "CourseProject_WPF_.View.AuthWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          � Title$  
MainWindow��5
      $��500     ��6   $	��400��5       � 
ResizeMode$ NoResize=�6    � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�6*   ���#0E53A7
�������.��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $	��10* �6   �� 5      $	��10* �6   �� 5      $	��20* �6   �� 5      $	��10* �6   .+�5   
   � -   5         �Name$ GridBarTitle��5      .+�5      �� -   5         ��Name$ buttonClose��5      $��Right=�6*      CloseButtonStyle#��[  6F   $��Bottom=�5   /   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6*   $��25��67   $��25��6C   $��Center=�6N   5      5      � 5   
   $��1��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Bottom=�62   $��50,10,50,10q�6M   .+�5        $ AccountMultiple=�6*   $��25��6B   $��25��6N   $��Center=�6Y   $��	0,10,15,0q�5    *   
�������6=   �� 5!      -   5        	 ��Name$	 mailTextBox��5!      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 
Логин��6F      
Foreground
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����$	��260��6�     	TextBoxes#��[ 5"      
���������5!   /   �� *Login+5#      5$      5%      � 5'   
   $��2��6   .+�5(      �� $ 
Horizontal=�6   $��Bottom=�62   $��50,10,50,10q�6M   .+�5)        $ 
AccountKey=�6*   $��25��6<   $��25��6H   $��Center=�6S   $��	0,10,15,0q�5*   *   
�������6=   G� 5+      -   5         G�Name$ passwordBox��5+   ,    G� 	MaxLength$ 6��6   $	��260��6A   $
 Пароль��6M   
 �����
 �����  PasswordBoxes#��[ 5,      
�������5-      5.      5/      � 51   
   $��3��6    � ColumnDefinitions 52      �� 53      $
��200* �6#   �� 54      $
��200* �6#   .+�56      �� -   5        $��0��56      $��
Войти��6%   $��	0,100,0,0q�65     AuthButtonStyle#���  6a   �� 57      -   5        $��1��57      $��Регистрация��6%   $��	0,100,0,0q�6;   #���  6f   58      � 5:   
   $��5��6   $��2��6   .+�5<      �� 
���  ��$��Center=�6?   $��Center=�5=      $��18(�63   ��5<      �� *Info+5=   3   5>      5?      5A      