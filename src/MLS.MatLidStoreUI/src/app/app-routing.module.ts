/*
 * Project: MatLidStore(https://github.com/phamtiendungcw/matlidstore)
 * File: app-routing.module.ts
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
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', redirectTo: 'matlidstore/admin', pathMatch: 'full' },
  {
    path: 'matlidstore/admin',
    loadChildren: () => import('./modules/admin/admin.module').then((m) => m.AdminModule),
  },
  {
    path: 'matlidstore',
    loadChildren: () => import('./modules/client/client.module').then((m) => m.ClientModule),
  },
  { path: 'account', loadChildren: () => import('./theme/pages/account/account.module').then((m) => m.AccountModule) },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
