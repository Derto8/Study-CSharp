   M S B A M L   `   `   `  ����E  AWpfProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:WpfProject.Pages.TasksWpfProject.Pages.Tasks  5      .    (WpfProject.Pages.Tasks.GeneratePasswords   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:WpfProject.Pages.Tasks     5        N� Title$  GeneratePasswords��5	      .��5      � 
������� � RowDefinitions 5   
   �� 5      $	��44* �6   �� 5      .+�5   
   �  J� OpacityMask �	#FF553D3A���	#FF553D3A$	��100��6>   $	��Top=�6K   .+�5      �� -   5        $��Вернуться��5      $��	0,31,10,0q�6)   $	��Top=�6<   
�������$��28��6g   ���	#FF553D3A$��	Helvetica)�6�   $��12(�6�   $��Right=�6�   $��68��6�   �� 5      $'��!Генератор паролей��6   $��	Helvetica)�60   $��16(�6G   
�������$
��Left=�6h   $��37,0,0,0q�6�   $��Center=�6�   5      �� 5   
   -   5        $-��'Сгенерировать пароли��5      $��
18,305,0,0q�60   ���	#FF553D3A
�������$��	Helvetica)�6   $��14(�6�   $
��Left=�6�   $	��185��6�   $��30��6�   $	��Top=�6�   �� 5   
   -   5         ��Name$ 	tb_lenght��5      $��14(�6%   $
��Left=�63   $��
18,136,0,0q�6N   $�� ��6b    �� TextWrapping$
 Wrap=�6j   $	��Top=�6~   $	��167��6�   $��24��6�   ���	#FF553D3A
�������6�   �� 5   
   $��Длина пароля:��6   $
��Left=�6(   $��
18,112,0,0q�6C   $	��Top=�6W   $��	Helvetica)�6o   ���	#FF553D3A$��24��6�   $��90��6�   �� 5   
   -   5        $ 	tb_amount��5      $��
18,197,0,0q�6%   $��14(�69   $�� ��6G   $
 Wrap=�6O   ���	#FF553D3A
�������$
��Left=�6�   $	��167��6�   $��24��6�   $	��Top=�6�    J� RenderTransformOrigin$ 0.517,-0.276&�6�   �� 5   
   $E��?Количество сгенерируемых паролей:��6   $
��Left=�6<   $��
18,168,0,0q�6W   $	��Top=�6k   $��	Helvetica)�6�   ���	#FF553D3A$��24��6�   $	��215��6�   �� 5   
   -   5        $ tb_path��5      $��
18,255,0,0q�6#   $��C:\Passwords.txt��67   $
 Wrap=�6O   ���	#FF553D3A$��14(�6z   
�������$
��Left=�6�   $	��167��6�   $��24��6�   $	��Top=�6�   $ 0.517,-0.276&�6�   �� 5   
   $��Путь до файла:��6   $
��Left=�6)   $��
18,226,0,0q�6D   $	��Top=�6X   $��	Helvetica)�6p   ���	#FF553D3A$��24��6�   $��92��6�   �� 5   
   -   5         ��Name$	 Rez��5      $�� ��6   $
��Left=�6(   $��
18,351,0,0q�6C   $	��Top=�6W   $��	Helvetica)�6o   $��14(�6�   ���	#FF553D3A$��33��6�   $	��230��6�   5      5      