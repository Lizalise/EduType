   M S B A M L   `   `   `  ����G  CRUregistered, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:RUregisteredRUregistered  5   	   #    RUregistered.AdministratorUse   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:RUregistered     5   	     � Title$  AdministratorUse��5   	   $��599.86��6"   $��967.494��62    � Icon$ EduType.png��6B    � 
ResizeMode$ NoResize=�6U    � WindowStartupLocation$ CenterScreen=�6k   ��5	      �� 5
   
    �� ImageSource$ database.jpg��6   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	dataGrid1��5      $
��Left=�6&   $��
24,167,0,0q�6A   $	��Top=�6U   $	��394��6m   $	��770��6z      GridLinesVisibility$ 
Horizontal=�6�   �� 5   
   -   5         ��Name$ label5��5      $1��+<<< Search with Student Number or Last Name��6    $
��Left=�6_   $��304,124,0,0q�6z   $	��Top=�6�   $��28��6�   $	��328��6�   $��14(�6�   ���	#FFA7DFF3$
��Bold"�6�   �� 5   
   -   5         ��Name$ textBox4��5      $
��Left=�6$   $��29��6?   $��139,124,0,0q�6K   	 �� TextWrapping$
	 Wrap=�6`   $	��Top=�6t   $	��160��6�   6�   �� 5   
   -   5        
 ��Name$
 button4��5      $��
VIEW DATA
��6"   $
��Left=�6;   $��
24,129,0,0q�6V   $	��Top=�6j   $	��102��6�   $��29��6�   ��5      �� 5       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5      �  � Color$ 	#FFF3F3F3��6#    � Offset$ 0Q�65   � 5      $ 	#FFEBEBEB��6#   $	 0.5Q�65   � 5      $ 	#FFDDDDDD��6#   $	 0.5Q�65   � 5      $ 	#FF347471��6#   $ 1Q�65   5      5      �� 5   
   -   5        $
 button2��5      $��Delete��6"   $
��Left=�63   $��
503,10,0,0q�6N   $	��Top=�6b   $��88��6z   $��48��6�   $��16(�6�   $
��Bold"�6�   ��5      �� 5      $	 0,1&�6&   $	 0,0&�65   .��5      � $ 	#FFF3F3F3��6#   $ 0Q�65   � 5      $ 	#FFEBEBEB��6#   $	 0.5Q�65   � 5      $ 	#FFDDDDDD��6#   $	 0.5Q�65   � 5       $ 	#FF498073��6#   $ 1Q�65   5!      5#      �� 5$   
   -   5        $ textBox2��5$      $
��Left=�6$   $��40��6?   $��
238,16,0,0q�6K   $
	 Wrap=�6_   $	��Top=�6s   $	��236��6�   $��16(�6�    K� ZIndex$ 2��6�   �� 5%   
   -   5        $ label2��5%      $��Student Number :��6    $
��Left=�6;   $��	24,16,0,0q�6V   $	��Top=�6i   $��35��6�   $	��187��6�   $��16(�6�   $ 9��6�   ���	#FFC4E2F5$
��Bold"�6�   �� 5&   
   -   5        $
 button3��5&      $
��Home��6"   $
��Left=�61   $��
706,10,0,0q�6L   $	��Top=�6`   $��88��6x   $��48��6�   $��16(�6�   $
��Bold"�6�   ��5'      �� 5(      $	 0,1&�6&   $	 0,0&�65   .��5)      � $ 	#FFF3F3F3��6#   $ 0Q�65   � 5*      $ 	#FFEBEBEB��6#   $	 0.5Q�65   � 5+      $ 	#FFDDDDDD��6#   $	 0.5Q�65   � 5,      $ 	#FF498073��6#   $ 1Q�65   5-      5/      51      52      