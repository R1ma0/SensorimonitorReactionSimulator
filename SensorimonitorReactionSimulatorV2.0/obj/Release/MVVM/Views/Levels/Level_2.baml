   M S B A M L   `   `   `  ���� Z  VSensorimonitorReactionSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�Iclr-namespace:SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels;SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels  D    >SensorimonitorReactionSimulatorV2._0.MVVM.Views.Levels.Level_2   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     `
viewModelsIclr-namespace:SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels       � DataContext  R  LSensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.Levels.Level_2ViewModel   � 	Resources    BoolToVisibilityConverter��%   &	        �� .���  
 c10_o1#��[ .+�� ���� *ChangeBlurEffectStyle+ � RowDefinitions �� $	��100 ��� .+�� $��0�� � ColumnDefinitions �� �� .+�(�  (� StretchDirection$
 Both=�$
��Left=�$��0��.���� $��0�� �� Orientation$ 
Horizontal=�$
��Left=�.+���   LevelNavigationButtonStyle#��[ $��25, 25, 12.5, 25q�$��50��$��50������ *GoToMainMenuCommand+.���� $��/Images/menu_icon.png���� $��1��.+���   AnimatedTargetButtonStyle#��[ y��� *TargetVisibility+ �� 	Converter# [  ���� *TargetClickCommand+
 �� Top �� *CanvasTopIndent+ �� Left �� *CanvasLeftIndent+z��� �� $��2��  StartTaskButtonStyle#��[ y��� *StartButtonVisibility+# [  ���� *	StartTask+�� y��� *StatisticsWindowVisibility+# [  .���  
 c14_o1#��[ $	��800��$	��600�� �� $	��150 ��� �� $	��110 �.+��� $��Результаты�� 
 c12_o1#��[ $��0 70 0 0q�$��44(�$��Center=�$��Center=��� $��1��
������ $��0q�
������ ���� *StatisticsParams+���� 	 �� 
TargetType"	 ��.��� 
 �� Property
 � {� �� Value .  �� 
 � |� .  �� 
 � �� .  ���� .R��  �� $	��573 ��� $	��200 �.+���    StatModalParametersTextStyle#��[ $
��Left=�$��30 0 0 0q�$��0������ *ParameterTitle+�� #��[ $��Right=�$��0 0 27 0q�$��1������ *ParameterValue+�� $��2��$��
Выход��$��0 0 30 0q�$	��150��$��50��#��[  
 c13_o1#��[ $��22(�$��Right=����� *GoToMainMenuCommand+