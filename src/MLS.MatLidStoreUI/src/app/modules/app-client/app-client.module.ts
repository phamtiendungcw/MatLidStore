import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { PagesModule } from 'src/app/theme/pages/pages.module';
import { ThemeModule } from 'src/app/theme/theme.module';
import { AppClientRoutingModule } from './app-client-routing.module';
import { ClientHomeComponent } from './client-home/client-home.component';

@NgModule({
  declarations: [ClientHomeComponent],
  imports: [CommonModule, AppClientRoutingModule, PagesModule, ThemeModule],
})
export class AppClientModule {}
