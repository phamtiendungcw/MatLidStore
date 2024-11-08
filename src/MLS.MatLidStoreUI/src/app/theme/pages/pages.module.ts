/*
 * Project: MatLidStore (https://github.com/phamtiendungcw/matlidstore)
 * File: pages.module.ts
 * Author: phamtiendungcw (https://github.com/phamtiendungcw)
 * Contact: Pham Tien Dung (phamtiendungcw@gmail.com)
 * Last Modified: Thứ Bảy, 09-11-2024 | 02:57 SA
 * --------
 * Copyright © 2023 - 2024 Pham Tien Dung, MatLidStore Ltd. All rights reserved.
 * --------
 * Description:
 *   This file is part of the MLS.MatLidStoreUI project.
 *   Unauthorized copying or distribution of this file, via any medium, is strictly prohibited.
 * --------
 * License: Proprietary and confidential.
 */

import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ThemeModule } from '../theme.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { PagesRoutingModule } from './pages-routing.module';
import { ServerErrorComponent } from './server-error/server-error.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { WelcomeComponent } from './welcome/welcome.component';

@NgModule({
  declarations: [DashboardComponent, NotfoundComponent, ServerErrorComponent, UserInfoComponent, WelcomeComponent],
  imports: [CommonModule, PagesRoutingModule, ThemeModule],
})
export class PagesModule {}
