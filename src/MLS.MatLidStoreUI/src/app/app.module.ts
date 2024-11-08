/*
 * Project: MatLidStore(https://github.com/phamtiendungcw/matlidstore)
 * File: app.module.ts
 * Author: phamtiendungcw(https://github.com/phamtiendungcw)
 * Created on: 15:34, 07/11/2024
 *
 * Copyright (c) 2024 Pham Tien Dung. All rights reserved.
 *
 * Description:
 *   This file is part of the MLS.MatLidStoreUI project.
 *   Unauthorized copying or distribution of this file, via any medium, is strictly prohibited.
 *
 * License: Proprietary and confidential.
 */

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ThemeModule } from './theme/theme.module';

@NgModule({
  declarations: [AppComponent],
  imports: [AppRoutingModule, BrowserAnimationsModule, BrowserModule, ThemeModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
