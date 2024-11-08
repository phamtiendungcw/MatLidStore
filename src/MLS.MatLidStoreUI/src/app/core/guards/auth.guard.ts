/*
 * Project: MatLidStore (https://github.com/phamtiendungcw/matlidstore)
 * File: auth.guard.ts
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

import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

import { AccountService } from '../services/account.service';

export const authGuard: CanActivateFn = () => {
  const router = inject(Router);
  const accountService = inject(AccountService);

  if (accountService.getCurrentUser()) {
    return true;
  } else {
    router.navigate(['/account/login']);
    return false;
  }
};
