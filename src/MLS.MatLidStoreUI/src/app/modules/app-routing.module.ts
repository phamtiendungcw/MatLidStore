import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: '/admin/home/dashboard', pathMatch: 'full' }, // Mặc định chuyển hướng tới dashboard
  { path: 'admin', loadChildren: () => import('./app-admin/app-admin.module').then(m => m.AppAdminModule) }, // Lazy load admin
  { path: 'client', loadChildren: () => import('./app-client/app-client.module').then(m => m.AppClientModule) }, // Lazy load client
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
