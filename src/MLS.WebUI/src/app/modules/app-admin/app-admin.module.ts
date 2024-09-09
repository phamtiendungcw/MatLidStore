import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppAdminRoutingModule } from './app-admin-routing.module';
import { ThemeModule } from '../../theme/theme.module';
import { PagesModule } from '../../theme/pages/pages.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';

@NgModule({
  declarations: [AdminHomeComponent],
  imports: [CommonModule, AppAdminRoutingModule, ThemeModule, PagesModule],
})
export class AppAdminModule {}
