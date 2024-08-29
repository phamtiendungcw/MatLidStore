import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginLayoutRoutingModule } from './login-layout-routing.module';
import { LoginLayoutComponent } from './login-layout.component';
import { FormsModule } from '@angular/forms';
import { API_BASE_URL, MatLidStoreServices } from 'src/app/core/data/mls-data.service';

@NgModule({
  declarations: [LoginLayoutComponent],
  imports: [CommonModule, LoginLayoutRoutingModule, FormsModule],
  providers: [MatLidStoreServices, { provide: API_BASE_URL, useValue: 'https://localhost:8100' }],
})
export class LoginLayoutModule {}
