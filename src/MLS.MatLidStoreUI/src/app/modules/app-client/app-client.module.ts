import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppClientRoutingModule } from './app-client-routing.module';
import { ClientHomeComponent } from './client-home/client-home.component';
import { PagesModule } from 'src/app/theme/pages/pages.module';
import { ThemeModule } from 'src/app/theme/theme.module';

@NgModule({
  declarations: [ClientHomeComponent],
  imports: [CommonModule, AppClientRoutingModule, PagesModule, ThemeModule],
})
export class AppClientModule {}
