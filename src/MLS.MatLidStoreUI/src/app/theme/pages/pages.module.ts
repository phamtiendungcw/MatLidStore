import { NgModule } from '@angular/core';

import { ThemeModule } from '../theme.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MenuComponent } from './menu/menu.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { PagesRoutingModule } from './pages-routing.module';
import { UserInfoComponent } from './user-info/user-info.component';
import { WelcomeComponent } from './welcome/welcome.component';

@NgModule({
  declarations: [WelcomeComponent, UserInfoComponent, MenuComponent, DashboardComponent, NotfoundComponent],
  imports: [PagesRoutingModule, ThemeModule],
  exports: [DashboardComponent],
})
export class PagesModule {}
