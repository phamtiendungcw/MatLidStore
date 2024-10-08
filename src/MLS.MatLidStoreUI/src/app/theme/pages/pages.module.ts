import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ThemeModule } from '../theme.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { PagesRoutingModule } from './pages-routing.module';
import { ServerErrorComponent } from './server-error/server-error.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { WelcomeComponent } from './welcome/welcome.component';

@NgModule({
  declarations: [DashboardComponent, NotfoundComponent, ServerErrorComponent, UserInfoComponent, WelcomeComponent],
  imports: [CommonModule, PagesRoutingModule, ThemeModule],
})
export class PagesModule {}
