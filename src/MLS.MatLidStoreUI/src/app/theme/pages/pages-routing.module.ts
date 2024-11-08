/*
 * Project: MatLidStore(https://github.com/phamtiendungcw/matlidstore)
 * File: pages-routing.module.ts
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

import { DashboardComponent } from './dashboard/dashboard.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { UserInfoComponent } from './user-info/user-info.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  { path: 'user-info', component: UserInfoComponent },
  { path: 'welcome', component: WelcomeComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: '**', component: NotfoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
