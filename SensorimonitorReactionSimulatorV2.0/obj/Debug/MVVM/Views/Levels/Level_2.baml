   M S B A M L   `   `   `  ����Z  VSensorimonitorReactionSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Iclr-namespace:SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels;SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels  5      D    >SensorimonitorReactionSimulatorV2._0.MVVM.Views.Levels.Level_2   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      `
viewModelsIclr-namespace:SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels     5        � DataContext  5      R  LSensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels.Level_2ViewModel  5   
    � 	Resources 5         BoolToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �  
 c10_o1#��[ 6   .+�5   
   � ��6   �� *ChangeBlurEffectStyle+ � RowDefinitions 5      �� 5      $	��100 �6    �� 5      .+�5      � $��0��6    � ColumnDefinitions 5      �� 5      �� 5      .+�5       (�  (� StretchDirection$
 Both=�6   $
��Left=�5!      $��0��5"      .��5$      �� $��0��6!    �� Orientation$ 
Horizontal=�5%   !   $
��Left=�5&   !   .+�5)      ��   LevelNavigationButtonStyle#��[ 6!   $��25, 25, 12.5, 25q�5*   !   $��50��5+   !   $��50��5,   !   ��5-   !   �� *GoToMainMenuCommand+.��5/      �� $��/Images/menu_icon.png��6$   50      52      53      54      �� 57      $��1��6   .+�59      ��   AnimatedTargetButtonStyle#��[ 6   y�5:      �� *TargetVisibility+ �� 	Converter# [  ��5;      �� *TargetClickCommand+
 �� Top 5<      �� *CanvasTopIndent+ �� Left 5=      �� *CanvasLeftIndent+z�5>      �� 5?      5A      5B      �� 5D      $��2��5E        StartTaskButtonStyle#��[ 5F      y�5D      �� *StartButtonVisibility+# [  ��5G      �� *	StartTask+5H      5I      �� 5L   
   y�6   �� *StatisticsWindowVisibility+# [  .��5M      �  
 c14_o1#��[ 6   $	��800��5N      $	��600��5O       5Q      �� 5R      $	��150 �6$   �� 5S      �� 5T      $	��110 �6$   .+�5W      �� $��Результаты��6    
 c12_o1#��[ 5X      $��0 70 0 0q�5Y      $��44(�5Z      $��Center=�5[      $��Center=�5\      �� 5^      $��1��6   
������ $��0q�5a      
������ ��5`      �� *StatisticsParams+��5d      �� 5e      	 �� 
TargetType"	 ��6    .�5f      �� 
 �� Property
 � {� �� Value .  6:   �� 5g      
 � |� .  6:   �� 5h      
 � �� .  6:   5i      ��5l      �� 5m      .R�5n      �  5p   "   �� 5q   &   $	��573 �67   �� 5r   &   $	��200 �67   .+�5u   "   ��    StatModalParametersTextStyle#��[ 5v   ,   $
��Left=�5w   ,   $��30 0 0 0q�5x   ,   $��0��5y   ,   ��5u   ,   �� *ParameterTitle+5y   ,   �� 5z   "   #��[ 5{   ,   $��Right=�5|   ,   $��0 0 27 0q�5}   ,   $��1��5~   ,   ��5z   ,   �� *ParameterValue+5~   ,   5      5�      5�      �� 5�      $��2��6   $��
Выход��5�      $��0 0 30 0q�5�      $	��150��5�      $��50��5�      #��[ 5�       
 c13_o1#��[ 5�      $��22(�5�      $��Right=�5�      ��5�      �� *GoToMainMenuCommand+5�      5�      5�      5�      