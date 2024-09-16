import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppAdminModule } from './app-admin/app-admin.module';
import { AppClientModule } from './app-client/app-client.module';
import { API_BASE_URL, MatLidStoreAPIServices } from '../core/data/mls-data.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, NgbModule, AppAdminModule, AppClientModule],
  providers: [MatLidStoreAPIServices, { provide: API_BASE_URL, useValue: 'https://localhost:8100' }],
  bootstrap: [AppComponent],
})
export class AppModule {}
