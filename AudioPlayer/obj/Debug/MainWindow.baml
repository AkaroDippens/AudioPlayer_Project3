   M S B A M L   `   `   `  ????  AudioPlayer    AudioPlayer.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  AudioPlayer??5   	   $	??425??6   $	??600??6*   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5	   	   .??5
      ?  ? RowDefinitions 5   
   ?? 5      $	??60* ?6   ?? 5      $
??117* ?6   ?? 5      $
??128* ?6   ?? 5      $	??39* ?6   ?? 5      $	??65* ?6    ? ColumnDefinitions 5   
   ?? 5      $
??149* ?6   ?? 5      $
??104* ?6   ?? 5      $
??113* ?6   ?? 5      $
??118* ?6   ?? 5      $
??116* ?6   .+?5   
   ?? -   5        $??Listik??5      $	??189??6!   $??	90,13,2,0q?6.   $	??Top=?6A   $??4??6Y   $??2??6m   $??1??6~   6?   ?? 5   
   -   5        $??btn_open??5      $??Открыть??6!   $??Center=?63   $??0,11,0,0q?6P   $	??Top=?6b   $??90??6z   $??4??6?   $??26??6?   r? 5   
   -   5        $??media??5       r? LoadedBehavior$ Manual=?6$   $	??260??6<   $??
20,44,20,0q?6I   $	??Top=?6]   $??5??6u   $??3??6?   ?? 5   
   
???   ?$??9,28,3,5q?6'   $??4??69   $??15(?6I   $??4??6W   
Звук6j   ?? 5   
   -   5        $??volumeSlider??5       ? Minimum$ 0Q?5       ? Maximum$ 1Q?6    ? Value$	 0.5Q?6    $??	25,9,4,23q?6,   $??4??6?   $??4??6O   ?? 5   
   -   5        $??Status??5      $
??0:00??6   $
??Left=?6-   $??
10,8,10,22q?6O   	 J? RenderTransformOrigin$	 0.522,0.688&?6c   $??4??6?   $??19(?6?   ?? 5    
   -   5        
 ??Name$
 btn_play??5       $??2??6#   $??4??63      MaterialDesignIconButton#??[  6@    ? ToolTip$ MaterialDesignIconButton??6r    ( $MaterialDesignTextFieldBoxBackground#???  5!      .??5"      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Play=?6&   $??38??62   $??38??6=   5#      ?? 5$   
   -   5        $
 	btn_pause??5$      $??4??6$   $??3??61   #???   6A   #???  6t   .??5%        $ Pause=?6&   $??38??63   $??38??6>   5&      ?? 5'   
   -   5         ??Name$ audio_Slider??5'      $??5??6'   $??104,16,104,0q?6;   $	??Top=?6Q   $??18??6?   $??3??6?   ?? 5(   
   -	   5        $
 btn_stop??5(      $??4??6#   $??1??60   #???   6@   #???  6s   .??5)        $
 Stop=?6&   $??38??62   $??38??6=   5*      ?? 5+   
   -
   5         ??Name$ Lable??5+      $??4??6   $??Label??6/   $
??Left=?6?   $??10,0,0,0q?6Z   $??2??6l   $??Center=?6y   $	??103??6?   5,      5.      