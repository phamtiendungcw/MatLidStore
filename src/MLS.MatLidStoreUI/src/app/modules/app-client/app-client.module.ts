import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppClientRoutingModule } from './app-client-routing.module';
import { ClientHomeComponent } from './client-home/client-home.component';

@NgModule({
  declarations: [ClientHomeComponent],
  imports: [CommonModule, AppClientRoutingModule],
})
export class AppClientModule {}
