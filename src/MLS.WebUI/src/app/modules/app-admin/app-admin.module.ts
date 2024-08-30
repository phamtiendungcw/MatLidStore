import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppAdminRoutingModule } from './app-admin-routing.module';
import { HomeComponent } from './home/home.component';
import { ThemeModule } from '../../theme/theme.module';
import { PagesModule } from '../../theme/pages/pages.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [CommonModule, AppAdminRoutingModule, ThemeModule, PagesModule],
})
export class AppAdminModule {}
