import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminHomeComponent } from './admin-home/admin-home.component';

const routes: Routes = [
  {
    path: '',
    component: AdminHomeComponent,
    children: [
      {
        path: 'account',
        loadChildren: () => import('src/app/theme/pages/account/account.module').then(m => m.AccountModule),
      }, // Lazy load account module cho login
      { path: 'home', loadChildren: () => import('src/app/theme/pages/pages.module').then(m => m.PagesModule) }, // Lazy load pages module cho dashboard
      { path: '', redirectTo: 'home/dashboard', pathMatch: 'full' }, // Mặc định chuyển đến dashboard
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppAdminRoutingModule {}
