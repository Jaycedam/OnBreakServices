   M S B A M L   `   `   `  ����E  AOnBreakApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:OnBreakApp.PagesOnBreakApp.Pages  5      (    "OnBreakApp.Pages.PageAdminClientes   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:OnBreakApp.Pages     5      e aMahApps.Metro.IconPacks.Modern, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ah dMahApps.Metro.IconPacks.Zondicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Typicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.FeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a^	 ZMahApps.Metro.IconPacks, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag
 cMahApps.Metro.IconPacks.Ionicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ak gMahApps.Metro.IconPacks.WeatherIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137al hMahApps.Metro.IconPacks.MaterialLight, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Octicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ae aMahApps.Metro.IconPacks.Entypo, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Unicons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137af bMahApps.Metro.IconPacks.Microns, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ac _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.FontAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137aj fMahApps.Metro.IconPacks.SimpleIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.BoxIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.EvaIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.RPGAwesome, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ai eMahApps.Metro.IconPacks.PicolIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137am iMahApps.Metro.IconPacks.MaterialDesign, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.JamIcons, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks     	 
                 64     N� Title$  PageAdminClientes��5	       � 	Resources 5       �� 
TargetType   txtPages �� BasedOn  cboPages  MahApps.Styles.Label  MahApps.Styles.TextBlock��%�   '��       7   '�� "     7  '�� D     7  '�� f     7  �� 5   
   " ��6   8   6%   �� 5   
   " ��6   8   6&   �� 5   
   " ��6   8   6#   �� 5   
   " ��6   8   6'   5      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��10 �6   �� 5      $��40 �6   �� 5      �� 5      $��40 �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $��20 �6    � ColumnDefinitions 5!   
   �� 5"      $��40 �6   �� 5#      �� 5$      $��10 �6   �� 5%      �� 5&      $��10 �6   �� 5'      �� 5(      $��40 �6   .+�5+   
   �� $��ADMINISTRAR CLIENTES��6    J� IsHitTestVisible .  $��0��5,      $��1��6   $��5��6-   $��Center=�5-      $��Center=�6+   $��Segoe UI Black)�5.      $��34(�6,   �� 51   
   $��2��6   $��1��6"   $��3��62    �� Orientation$ 
Horizontal=�6F   $��Center=�6_   .+�52      ,  &MahApps.Metro.IconPacks.PackIconModern     Kind$ 
PageSearch=�6'   $��25��69   $��25��6E   ���	#FF25C9C9$��0,0,10,0q�53   >   $��Center=�6P   �� 54      $��Buscar��6   $��20(�6%   $��Segoe UI Semibold)�63   �� 56      -   5        	 ��Name$	 btnLimpiarDatos��56      $
��Left=�6.   $��30,0,0,0q�6I    $  MahApps.Styles.Button.Chromeless#��[ 57      .��58      �� $ 
Horizontal=�6   $��Center=�66   $��Center=�6Q   .+�59        $ Clear=�6/   $��Center=�6<   �� 5:      $��LIMPIAR��6    $��5,0,0,0q�6/   5;      5<      5=      �� 5?   
   $��3��6   $��1��6"   $��Stretch=�62   $	��Top=�6P   .+�5@      �� $��Rut (ej 146542354)��6   �� 5A      -   5        
 ��Name$
 txtBuscarRut��5A       �� 	MaxLength$ 9��6,   5B      �� 5D   
   -   5        $	 btnBuscarCliente��5D      $��3��6+   $��3��68     btnPages#��[ 5E      $	��Top=�5F      $
��Left=�6)   $��	20,15,0,0q�6D   .��5H      �� $ 
Horizontal=�6   $��Center=�62   .+�5I        $ Magnify=�6+   $��Center=�6:   �� 5J      $��BUSCAR��6   $��5,0,0,0q�6*   5K      5L      �� 5O   
   $��4��6   $��1��6"   $��3��62   $ 
Horizontal=�6F   $��Center=�6_   .+�5P        $ FolderPeople=�6'   $��25��6;   $��25��6G   ���	#FF25C9C9$��0,0,10,0q�5Q   >   $��Center=�6P   �� 5R      $��Cliente��6   $��20(�6&   $��Segoe UI Semibold)�64   5S      .  (MahApps.Metro.IconPacks.PackIconBoxIcons  5U   
      Kind$ SolidHelpCircle=�6%   $��4��6<   $��5��6I   $��Right=�5V   )   $��Center=�6E   $��20��5W   )   $
��auto��65   ���	#FF25C9C9 � ToolTip$I CLos botones para modificar/eliminar se activan al buscar un cliente��5X   )   �� 5Z   
   $��5��6   $��1��6"   $��Stretch=�62   $	��Top=�6P   .+�5[      �� $��Rut (ej 146542354)��6   �� 5\      -   5        $
 txtRut��5\      $ 9��6&   5]      �� 5_   
   $��5��6   $��3��6"   $��Stretch=�62   $	��Top=�6P   .+�5`      �� $��Nombre contacto��6   �� 5a      -   5        $
 	txtNombre��5a      5b      �� 5d   
   $��5��6   $��5��6"   $��Stretch=�62   $	��Top=�6P   .+�5e      �� $��Razón social��6   �� 5f      -   5        $
 txtRazonSocial��5f      5g      �� 5j   
   $��6��6   $��1��6"   $��Stretch=�62   $	��Top=�6P   .+�5k      �� $��Mail contacto��6   �� 5l      -   5        $
 txtMailContacto��5l      5m      �� 5o   
   $��6��6   $��3��6"   $��Stretch=�62   $	��Top=�6P   .+�5p      �� $��Teléfono (ej 958965445)��6   �� 5q      -   5        $
 txtTelefono��5q      $ 9��6+   5r      �� 5t   
   $��6��6   $��5��6"   $��Stretch=�62   $	��Top=�6P   .+�5u      �� $��	Direccion��6   �� 5v      -	   5        $
 txtDireccion��5v      5w      �� 5y   
   $��7��6   $��1��6"   $��Stretch=�62   $	��Top=�6P   .+�5z      �� $��Tipo de Empresa��6   �� 5{      -
   5         ��Name$ cboTipoEmpresa��5{      5|      �� 5~   
   $��7��6   $��3��6"   $��Stretch=�62   $	��Top=�6P   .+�5      �� $��Actividad empresa��6   �� 5�      -   5        $ cboActividadEmpresa��5�      5�      �� 5�   
   $��10��6   $��1��6#   $��5��63   $ 
Horizontal=�6G   $��Center=�5�      $��Center=�60   .+�5�      �� -   5        $	 btnRegistrarCliente��5�      $��0,0,20,0q�62   #��[ 5�      .��5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�        $ PageAdd=�6/   $��Center=�6>   �� 5�      $��	REGISTRAR��6    $��5,0,0,0q�61   5�      5�      �� 5�      -   5        $	 btnNuevoContrato��5�      {�.   J� Opacity$	 0.5Q�6A   #��[ 5�      .��5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�      4  .MahApps.Metro.IconPacks.PackIconMaterialDesign     Kind$	 Add=�67   $��Center=�6B   �� 5�      $��CONTRATO��6    $��5,0,0,0q�60   5�      5�      �� 5�      -   5        $	 btnModificarCliente��5�      {�.  $	 0.5Q�6D   #��[ 5�      $��	20,0,20,0q�5�      .��5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�        $
 Edit=�6/   $��Center=�6;   �� 5�      $��	MODIFICAR��6    $��5,0,0,0q�61   5�      5�      �� 5�      -   5        $	 btnEliminarCliente��5�        btnPagesDelete#��[ 61   {�.  $	 0.5Q�5�   '   .��5�      �� $ 
Horizontal=�6   $��Center=�66   .+�5�        $ Delete=�6/   �� 5�      $��ELIMINAR��6    $��5,0,0,0q�60   5�      5�      5�      5�      5�      