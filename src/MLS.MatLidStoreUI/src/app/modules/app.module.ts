import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { API_BASE_URL, MatLidStoreAPIServices } from '../core/data/mls-data.service';
import { ThemeModule } from '../theme/theme.module';
import { AppAdminModule } from './app-admin/app-admin.module';
import { AppClientModule } from './app-client/app-client.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    AppAdminModule,
    AppClientModule,
    ThemeModule,
  ],
  providers: [MatLidStoreAPIServices, { provide: API_BASE_URL, useValue: 'https://localhost:8100' }],
  bootstrap: [AppComponent],
})
export class AppModule {}
