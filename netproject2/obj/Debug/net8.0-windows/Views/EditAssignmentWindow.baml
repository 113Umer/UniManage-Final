   M S B A M L   `   `   `  ����F  Bnetproject2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:netproject2.Viewsnetproject2.Views  5   	   ,    &netproject2.Views.EditAssignmentWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:netproject2.Views     5   	   $	��720��5   	   $
��1280��5	   	   $	��300��5
   	   $	��200��5   	     � 
ResizeMode$  	CanResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5$   
   �� $��Title:��6   $��0��6!   $��10q�6.   $��Center=�6:   $��Right=�6U   �� 5%   
   -   5         ��Name$ TitleTextBox��5%      $��0��5&      $��1��6   $��10q�5'      $��Center=�5(      $	��300��5)      $��30��6!   $��Title��5*      
�������5,      �� 5/   
   $��Description:��6   $��1��6'   $��10q�64   $��Center=�6@   $��Right=�6[   �� 50   
   -   5        $ DescriptionTextBox��50      $��1��51      $��1��6   $��10q�52      $��Center=�53      $	��300��54      $��30��6!   $��Description��55      
�������57      �� 5:   
   $��Assignment Type:��6   $��2��6+   $��10q�68   $��Center=�6D   $��Right=�6_   �� 5;   
   -   5        $ AssignmentTypeTextBox��5;      $��2��5<      $��1��6   $��10q�5=      $��Center=�5>      $	��300��5?      $��30��6!   $��Assignment Type��5@      
�������5B      �� 5E   
   $��	Due Date:��6   $��3��6$   $��10q�61   $��Center=�6=   $��Right=�6X   (  "System.Windows.Controls.DatePicker  5F   
   -   5          Name$ DueDatePicker��5F      $��3��5G      $��1��6"   $��10q�5H      $��Center=�5I      $	��300��5J      �� 5M   
   $��Assignment Value:��6   $��4��6,   $��10q�69   $��Center=�6E   $��Right=�6`   �� 5N   
   -   5        $ AssignmentValueTextBox��5N      $��4��5O      $��1��6   $��10q�5P      $��Center=�5Q      $	��300��5R      $��30��6!   $��Assignment Value��5S      
�������5U      �� 5X   
   $��Assignment Result:��6   $��5��6-   $��10q�6:   $��Center=�6F   $��Right=�6a   �� 5Y   
   -   5        $ AssignmentResultTextBox��5Y      $��5��5Z      $��1��6   $��10q�5[      $��Center=�5\      $	��300��5]      $��30��6!   $��Assignment Result��5^      
�������5`      �� 5c   
   $��Select Subject:��6   $��6��6*   $��10q�67   $��Center=�6C   $��Right=�6^   �� 5d   
   -   5         ��Name$ SubjectComboBox��5d      $��6��5e      $��1��6    $��10q�5f      $��Center=�5g      $	��300��5h       �� 
IsEditable$ False��5i      �� 5l   
   -   5         ��Name$ SubmitButton��5l      $��Make Changes��5m      $��8��5n      $��2��6   $��10q�5o      $��Center=�5p      $��Center=�5q      $	��150��5r      $��40��6    5s      5t      5u      