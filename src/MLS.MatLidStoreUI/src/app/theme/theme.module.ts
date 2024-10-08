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
