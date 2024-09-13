import { NgModule } from '@angular/core';

import { PagesRoutingModule } from './pages-routing.module';
import { WelcomeComponent } from './welcome/welcome.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { MenuComponent } from './menu/menu.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ThemeModule } from '../theme.module';
import { NotfoundComponent } from './notfound/notfound.component';

@NgModule({
  declarations: [WelcomeComponent, UserInfoComponent, MenuComponent, DashboardComponent, NotfoundComponent],
  imports: [PagesRoutingModule, ThemeModule],
  exports: [DashboardComponent],
})
export class PagesModule {}
