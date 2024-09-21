import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { RouterModule } from '@angular/router';
import { ThemeModule } from 'src/app/theme/theme.module';
import { PagesModule } from '../../theme/pages/pages.module';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AppAdminRoutingModule } from './app-admin-routing.module';

@NgModule({
  declarations: [AdminHomeComponent],
  imports: [CommonModule, RouterModule, AppAdminRoutingModule, PagesModule, ThemeModule],
})
export class AppAdminModule {}
