   M S B A M L   `   `   `  ����J  FpruebaProyecto2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:pruebaProyecto2pruebaProyecto2  5   	   1clr-namespace:pruebaProyecto2pruebaProyecto2  5   	   &     pruebaProyecto2.polinomioVentana   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0customclr-namespace:pruebaProyecto2     5   	   /localclr-namespace:pruebaProyecto2     5   	     � Title$  	polinomio��5	   	   $	��100��6   $	��300��6(   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��4* �6    � RowDefinitions 5   
   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��0��6!   
�������$��1q�6A   $��2q�6U   ._�5      �� $��Center=�6   $��Center=�65   $��2q�6P   F(x)=6b   5      �� 5    
   $��0��6   $��1��6!   
�������$��1q�6A   $��2q�6U   ._�5!      �� $��Center=�6   $��Center=�65   $��2q�6P   Rango6b   5"      � 5%   
   $��0��6   $��1��6    5&      �� 5'      $��* �6#   �� 5(      $
��0.7* �6#   �� 5)      $
��0.5* �6#   �� 5*      $��* �6#   �� 5+      $
��0.7* �6#   �� 5,      $
��0.5* �6#   �� 5-      $��* �6#   .+�50      $  pruebaProyecto2.numericTextBox  -   5          Name$ cajaCuadrado��50   ?   $��0��6$   $��2q�64   $��Center=�6U   $��Center=�6r   $��20��51   $   .��6/   053      �� 55      $��1��6   $��Center=�6(   $��Center=�6E   $	��x²��6`   57      �� 59      $��2��6   $��Center=�6(   $��Center=�6E   +5;        5=      -   5        $ 
cajaNormal��5=   ?   $��3��6$   $��2q�64   $��Center=�6S   $��Center=�6p   $��20��5>   $   .��6/   05@      �� 5B      $��4��6   $��Center=�6(   $��Center=�6E   X5D      �� 5F      $��5��6   $��Center=�6(   $��Center=�6E   +5H        5J      -   5        $ cajaIndependiente��5J   ?   $��6��6$   $��2q�64   $��Center=�6Z   $��Center=�6w   $��20��5K   $   .��6/   05M      5O      �� 5Q   
   $��1��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��Center=�6h   .+�5S        -   5        $ cajaBase��5S   =   $
��10,2q�6$   $��40��62   .��6O   5U        5W      -   5        $ cajaTope��5W   =   $
��10,2q�6$   $��40��62   .��6O   5Y        5[      -   5        $ cajaIncremento��5[   =   $
��10,2q�6$   $��40��62   .��6U   5]      �� 5_      -   5        $��1��5_      $��1��6%   $��5q�62   $��30��6=   $��calcular��6H   5a      5b      5i      5j      