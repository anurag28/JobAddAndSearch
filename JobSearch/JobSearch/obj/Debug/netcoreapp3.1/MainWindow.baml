   M S B A M L   `   `   `  ����D  @JobSearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:JobSearch	JobSearch  5   	   =#clr-namespace:JobSearch.ValidationsJobSearch.Validations  5   	   3clr-namespace:JobSearch.ModelsJobSearch.Models  5   	       JobSearch.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:JobSearch     5   	   6local1#clr-namespace:JobSearch.Validations     5   	   1local2clr-namespace:JobSearch.Models     5   	     � Title$  HR Management System��5
   	   $	��550��6&   $
��1000��63    � 	Resources 5      (   "JobSearch.Validations.RowConverter   myConverter$   JobSearch.Validations.HourRule 
 aHours   JobSearch.Models.Job  job��%W   &	        &	      &	 &       5   
   6     5   
   6     5   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      6!   �� 5      6!   .+�5   
   �� $��0��6   .+�5      �� -   5         ��Name$ 
lblJobName��5      $	��120��6(   $��Enter Job Name��64   $
��Left=�6M   $��10q�6h   $
��Bold"�6t   6�   �� 5      -   5        $ lblHours��5      $	��120��6&   $��Hours Worked��62   $
��Left=�6I   $��10q�6d   $
��Bold"�6p   6�   �� 5      -   5        $ lblAssignedTo��5      $	��120��6+   $��Assigned To��67   $
��Left=�6M   $��10q�6h   $
��Bold"�6t   6�   �� 5      -   5         ��Name$ btnAdd��5      $	��Add��6%   $
��Left=�63   $��30q�6N   $��60��6Z   $��30��6e   6�   �� 5      -   5        $ btnSave��5      $
��Save��6&   $
��Left=�65   $��30q�6P   $��60��6\   $��30��6g   6�   5      �� 5    
   $��1��6   .+�5!      �� -   5         ��Name$ 
txtJobName��5!      $��10q�6*   $
��Left=�66   $	��200��6Q   $��30��6]   6k   �� 5"      -   5        $ txtHours��5"      $��10q�6(   $
��Left=�64   $	��200��6O   $��30��5#       � DataContext# [ 5%       � ToolTip 5$      ��  �� ElementName$ txtHours��	 �� Path$)	 #(Validation.Errors)[0].ErrorContent�.��5%   u   ��5&      �� 5'      $	 Hours�6   
 �� ValidationRules
 5(        5)      
   Min$ 0Q�6.   
   Max$ 8Q�66   6@   5+      .��5,       5-      �� 5.      -   5        $ txtAssignedTo��5.      $��10q�6-   $
��Left=�69   $	��200��6T   $��30��6`   6n   5/      &   System.Windows.Controls.DataGrid  50   
   -	   5          Name$ grdAddedJobs��50      $��2��6)   $��10q�6b      AutoGenerateColumns$ False��6n   ��69   �� $	 DisplayJobs�   RowStyle 51      �� 52       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�53      ��  �� Property � �� �� Value 63   �� *Hours+ �� 	Converter# [  54         Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ Job Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 67   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6A   �� *Name+6\     59      $ Hours Worked��6%   $ * 6;    6E   �� *Hours+6a     5:      $ Assigned To��6%   $ * 6:    6D   �� *
Assigned+6c   5<      �� 5=   
   $��3��6   .+�5?        $��10q�6   $
��Auto��6#   $ False��61   ��6M   �� $	 DisplaySearchedJobs� 5@        5A      $ Job Name��6)   $ * 6;    6E   �� *Name+6`     5B      $ Hours Worked��6)   $ * 6?    6I   �� *Hours+6e     5C      $ Assigned To��6)   $ * 6>    6H   �� *
Assigned+6g   5E      �� 5F      -
   5        $ 	txtSearch��5F      $	��200��6)   $��30��65   $��Search by Job Name��6A   $��Center=�6[   $��10q�6x   6�   �� 5G      -   5        $ 	btnSearch��5G      $��Search��6(   $��Center=�69   $��10q�6V   $��60��6b   $��30��6m   6�   5H      5I      5J      