   M S B A M L   `   `   `  ????E  ASalaryFond, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:SalaryFond.Views.WindowsSalaryFond.Views.Windows  5   	   0    *SalaryFond.Views.Windows.ListWorkersWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:SalaryFond.Views.Windows     5   	     ? Title$  ListWorkersWindow??5   	   $	??450??6#   $	??800??60    ? DataContext 5	   	   ??  ?? RelativeSource ?? *Self+.??5
      ? .+?5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False??66      CanUserAddRows$ False??6R   ??6   ?? *
WorkerList+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$	 №??6%      
IsReadOnly$
 True??60   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   ?? *Id+  5      $ ФИО??6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 180 62   $
 True??6?    6Q   ?? *FIO+  5      $ Должность??6%   $		 100 68   $
 True??6D    6V   ?? *MainProfession+  5      $ 
Оклад??6%   $	 80 64   $
 True??6?    6Q   ?? *
MainSalary+  5      $( "Часы(отработанные)??6%   $
 True??6A    6S   ?? *WorkedHours+  5      $ Часы(норма)??6%   $
 True??6:    6L   ?? *NormalHours+  5      $  Ставка руб/час??6%   $
 True??6=    6O   ?? *	RateRUB+  5      $* $Начислено по окладу??6%   $
 True??6B    6T   ?? *MainResultSalary+  5      $ Отпускные??6%   $
 True??68    6J   ?? *
HolidayPay+  5      $ Больничные??6%   $
 True??69    6K   ?? *	SickPay+  5      $ Премия 10%??6%   $
 True??69    6K   ?? *Prize+  5      $+ %Премия руководителя??6%   $
 True??6B    6T   ?? *	PrizeBoss+  5      $ 
Штраф??6%   $	 80 64   $
 True??6?    6Q   ?? *SummPenalties+  5      $# Итого начислено??6%   $
 True??6>    6P   ?? *FinalResultSalary+  5      $ 
Аванс??6%   $	 80 64   $
 True??6?    6Q   ?? *
Prepayment+  5      $ РКО??6%   $	 80 62   $
 True??6=    6O   ?? *RKO+  5      $ Исп. лист??6%   $	 80 68   $
 True??6C    6U   ?? *ExecutiveList+  5      $" Перечислено р/с??6%   $
 True??6>    6P   ?? *TransferByCard+  5       $$ Остаток к выдаче??6%   $
 True??6?    6Q   ?? *ResultSalary+5#      5$      5%      