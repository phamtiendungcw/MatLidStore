import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from 'src/app/core/guards/auth.guard';
import { ClientHomeComponent } from './client-home/client-home.component';

const routes: Routes = [
  {
    path: '',
    component: ClientHomeComponent,
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
      { path: '', redirectTo: 'home', pathMatch: 'full' }, // Mặc định chuyển đến welcome
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppClientRoutingModule {}
