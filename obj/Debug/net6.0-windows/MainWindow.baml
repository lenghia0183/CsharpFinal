   M S B A M L   `   `   `  ����>  :ck5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ck5ck5  5   	       ck5.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:ck5     5   	     � Title$  
MainWindow��5   	   $	��589��6   $	��800��6)   .��5	      �� 
�������
�������$��10q�67   ._�5
   
   � $��10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��3* �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $
��auto �6    .+�5      �� $��0��6   $��0��6!      
lableStyle#��[  61   .��6U   MaNV:6]   �� 5      $��1��6   $��0��6!   #��[  61   .��6U   HoTen:6]   �� 5      $��2��6   $��0��6!   #��[  61   .��6U   	NgaySinh:6`   �� 5      $��3��6   $��0��6!   #��[  61   .��6U   
GioiTinh6_   �� 5       $��4��6   $��0��6!   #��[  61   .��6U   
NgoaiNgu6_   �� 5!      $��5��6   $��0��6!   #��[  61   .��6U   
PhongBan6_   �� 5#      -   5        $
��MaNV��5#      $��0��6"   $��1��6/     
inputStyle#��[ 6?   6e   �� 5$      -   5        $��HoTen��5$      $��1��6#   $��1��60   #��[ 6@   6f   (  "System.Windows.Controls.DatePicker  5&      -   5        $��NgaySinh��5&      $��2��6)   $��1��66   $
��Left=�6F   $	��150��6a   $��30��6m   6{   �� 5(      $��3��6   $��1��6&    �� Orientation$ 
Horizontal=�66   $
��Left=�6O   .+�5)      	� -   5        $	��Nam��5)   /    d� 	IsChecked$
 TrueY�6    	� 	GroupName$ gt��6:     
radioStyle#��[ 6I   .��6m   Nam6r   	� 5*      -   5        $��Nu��5*      $ gt��6(   #��[ 67   .��6[   Nu6_   5+      �� 5-      $��4��6   $��1��6&   $ 
Horizontal=�66   $
��Left=�6O   .+�5.      �� -   5        $��TiengAnh��5.        checkboxStyle#��[ 6+   .��6R   	Tieng Anh6]   �� 5/      -   5        $��
TiengTrung��5/      #��[ 6-   .��6T   Tieng Trung6a   �� 50      -   5        $��	TiengPhap��50      #��[ 6,   .��6S   
Tieng Phap6_   51      �� 53      -	   5        $��CbbPhongBan��53      $	��150��6*   $��30��66   $��5��6B   $��1��6O   6a   &   System.Windows.Controls.DataGrid  55      -
   5        $��dtgNhanVien��55         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6*   $��10q�6:      AutoGenerateColumns$ False��6F   $	��100��6b   $��2��6o   $��6��6�   $��0��6�      Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 MaNV��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *MaNv+  58      $	 HoTen��6)   
 68   �� *HoTen+  59      $	 NgaySinh��6)   
 6;   �� *
NgaySinh+  5:      $	 GioiTinh��6)   
 6;   �� *
Gioitinh+  5;      $	 NgaoiNgu��6)   
 6;   �� *
NgoaiNgu+  5<      $	 PhongBan��6)   
 6;   �� *TenPhongBan+5>      �� 5@      $��Center=�6   $��Center=�66   $ 
Horizontal=�6Q   $��2��6j   $��7��6~   $��0��6�   .+�5A      �� -   5          btnStyle#��[ 5A        btnTemplate#��[ 6;   .��6x   Them6~   �� 5B      -   5        #��[ 5B      .��6R   Tim6W   �� 5C      -   5        #��[ 5C      .��6R   Xoa6W   �� 5D      -   5        #��[ 5D      .��6R   Sua6W   5E      5G      5H      5I      