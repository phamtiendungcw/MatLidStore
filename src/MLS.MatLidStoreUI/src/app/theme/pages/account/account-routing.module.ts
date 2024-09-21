import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'login', component: AccountComponent }, // Hiển thị AccountComponent làm trang đăng nhập
  { path: 'register', component: RegisterComponent }, // Hiển thị RegisterComponent làm trang đăng ký
  { path: '', redirectTo: 'login', pathMatch: 'full' }, // Mặc định chuyển hướng tới trang đăng nhập
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
