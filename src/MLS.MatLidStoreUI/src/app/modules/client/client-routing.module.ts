/*
 * Project: MatLidStore(https://github.com/phamtiendungcw/matlidstore)
 * File: client-routing.module.ts
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

import { ClientHomeComponent } from './client-home/client-home.component';

const routes: Routes = [
  {
    path: '',
    component: ClientHomeComponent,
    children: [
      { path: '', redirectTo: 'welcome', pathMatch: 'full' },
      { path: '', loadChildren: () => import('../../theme/pages/pages.module').then((m) => m.PagesModule) },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ClientRoutingModule {}
