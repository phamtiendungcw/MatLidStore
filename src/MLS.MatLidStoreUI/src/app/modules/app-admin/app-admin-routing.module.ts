import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { DashboardComponent } from 'src/app/theme/pages/dashboard/dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: AdminHomeComponent,
    children: [
      {
        path: 'login',
        loadChildren: () => import('src/app/theme/pages/account/account.module').then(m => m.AccountModule),
      },
      {
        path: 'dashboard',
        loadChildren: () => import('src/app/theme/pages/pages.module').then(m => m.PagesModule),
        component: DashboardComponent,
      },
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppAdminRoutingModule {}
