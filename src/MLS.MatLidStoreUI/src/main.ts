/*
 * Project: MatLidStore (https://github.com/phamtiendungcw/matlidstore)
 * File: main.ts
 * Author: phamtiendungcw (https://github.com/phamtiendungcw)
 * Contact: Pham Tien Dung (phamtiendungcw@gmail.com)
 * Last Modified: Thứ Bảy, 09-11-2024 | 02:58 SA
 * --------
 * Copyright © 2023 - 2024 Pham Tien Dung, MatLidStore Ltd. All rights reserved.
 * --------
 * Description:
 *   This file is part of the MLS.MatLidStoreUI project.
 *   Unauthorized copying or distribution of this file, via any medium, is strictly prohibited.
 * --------
 * License: Proprietary and confidential.
 */

/// <reference types="@angular/localize" />

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';

platformBrowserDynamic()
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
