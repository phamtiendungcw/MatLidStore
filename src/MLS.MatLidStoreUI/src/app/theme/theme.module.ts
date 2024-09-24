import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterLink } from '@angular/router';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { TableComponent } from './components/table/table.component';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, PaginationComponent, SearchInputComponent, TableComponent],
  imports: [CommonModule, RouterLink],
  exports: [HeaderComponent, FooterComponent, TableComponent],
})
export class ThemeModule {}
