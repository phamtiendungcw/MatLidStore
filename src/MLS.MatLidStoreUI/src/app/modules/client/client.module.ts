import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ThemeModule } from 'src/app/theme/theme.module';

import { ClientHomeComponent } from './client-home/client-home.component';
import { ClientRoutingModule } from './client-routing.module';

@NgModule({
  declarations: [ClientHomeComponent],
  imports: [ClientRoutingModule, CommonModule, ThemeModule],
})
export class ClientModule {}
