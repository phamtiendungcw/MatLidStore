import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from 'src/app/core/guards/auth.guard';
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
      {
        path: 'home',
        loadChildren: () => import('src/app/theme/pages/pages.module').then(m => m.PagesModule),
        canActivate: [authGuard],
      }, // Lazy load pages module cho home
      { path: '', redirectTo: 'home', pathMatch: 'full' }, // Mặc định chuyển đến home
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppAdminRoutingModule {}
