   M S B A M L   `   `   `  ����E  AOnBreakApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnBreakApp.PagesOnBreakApp.Pages  5           OnBreakApp.Pages.PageLogin   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OnBreakApp.Pages     5      e aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^	 ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag
 cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks     	 
                 5        N� Title$  	PageLogin��5
       � 	Resources 5       �� 
TargetType   loginTxt �� BasedOn  loginBtn  	loginPass  MahApps.Styles.Label  MahApps.Styles.TextBlock��%�   '��       7   '�� "     7  'G� D     7  '�� f     7  '�� �     7  �� 5   
   " ��6   8   6%   �� 5   
   " ��6   8   6$   �� 5   
   " G�6   8   6)   �� 5   
   " ��6   8   6#   �� 5   
   " ��6   8   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��240 �6   �� 5      �� 5      �� 5      $	��150 �6    � ColumnDefinitions 5   
   �� 5      $��60 �6   �� 5      �� 5      $��60 �6   .+�5!   
   �� $��4��6   $��3��6"   ��5"      �� 5#      .��5$      �  � Color$ 	#FF386EFB��6#   � 5%      $ 	#FF82009E��6#    � Offset$ 1Q�65   5&      5(      �� 5*   
   $��0��6   $��1��6"   .+�5+      �� -   5         ��Name$ imgLogo��5+      $+��%/OnBreakApp;component/Images/logo.png��6%   $��2��6T   $��0,10,0,0q�6h   $��Center=�6z   $	��180��6�   $	��Top=�6�   �� 5,      $��Iniciar sesión��6   $
��auto��6-   $��Center=�6:   
�������$��Segoe UI Semibold)�6j   $��20(�6�   5-      �� 5/   
   -   5        	 ��Name$	 txtLoginUser��5/      $��1��50      $��1��6   51      ,  &MahApps.Metro.IconPacks.PackIconModern  52   
   
   Kind$

 User=�6#   
�������$��1��54   #   $��1��60   $��Center=�55   #   $��Right=�6>   G� 58   
   -   5         G�Name$ 	passLogin��58      $��2��59      $��1��6#    G� Password$ contraseña��5:      5;        5<   
   $
 InterfacePassword=�6#   
�������$��2��5=   #   $��1��60   $��Center=�5>   #   $��Right=�6>   �� 5@   
   $��1��6   $��1��6!   $��0,0,0,10q�5A      $��Bottom=�6&   
�������6A   �� 5B   
   $��2��6   $��1��6!   $��0,0,0,10q�5C      $��Bottom=�6&   
�������6A   �� 5E   
   -   5         ��Name$ btnRegistrarse��5E      $��REGISTRARSE��5F      $��3��5G      $��1��6   $
��Left=�5H      $��0,20,0,0q�5I      5J      �� 5K   
   -   5        $ btnLogin��5K      $��INICIAR SESIÓN��6#   $��3��5L      $��1��6   $��Right=�5M      $��0,20,0,0q�5N       �� 	IsDefault . 5P      �� 5R   
   -   5        $ closeWindow��5R      $��2��6&   $	��Top=�5S      $��Right=�6)   $��	0,10,10,0q�5T      $��30��6$   $��30��6/   .��5V      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5W        $
 Close=�6+   $��Center=�68   5X      5Y      5Z      5[      