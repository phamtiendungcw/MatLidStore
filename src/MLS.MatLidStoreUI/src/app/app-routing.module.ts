import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'matlidstore/admin', pathMatch: 'full' },
  {
    path: 'matlidstore/admin',
    loadChildren: () => import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'matlidstore',
    loadChildren: () => import('./modules/client/client.module').then((m) => m.ClientModule),
  },
  { path: 'account', loadChildren: () => import('./theme/pages/account/account.module').then((m) => m.AccountModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
