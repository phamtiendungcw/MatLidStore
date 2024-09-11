import { NgModule } from '@angular/core';

import { AccountRoutingModule } from './account-routing.module';
import { AccountComponent } from './account.component';
import { ThemeModule } from '../../theme.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AccountComponent],
  imports: [FormsModule, ThemeModule, AccountRoutingModule],
})
export class AccountModule {}
