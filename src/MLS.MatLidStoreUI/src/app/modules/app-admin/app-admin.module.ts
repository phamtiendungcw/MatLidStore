import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppAdminRoutingModule } from './app-admin-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';

@NgModule({
  declarations: [AdminHomeComponent],
  imports: [CommonModule, AppAdminRoutingModule],
})
export class AppAdminModule {}
