import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PagesRoutingModule } from './pages-routing.module';
import { WelcomeComponent } from './welcome/welcome.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
  declarations: [WelcomeComponent, UserInfoComponent, MenuComponent],
  imports: [CommonModule, PagesRoutingModule],
  exports: [WelcomeComponent],
})
export class PagesModule {}
