import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterLink } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ToastrModule } from 'ngx-toastr';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { TableComponent } from './components/table/table.component';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, PaginationComponent, SearchInputComponent, TableComponent],
  imports: [
    CommonModule,
    RouterLink,
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
    NgbModule,
    ToastrModule,
    HeaderComponent,
    FooterComponent,
    PaginationComponent,
    SearchInputComponent,
    TableComponent,
  ],
})
export class ThemeModule {}
