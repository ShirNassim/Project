   M S B A M L   `   `   `  ����M  ITelephoneDirectory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TelephoneDirectoryTelephoneDirectory  5   	   #    TelephoneDirectory.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TelephoneDirectory     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��Phone Directory��6   $
��Left=�69   $��62��6T   $��	153,2,0,0q�6`   $	��Top=�6t   $	��253��6�   $��30(�6�   �� 5   
   -   5         ��Name$ lvDataBinding��5      $
��Left=�6*   $	��246��6E   $��
265,64,0,0q�6R   $	��Top=�6f   $	��224��6~    �� View 5      �� 5      .P�5      �� $
��Name��5   !    �� Width$	 120��6/    �� DisplayMemberBinding 5   %   ��  �� Path$ fullName�5   /   �� 5      $��Phone Number��5   !   $	 100��67    5   %   �� $ phoneNum�5   7   5      5      �� 5   
   -   5         ��Name$ addBtn��5      $��New Contact��6!   $
��Left=�67   $��145,163,0,0q�6R   $	��Top=�6g   $��82��6   $��28��6�   6�   �� 5   
   -   5        $ saveBtn��5      $
��Save��6"   $
��Left=�61   $��
60,268,0,0q�6L   $	��Top=�6`   $��99��6x   $��28��6�   6�   �� 5   
   -   5        $��txtHintName��5      $��34,168,369,120q�5      $��
enter name��5      
�������5      �� 5   
   -   5        $��txtName��5      
������ $��24,165,381,123q�5!   3   �� 5%   
   -   5         ��Name$ orderByNameCB��5%      $��Order By Name��6*   $
��Left=�6B   $��
24,122,0,0q�6]   $	��Top=�6q   6�   �� 5&   
   -   5        $ loadBtn��5&      $��Upload Existing List��6"   $
��Left=�6A   $��28��6\   $��
24,202,0,0q�6h   $	��Top=�6|   $	��203��6�   6�   5(      5)      