   M S B A M L   `   `   `  ����F  BKeyPressApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KeyPressAppKeyPressApp  5   	       KeyPressApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KeyPressApp     5   	   -   5          �Name$  MyWindow��5   	    � Title$ KeyPress��5   	   $	��350��6   $	��720��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $��3* �6   �� 5      $��1* �6    � ColumnDefinitions 5   
   �� 5      $	��400 �6   �� 5      $��1* �6   .+�5   
   �� $��0��6   $��Center=�6"   $��Center=�6=   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   .+�5      �� $��	App Name:��6   $��90��6,   �� 5      -   5        $��
txtAppName��5      $��30��6j   $	��250��6v   ��6,   �� *	AppName+ �� UpdateSourceTrigger$ PropertyChanged=�6v   5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� $��Key Pressed:��6   $��90��6/   �� 5      -   5        $��txtImput��5      $��30��6k   $��30��6w   ��6*   �� *
KeyToPress+$ PropertyChanged=�6w   5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5      �� $��Secounds per:��6   $��90��60   �� 5      -   5        $��txtSecounds��5   E   $��30��6�   $��30��6�   ��6X   �� *SecoundsPerPress+$ PropertyChanged=�6�   5      �� 5      $ 
Horizontal=�6   $��5q�62   .+�5       �� $��# of Times:��6   $��90��6.   �� 5!      -   5        $��txtNumberOfTimes��5!   E   $��30��6�   $��30��6�   ��6]   �� *NumberOfTimes+$ PropertyChanged=�6�   5"      5#      �� 5$   
   $��0��6   $��1��6"   .+�5%      �� $��.5q�6   
�������$��2q�6=   ._�5&      �� -   5        $��txtInfo��5&      $	��200��6i   ��6+   �� *	LogInfo+$ PropertyChanged=�6i   5'      �� 5(      -   5        $��btnClear��5(      $��Clear��6K   $��2,0,3,0q�6[   $��20��6l   $��40��6x   $��Right=�5)      ��5(   &   �� *ClearLogCommand+5)      5*      �� 5+   
   $��1��6   $��2��6"   $��Bottom=�66   $��Center=�6Q   .+�5,      �� -   5        $��lbStatus��5,      $��Center=�6j   ��6$   �� *StateDisplay+$ PropertyChanged=�6j   �� 5-      $ 
Horizontal=�6   .+�5.      �� -	   5        $��btnStart��5.      $��Start��6K   $��3q�6[   $��35��6f   $��75��6r   ��6)   �� *StartCommand+6r   �� 5/      -
   5        $��btnStop��5/      $
��Stop��6J   $��3q�6Y   $��35��6d   $��75��6p   ��6)   �� *StopCommand+6p   50      51      �� 52   
   $��1��6   $��2��6"   $ 
Horizontal=�66   $��Bottom=�6O   $��Right=�53      .+�54      �� -   5        $��btnClose��54      $��Close��6�   $��3q�6�   $��35��6�   $��75��6�   ��6&   �� *CloseWindowCommand+ �� Mode$ OneWay=���6[   ��  �� ElementName$ MyWindow��6�   55      56      57      