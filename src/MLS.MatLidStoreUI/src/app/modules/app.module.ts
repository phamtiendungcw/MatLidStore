import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppAdminModule } from './app-admin/app-admin.module';
import { AppClientModule } from './app-client/app-client.module';

@NgModule({
  declarations: [AppComponent],
  imports: [BrowserModule, AppRoutingModule, NgbModule, AppAdminModule, AppClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
