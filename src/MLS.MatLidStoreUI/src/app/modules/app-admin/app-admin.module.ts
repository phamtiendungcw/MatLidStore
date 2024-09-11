import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppAdminRoutingModule } from './app-admin-routing.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { PagesModule } from '../../theme/pages/pages.module';
import { ThemeModule } from 'src/app/theme/theme.module';

@NgModule({
  declarations: [AdminHomeComponent],
  imports: [CommonModule, AppAdminRoutingModule, PagesModule, ThemeModule],
})
export class AppAdminModule {}
