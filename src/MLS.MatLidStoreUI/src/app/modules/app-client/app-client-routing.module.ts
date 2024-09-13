import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientHomeComponent } from './client-home/client-home.component';

const routes: Routes = [
  {
    path: '',
    component: ClientHomeComponent,
    children: [
      {
        path: 'login',
        loadChildren: () => import('src/app/theme/pages/account/account.module').then(m => m.AccountModule),
      }, // Lazy load account module cho login
      { path: 'home', loadChildren: () => import('src/app/theme/pages/pages.module').then(m => m.PagesModule) }, // Lazy load pages module cho welcome
      { path: '', redirectTo: 'home/welcome', pathMatch: 'full' }, // Mặc định chuyển đến welcome
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AppClientRoutingModule {}
