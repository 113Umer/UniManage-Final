   M S B A M L   `   `   `  ����  netproject2+    %netproject2.Views.NewAssignmentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  New Assignment��5   	   $	��720��5   	   $
��1280��5   	   $	��300��5   	   $	��200��5   	    � 
ResizeMode$ 	CanResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5!   
   �� $��Title:��6   $��0��6!   $��10q�6.   $��Center=�6:   $��Right=�6U   �� 5"   
   -   5         ��Name$ TitleTextBox��5"      $��0��5#      $��1��6   $��10q�5$      $��Center=�5%      $	��300��5&      $��30��6!   $��Title��5'      
�������5)      �� 5,   
   $��Description:��6   $��1��6'   $��10q�64   $��Center=�6@   $��Right=�6[   �� 5-   
   -   5        $ DescriptionTextBox��5-      $��1��5.      $��1��6   $��10q�5/      $��Center=�50      $	��300��51      $��30��6!   $��Description��52      
�������54      �� 57   
   $��Assignment Type:��6   $��2��6+   $��10q�68   $��Center=�6D   $��Right=�6_   �� 58   
   -   5        $ AssignmentTypeTextBox��58      $��2��59      $��1��6   $��10q�5:      $��Center=�5;      $	��300��5<      $��30��6!   $��Assignment Type��5=      
�������5?      �� 5B   
   $��	Due Date:��6   $��3��6$   $��10q�61   $��Center=�6=   $��Right=�6X   (  "System.Windows.Controls.DatePicker  5C   
   -   5          Name$ DueDatePicker��5C      $��3��5D      $��1��6"   $��10q�5E      $��Center=�5F      $	��300��5G      �� 5J   
   $��Assignment Value:��6   $��4��6,   $��10q�69   $��Center=�6E   $��Right=�6`   �� 5K   
   -   5        $ AssignmentValueTextBox��5K      $��4��5L      $��1��6   $��10q�5M      $��Center=�5N      $	��300��5O      $��30��6!   $��Assignment Value��5P      
�������5R      �� 5U   
   $��Assignment Result:��6   $��5��6-   $��10q�6:   $��Center=�6F   $��Right=�6a   �� 5V   
   -   5        $ AssignmentResultTextBox��5V      $��5��5W      $��1��6   $��10q�5X      $��Center=�5Y      $	��300��5Z      $��30��6!   $��Assignment Result��5[      
�������5]      �� 5`   
   $��Select Subject:��6   $��6��6*   $��10q�67   $��Center=�6C   $��Right=�6^   �� 5a   
   -   5         ��Name$ SubjectComboBox��5a      $��6��5b      $��1��6    $��10q�5c      $��Center=�5d      $	��300��5e       �� 
IsEditable$ False��5f      �� 5i   
   -   5        	 ��Name$	 SubmitButton��5i      $��Make Changes��5j      $��8��5k      $��2��6   $��10q�5l      $��Center=�5m      $��Center=�5n      $	��150��5o      $��40��6    5p      5q      5r      