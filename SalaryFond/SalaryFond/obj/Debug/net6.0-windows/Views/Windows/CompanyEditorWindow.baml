   M S B A M L   `   `   `  ????E  ASalaryFond, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SalaryFond.Views.WindowsSalaryFond.Views.Windows  5   	   U/clr-namespace:SalaryFond.Infrastructure.Commads!SalaryFond.Infrastructure.Commads  5   	   2    ,SalaryFond.Views.Windows.CompanyEditorWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:SalaryFond.Views.Windows     5   	   =c/clr-namespace:SalaryFond.Infrastructure.Commads     5   	     ? Title$=  7Редактирование подразделения??5	   	   $	??300??6.   $	??300??6;    ? DataContext 5
   	   ??  ?? RelativeSource ?? *Self+.??5      ?  ? RowDefinitions 5   
   ?? 5      ?? 5      ?? 5      ?? 5      .+?5   
   ? $??0??6   .+?5      ?? $
??10,0q?6   .+?5      ?? $??Название??6   ?? 5      -   5        $??CaseName??5      $	??180??6*   $
??Left=?66   ??6Q   ?? *NameCompany+5      5      ? 5   
   $??1??6   .+?5      ?? $
??10,0q?6   .+?5      ?? $??Расположение??6   ?? 5      -   5        $??CaseLocation??5      $	??180??6.   $
??Left=?6:   ??6U   ?? *
Location+5      5      ? 5    
   $??2??6   .+?5!      ?? $
??10,0q?6   .+?5"      ?? $4??.Плановый зарплатный фонд??6   ?? 5#      -   5        $??CasePlanningSalaryFound??5#      $	??180??69   $
??Left=?6E   ??6`   ?? *PlanningSalaryFund+6?   5$      5%      ? 5&   
   $??3??6   .+?5'      ??  ?? Orientation$ 
Horizontal=?6   $??Right=?62   .+?5(      ?? -   5         ??Name$ EditPCMemberButton??5(      $??OK??65   $??40??6B   $??20??6M   $??0,0,30,0q?6Y    ?? 	IsDefault$
 True??6k   ??5)      ??  ??  ?? AncestorType local:CompanyEditorWindow??5*      :  4SalaryFond.Infrastructure.Commads.CloseDialogCommand  5+         DialogResult True6/   5-      ?? 5.      -   5        $ CancelButton??5.      $??Отмена??6/   $??50??6@   $??20??6K   $??0,0,20,0q?6W   	 ?? IsCancel$
	 True??6i   ??5/      ??  ??  local:CompanyEditorWindow??50        51      	 False6/   53      54      55      56      57      