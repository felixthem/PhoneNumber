   M S B A M L   `   `   `  ����a  ]Моя телефонная книга, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullq=clr-namespace:Моя_телефонная_книга.Window_s/Моя_телефонная_книга.Window_s  5   	   @    :Моя_телефонная_книга.Window_s.CallWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Olocal=clr-namespace:Моя_телефонная_книга.Window_s     5   	     � Title$  
CallWindow��5   	   $	��600��6   $	��500��6)    � 
ResizeMode$ NoResize=�65    � Icon$H B/Моя телефонная книга;component/Picture/icon.png��6K    � WindowStartupLocation$ CenterScreen=�6�    � WindowStyle$
 None=�6�   .��5	      � -   5         �Name$ callGrid��5	      $
��Left=�6   $	��600��68   $	��Top=�6E   $	��500��6]   ���	#FF0E1621.+�5
   
   �� $��Идёт звонок...��6   $
��Left=�6)   $��	18,10,0,0q�6D   $	��Top=�6W   $��30(�6o   ���	#FFAED9E06}   �� 5   
   -   5         ��Name$ timerT��5      $
��Left=�6$   $��
58,301,0,0q�6?   $
��Wrap=�6S   $��00:00:��6g   $	��Top=�6u    �� TextAlignment$ center=�6�   $	��370��6�   $��35(�6�   ���	#FFAED9E06�   �� 5   
   -   5        $ fioTextBlock��5      $
��Left=�6*   $��10,365,0,185q�6E   $
��Wrap=�6[   $#��Наркевич Михаил��6o   $��Center=�6�   $ center=�6�   $��30(�6�   ���	#FFFAF3DD$��46��6�   $	��476��6�   �� 5   
   -   5        $ numberTextBlock��5      $
��Left=�6-   $��18,420,0,126q�6H   $
��Wrap=�6^   $��+375(29)601-76-14��6r   $��Center=�6�   $ center=�6�   $��30(�6�   ���	#FFFAF3DD$��50��6�   $	��468��6�   �� 5   
   -   5         ��Name$ avatarCallImage��5      $
��Left=�6)   $	��178��6D   $��
165,85,0,0q�6Q   $	��Top=�6e   $	��172��6}   $J��D/Моя телефонная книга;component/Picture/avatar.png��6�   A� 5   
   $��47��6   ���	#FF0E1621	 �� StrokeDashCap$	 Round=�5       $��121,45,121,294q�66   �� 5   
   -   5        $��206,492,212,35q�5      $N��H/Моя телефонная книга;component/Picture/cancelCall.png��6(   $
��Fill=�6h   6w   A� 5   
   -   5        
 A�Name$
 
cancelCall��5      $��18��5       �� StrokeDashArray$  R�6"   ���	#FF0E1621$	 Round=�5       $��190,475,196,18q�66   6N   5      5      