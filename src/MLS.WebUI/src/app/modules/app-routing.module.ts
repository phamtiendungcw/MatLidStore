import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'admin/home', pathMatch: 'full' },
  {
    path: 'admin/home',
    loadChildren: () => import('./app-admin/app-admin.module').then((m) => m.AppAdminModule),
  },
  {
    path: 'client/home',
    loadChildren: () => import('./app-client/app-client.module').then((m) => m.AppClientModule),
  },
  {
    path: 'login',
    loadChildren: () => import('../theme/pages/login-layout/login-layout.module').then((m) => m.LoginLayoutModule),
  },
  {
    path: 'page',
    loadChildren: () => import('../theme/pages/pages.module').then((m) => m.PagesModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
