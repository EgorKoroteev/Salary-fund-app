   M S B A M L   `   `   `  ????E  ASalaryFond, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SalaryFond.Views.WindowsSalaryFond.Views.Windows  5   	   U/clr-namespace:SalaryFond.Infrastructure.Commads!SalaryFond.Infrastructure.Commads  5   	   ?    9SalaryFond.Views.Windows.AdditionalProfessionEditorWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:SalaryFond.Views.Windows     5   	   =c/clr-namespace:SalaryFond.Infrastructure.Commads     5   	     ? Title$&   AdditionalProfessionEditorWindow??5	   	   $	??300??62   $	??300??6?    ? DataContext 5
   	   ??  ?? RelativeSource ?? *Self+.??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      .+?5   
   ? $??0??6   .+?5      ?? $
??10,0q?6   .+?5      ?? $??Название??6   ?? 5      $	??180??6   $
??Left=?6&   ??6A   ?? *MainProfession+5      5      ? 5   
   $??1??6   .+?5      ?? $
??10,0q?6   .+?5      ?? $??
Оклад??6   ?? 5      -   5        $	??180??5      $
??Left=?6&   ??6A   ?? *
MainSalary+6]   5      5      ? 5!   
   $??2??6   .+?5"      ?? $
??10,0q?6   .+?5#      ?? $??Часы(норма)??6   ?? 5$      -   5        $	??180??5$      $
??Left=?6&   ??6A   ?? *NormalHours+6^   5%      5&      ? 5(   
   $??3??6   .+?5)      ?? $
??10,0q?6   .+?5*      ?? $(??"Часы(отработанные)??6   ?? 5+      -   5        $	??180??5+      $
??Left=?6&   ??6A   ?? *WorkedHours+6^   5,      5-      ? 5/   
   $??4??6   .+?50      ??  ?? Orientation$ 
Horizontal=?6   $??Right=?62   .+?51      ?? -   5         ??Name$ EditPCMemberButton??51      $??OK??65   $??40??6B   $??20??6M   $??0,0,30,0q?6Y    ?? 	IsDefault$
 True??6k   ??52      ??  ??  ?? AncestorType* &local:AdditionalProfessionEditorWindow??53      :  4SalaryFond.Infrastructure.Commads.CloseDialogCommand  54         DialogResult True6/   56      ?? 57      -   5        $ CancelButton??57      $??Отмена??6/   $??50??6@   $??20??6K   $??0,0,20,0q?6W   	 ?? IsCancel$
	 True??6i   ??58      ??  ?? * &local:AdditionalProfessionEditorWindow??59        5:      	 False6/   5<      5=      5>      5?      5@      