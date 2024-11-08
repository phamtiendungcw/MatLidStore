/*
 * Project: MatLidStore(https://github.com/phamtiendungcw/matlidstore)
 * File: account.module.ts
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

import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ThemeModule } from '../../theme.module';
import { AccountRoutingModule } from './account-routing.module';
import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';

@NgModule({
  declarations: [LoginPageComponent, RegisterPageComponent],
  imports: [AccountRoutingModule, CommonModule, ThemeModule],
})
export class AccountModule {}
