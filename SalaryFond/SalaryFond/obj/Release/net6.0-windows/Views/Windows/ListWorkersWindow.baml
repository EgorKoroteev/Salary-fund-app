   M S B A M L   `   `   `  ???? E  ASalaryFond, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SalaryFond.Views.WindowsSalaryFond.Views.Windows  0    *SalaryFond.Views.Windows.ListWorkersWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:SalaryFond.Views.Windows       ? Title$  ListWorkersWindow??$	??450??$	??800?? ? DataContext ??  ?? RelativeSource ?? *Self+.??? .+?&   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False??   CanUserAddRows$ False?????? *
WorkerList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 №??   
IsReadOnly$
 True??1  +System.Windows.Controls.DataGridBoundColumn   Binding ?? *Id+  $ ФИО??	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 180 $
 True?? ?? *FIO+  $ Должность??$		 100 $
 True?? ?? *MainProfession+  $ 
Оклад??$	 80 $
 True?? ?? *
MainSalary+  $( "Часы(отработанные)??$
 True?? ?? *WorkedHours+  $ Часы(норма)??$
 True?? ?? *NormalHours+  $  Ставка руб/час??$
 True?? ?? *	RateRUB+  $* $Начислено по окладу??$
 True?? ?? *MainResultSalary+  $ Отпускные??$
 True?? ?? *
HolidayPay+  $ Больничные??$
 True?? ?? *	SickPay+  $ Премия 10%??$
 True?? ?? *Prize+  $+ %Премия руководителя??$
 True?? ?? *	PrizeBoss+  $ 
Штраф??$	 80 $
 True?? ?? *SummPenalties+  $# Итого начислено??$
 True?? ?? *FinalResultSalary+  $ 
Аванс??$	 80 $
 True?? ?? *
Prepayment+  $ РКО??$	 80 $
 True?? ?? *RKO+  $ Исп. лист??$	 80 $
 True?? ?? *ExecutiveList+  $" Перечислено р/с??$
 True?? ?? *TransferByCard+  $$ Остаток к выдаче??$
 True?? ?? *ResultSalary+