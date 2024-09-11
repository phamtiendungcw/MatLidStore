import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'admin', loadChildren: () => import('./app-admin/app-admin.module').then(m => m.AppAdminModule) },
  { path: 'client', loadChildren: () => import('./app-client/app-client.module').then(m => m.AppClientModule) },
  { path: '', redirectTo: '/admin', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
