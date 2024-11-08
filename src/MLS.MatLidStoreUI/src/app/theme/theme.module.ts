/*
 * Project: MatLidStore (https://github.com/phamtiendungcw/matlidstore)
 * File: theme.module.ts
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
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';

import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { AdminNavbarComponent } from './components/navbars/admin-navbar/admin-navbar.component';
import { ClientNavbarComponent } from './components/navbars/client-navbar/client-navbar.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TableComponent } from './components/table/table.component';

@NgModule({
  declarations: [
    AdminNavbarComponent,
    ClientNavbarComponent,
    FooterComponent,
    HeaderComponent,
    PaginationComponent,
    SidebarComponent,
    TableComponent,
  ],
  imports: [
    CommonModule,
    FontAwesomeModule,
    NgbModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      timeOut: 2000,
      maxOpened: 2,
      preventDuplicates: true,
      closeButton: true,
      tapToDismiss: true,
      newestOnTop: true,
      progressBar: true,
      autoDismiss: true,
    }),
  ],
  exports: [
    AdminNavbarComponent,
    ClientNavbarComponent,
    FontAwesomeModule,
    FooterComponent,
    HeaderComponent,
    PaginationComponent,
    SidebarComponent,
    TableComponent,
  ],
})
export class ThemeModule {}
