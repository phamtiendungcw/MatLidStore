import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppAdminModule } from './app-admin/app-admin.module';
import { HttpClientModule } from '@angular/common/http';
import { API_BASE_URL, MatLidStoreServices } from '../core/data/mls-data.service';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, AppAdminModule, HttpClientModule],
  providers: [MatLidStoreServices, { provide: API_BASE_URL, useValue: 'https://localhost:8100' }],
  bootstrap: [AppComponent],
})
export class AppModule {}
