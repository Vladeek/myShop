   M S B A M L   `   `   `  ����A  =MyShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:CourseProject.ViewCourseProject.View  5   	   +    %CourseProject.View.RegistrationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   ,local clr-namespace:CourseProject.View  5   	   -   5          � Title$  RegistrationWindow��5	   	   $	��600��6$   $	��720��61    � 
ResizeMode$ NoResize=�6=    � WindowStyle$
 None=�6x    � WindowStartupLocation$ CenterScreen=�6�   ���#0E53A7
�������.��5
      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $	��70* �6   �� 5      $	��90* �6   �� 5      $	��90* �6   �� 5      $	��90* �6   �� 5      $	��90* �6   �� 5      $	��90* �6   �� 5      $
��150* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��60 �6#   �� 5      .+�5      �� -   5        $��0��5         NavigationButtonStyle#���   6%   .��5      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ KeyboardReturn=�6+   $��25��6B   $��25��6N   5      �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��1��6N   .+�5      �� -   5        #���   5      .��5         $ WindowMinimize=�6.   $��Center=�6D   $��25��6a   $��25��6m   5!      �� 5"      -   5          CloseButtonStyle#���  5"      .��5#        $ Close=�6.   $��Center=�6;   $��25��6X   $��25��6d   5$      5%      5&      � 5(   
   $��2��6   .+�5)      �� -   5         ��Name$ firstNameTextBox��5)      	 �� 	MaxLength$	 50��6K   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Имя��6[      
Foreground
 �����.  (MaterialDesignThemes.Wpf.TextFieldAssist   UnderlineBrush
 �����  	TextBoxes#��[ 6�   $��Bottom=�6  $	��500��6!  
�������$��100,0,100,0q�6l  ��60   �� *	FirstName+6l  5*      � 5+   
   $��3��6   .+�5,      �� -   5        $ secondNameTextBox��5,      $	 50��6M   $
 Фамилия��6\   
 �����
 �����#��[ 6�   $��Bottom=�6  $	��500��6'  
�������$��2��6t  $
��50,0q�6�  ��61   �� *
SecondName+6�  5-      � 5.   
   $��4��6   .+�5/      �� -   5        $ mailTextBox��5/      $	 50��6A   $

 Mail��6P   
 �����
 �����#��[ 6�   $��Bottom=�6�   $	��500��6  
���������6+   �� *Mail+68  50      � 51   
   $��5��6   .+�52      G� -   5         G�Name$ pass1NameTextBox��52      $
 Пароль��64    G� 	MaxLength$ 6��6\   
 �����
 �����  PasswordBoxes#��[ 6�   $��Bottom=�6�   $	��500��6  
�������60  53      � 54   
   $��6��6   .+�55      G� -	   5        $ pass2NameTextBox��55      $%
 Повторите пароль��64   $ 6��6f   
 �����
 �����#��[ 6�   $��Bottom=�6�   $	��500��6  
�������6;  56      � 57   
   $��7��6   .+�58      �� -
   5         ��Name$ registrationButton��58      $��Регистрация��61   $	��Top=�6G     AuthButtonStyle#���  6`   $��0,25,0,0q�6�   {�.  6�   �� 59      -   5         ��Name$ 	infoLabel��59      $��Center=�6@   $��Bottom=�6]   $��16(�6x   $��0,0,0,22q�6�   $��DemiBold"�6�   ��6'   �� *Info+6�   5:      5;      5<      