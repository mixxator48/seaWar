   M S B A M L   `   `   `  ����B  >WarShip, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WarShipWarShip  5   	       WarShip.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WarShip     5   	   -   5          � Title$  WarShip��5   	   $��18(�5	   	   $	��580��5
   	   $��816.579��5   	   $��Rockwell Extra Bold)�5   	   $y�Visible=�5   	    � Topmost . ���	#FF32BCDA � 
ResizeMode$ NoResize=�5        � Icon$ Resources/ship.ico��6M    � 	Resources 5       
  blocks �� Property �� Value��%G   &	        �� 5   
   .�5      ��  � ��$ 2q�6/   5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $	��250 �6   .+�5   
   � -   5        $��fieldOfEnemy��5      $��0��6#   #��[  63   ��5      �� 5        �� EndPoint$	 0,0&�6&   	 �� 
StartPoint$	 0.5,1&�65   .��5!      � 
 � Color$
 	#FF011E68��6#    � Offset$ 0Q�65   � 5"      $
 	#FF6490DE��6#   $ 1Q�65   5#      .+�5%      A� -   5        $��fieldOfenemyUniform��5%      $��30q�65   5&      A� 5(   
    A� Rows$ 2��6   $��1��6   .+�5*      � $��1��6   $��0��6#   #��[  60   ��5+      �� 5,      $ 0.8,1&�6*    � MappingMode$ RelativeToBoundingBox=�6;   $		 1,0&�6_   .��5-      � $
 	#FF34F1E0��6'   $ 0Q�69   � 5.      $
 	#FF000ADA��6'   $ 1Q�69   5/      .+�51      A� -   5        $��myField��51      $��10q�6-   52      � 54      -   5        $��fieldOfInfo��54      ���#ffffff$��1��6;   $��1��6K   #��[  6X   .+�56      �� -   5        $
��btn1��56      $��Start!��57      $��0,224,125,0q�58      $	��125��59      $��50��6%   5:      �� 5<      -   5        $��Exit!��5<      $
��Left=�5=      $��125,224,0,0q�5>      $	��Top=�5?      $	��125��5@      $��50��6%   5A      �� 5B      $
��Left=�6   $	��180��67   $��8,28,0,0q�6D   $
��Wrap=�6V   $��            Your Score:��6j   $	��Top=�6�   $	��228��6�   5C      5E      5F      5G      