import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { WelcomeComponent } from './welcome/welcome.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { MenuComponent } from './menu/menu.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [WelcomeComponent, UserInfoComponent, MenuComponent, DashboardComponent],
  imports: [CommonModule, PagesRoutingModule],
  exports: [WelcomeComponent, DashboardComponent],
})
export class PagesModule {}
