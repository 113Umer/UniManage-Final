   M S B A M L   `   `   `  ����F  Bnetproject2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:netproject2.Viewsnetproject2.Views  5   	   '    !netproject2.Views.StudentInfoView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:netproject2.Views     5   	     � Title$  Student Info��5   
   $	��720��5	   	   $
��1280��5
   	   $	��300��5   	   $	��200��5   	    � 
ResizeMode$ 	CanResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ��5   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ FullNameTextBox��5      $��0��5      $��10q�5      $��Center=�5      $��Center=�5      $	��300��5       $��30��6!   $	��200��5!      $��30��6!   $	��200��5"      $��	Full Name��6    �� 
IsReadOnly$
 True��5#      
�������
���   �5$      �� 5'   
   -   5        $ EmailTextBox��5'      $��1��5(      $��10q�5)      $��Center=�5*      $��Center=�5+      $	��300��5,      $��30��6!   $	��200��5-      $��30��6!   $	��200��5.      $��Email Address��6   $
 True��50      
�������
���   �51      �� 54   
   -   5        $ PasswordTextBox��54      $��2��55      $��10q�56      $��Center=�57      $��Center=�58      $	��300��59      $��30��6!   $	��200��5:      $��30��6!   $	��200��5;      $��Password��6   $
 True��5=      
�������
���   �5>      5?      5@      