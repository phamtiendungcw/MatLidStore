/*
 * Project: MatLidStore(https://github.com/phamtiendungcw/matlidstore)
 * File: admin.module.ts
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
import { ThemeModule } from 'src/app/theme/theme.module';

import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminRoutingModule } from './admin-routing.module';

@NgModule({
  declarations: [AdminHomeComponent],
  imports: [AdminRoutingModule, CommonModule, ThemeModule],
})
export class AdminModule {}
