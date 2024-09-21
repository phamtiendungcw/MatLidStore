import { NgModule } from '@angular/core';

import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ThemeModule } from '../../theme.module';
import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { RegisterComponent } from './register/register.component';

@NgModule({
  declarations: [AccountComponent, RegisterComponent],
  imports: [CommonModule, FormsModule, ThemeModule, AccountRoutingModule],
})
export class AccountModule {}
