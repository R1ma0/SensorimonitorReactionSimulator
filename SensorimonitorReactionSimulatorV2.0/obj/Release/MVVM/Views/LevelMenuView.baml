   M S B A M L   `   `   `  ���� Z  VSensorimonitorReactionSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null{Bclr-namespace:SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels4SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels  C    =SensorimonitorReactionSimulatorV2._0.MVVM.Views.LevelMenuView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Y
viewmodelsBclr-namespace:SensorimonitorReactionSimulatorV2._0.MVVM.ViewModels       � DataContext  M  GSensorimonitorReactionSimulatorV2._0.MVVM.ViewModels.LevelMenuViewModel  .����  
  c10_o1#��[  $��20 15 20 15q����� *TrainingLevelList+���� .R���  
 c14_o1#��[ $��1q�$��0 5 0 0q�._�� $��10q� � ColumnDefinitions �� $
��1000 ��� $	��180 � � RowDefinitions �� �� .+��� $��0��$��0��$
��Bold"� 
 c13_o1#��[ $��24(�$��Center=�$��0 0 0 10q����� *Title+�� $��1��$��2��#��[  
 c12_o1#��[ $��Запустить��$��50��$	��150��
������ $��0q�$��18(�$��Center=�$��Center=�����  �� RelativeSource ��  �� AncestorType" �� �� Path$* $DataContext.LoadSelectedLevelCommand����� *	LevelID+�� $��0��$��1��$
��Wrap=�#��[ $��18(�$
��Left=����� *Description+