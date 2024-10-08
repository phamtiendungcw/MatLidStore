import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ThemeModule } from 'src/app/theme/theme.module';

import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminRoutingModule } from './admin-routing.module';

@NgModule({
  declarations: [AdminHomeComponent],
  imports: [AdminRoutingModule, CommonModule, ThemeModule],
})
export class AdminModule {}
