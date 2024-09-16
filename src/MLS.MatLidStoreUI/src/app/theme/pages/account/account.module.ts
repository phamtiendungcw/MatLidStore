import { NgModule } from '@angular/core';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { ThemeModule } from '../../theme.module';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [AccountComponent],
  imports: [CommonModule, FormsModule, ThemeModule, AccountRoutingModule],
})
export class AccountModule {}
