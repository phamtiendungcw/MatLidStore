import { NgModule } from '@angular/core';

import { ThemeModule } from '../theme.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { MenuComponent } from './menu/menu.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { PagesRoutingModule } from './pages-routing.module';
import { ServerErrorComponent } from './server-error/server-error.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { WelcomeComponent } from './welcome/welcome.component';

@NgModule({
  declarations: [
    WelcomeComponent,
    UserInfoComponent,
    MenuComponent,
    DashboardComponent,
    NotfoundComponent,
    ServerErrorComponent,
    HomeComponent,
  ],
  imports: [PagesRoutingModule, ThemeModule],
  exports: [DashboardComponent, WelcomeComponent],
})
export class PagesModule {}
