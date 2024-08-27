import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppAdminModule } from './app-admin/app-admin.module';
import { HttpClientModule } from '@angular/common/http';
import { MatLidStoreServices } from '../core/data/mls-data.service';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, AppAdminModule, HttpClientModule],
  providers: [MatLidStoreServices],
  bootstrap: [AppComponent],
})
export class AppModule {}
