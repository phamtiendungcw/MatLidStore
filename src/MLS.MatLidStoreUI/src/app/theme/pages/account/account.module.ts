import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ThemeModule } from '../../theme.module';
import { AccountRoutingModule } from './account-routing.module';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';

@NgModule({
  declarations: [LoginPageComponent, RegisterPageComponent],
  imports: [AccountRoutingModule, CommonModule, ThemeModule],
})
export class AccountModule {}
