import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: AccountComponent }, // Hiển thị AccountComponent làm trang đăng nhập
  { path: 'register', component: RegisterComponent }, // Hiển thị RegisterComponent làm trang đăng ký
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AccountRoutingModule {}
