   M S B A M L   `   `   `  ����E  AOnBreakApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnBreakApp.PagesOnBreakApp.Pages  5      #    OnBreakApp.Pages.PageRegister   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OnBreakApp.Pages     5      e aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^	 ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag
 cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks     	 
                 64     N� Title$  PageRegister��5	       � 	Resources 5       �� 
TargetType   loginTxt �� BasedOn  loginBtn  	loginPass  MahApps.Styles.Label  MahApps.Styles.TextBlock��%�   '��       7   '�� "     7  'G� D     7  '�� f     7  '�� �     7  �� 5   
   " ��6   8   6%   �� 5   
   " ��6   8   6$   �� 5   
   " G�6   8   6)   �� 5   
   " ��6   8   6#   �� 5   
   " ��6   8   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��240 �6   �� 5      �� 5      �� 5      $	��150 �6    � ColumnDefinitions 5   
   �� 5      $��60 �6   �� 5      �� 5      $��60 �6   .+�5    
   �� $��4��6   $��3��6"   ��5!      �� 5"      .��5#      �  � Color$ 	#FF00B663��6#   � 5$      $ 	#FF2035B8��6#    � Offset$	 1.3Q�65   5%      5'      �� 5)   
   $��0��6   $��1��6"   .+�5*      �� -   5         ��Name$ imgLogo��5*      $+��%/OnBreakApp;component/Images/logo.png��6%   $��2��6T   $��0,10,0,0q�6h   $��Center=�6z   $	��180��6�   $	��Top=�6�   �� 5+      $��Registrar usuario��6   $
��auto��60   $��Center=�6=   
�������$��Segoe UI Semibold)�6m   $��20(�6�   5,      �� 5.   
   -   5        	 ��Name$	 txtRegisterUser��5.      $��1��5/      $��1��6   50      ,  &MahApps.Metro.IconPacks.PackIconModern  51   
   
   Kind$

 User=�6#   
�������$��1��6C   $��1��6P   $��Center=�6`   $��Right=�6{   �� 53   
   $��1��6   $��1��6!   $��0,0,0,10q�61   $��Bottom=�6C   
�������6^   �� 54   
   $��2��6   $��1��6!   $��0,0,0,10q�61   $��Bottom=�6C   
�������6^   G� 57   
   -   5         G�Name$ passRegister��57      $��2��58      $��1��6#    G� Password$ contraseña��59      6,     5:   
   $
 InterfacePassword=�6#   
�������$��2��5;   #   $��1��60   $��Center=�5<   #   $��Right=�6>   �� 5>   
   -   5         ��Name$ btnRegistrarse��5>      $��REGISTRARSE��5?      $��3��5@      $��1��6   $
��Left=�5A      $��0,20,0,0q�5B       �� 	IsDefault . 5D      �� 5E   
   -   5        $ btnLogin��5E      $��INICIAR SESIÓN��5F      $��3��5G      $��1��6   $��Right=�5H      $��0,20,0,0q�5I      5J      �� 5L   
   -   5        $ closeWindow��5L      $��2��6&   $	��Top=�5M      $��Right=�6)   $��	0,10,10,0q�5N      $��30��6$   $��30��6/   .��5P      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5Q        $
 Close=�6+   $��Center=�68   5R      5S      5T      5U      