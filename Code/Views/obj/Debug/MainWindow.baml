   M S B A M L   `   `   `  ����@  <Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ViewsViews  5   	       Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Views     5   	     � Title$  Skema planlægning��5   	   $	��442��6#   $	��522��60    � 	Resources 5	         hcs �� 
TargetType �� Property �� Value��%Y   &	        �� 5
   
   " ��6   .�5      ��  � ��$
 Left=�6;   6J   5      5      .��5      � .+�5   
   �� .@�5      �� $��Lærer��6   .��5      �  � ColumnDefinitions 5      �� 5      $��* �6+   �� 5      $
��60px �6+   .+�5      &   System.Windows.Controls.DataGrid     
IsReadOnly . ��61   �� *Tsvm.Person.Persons+ �� SelectedItem 6]   �� *Tsvm.SelectedPerson+�� 5      $��1��6!   .+�5      �� $
��25px��6!   $	��Top=�6/   $��Ny lære��6G   ��6Y   �� *Tsvm.AddTeacherCommand+�� 5      $
��25px��6!   $	��Top=�6/   $��Redigér��6G   ��6Y   �� *Tsvm.EditTeacherCommand+5      5      5       �� 5!      $��Elever��6   .��5"      �  5#      �� 5$      $��* �6+   �� 5%      $
��60px �6+   5-      5.      �� 5/      $��Skema��6   51      �� 52      $	��Fag��6   .��53      �  54      �� 55      $��* �6+   �� 56      $
��60px �6+   .+�59         . ��61   �� *Ssvm.Ssvd.Subjects+ 6\   �� *Ssvm.SelectedSubject+�� 5;      $��1��6!   .+�5>      �� $
��25px��6!   $	��Top=�6/   $��Autotilføj��6G   ��6\   �� *Ssvm.AutoAddCommand2+5?      5A      5B      5C      5D      5E      