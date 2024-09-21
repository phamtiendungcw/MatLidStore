import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  { path: 'dashboard', component: DashboardComponent }, // Hiển thị Dashboard cho admin
  { path: 'welcome', component: WelcomeComponent }, // Hiển thị Welcome cho client
  { path: '**', component: NotfoundComponent, pathMatch: 'full' }, // Trang NotFound khi không có đường dẫn khớp
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
