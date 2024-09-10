import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SearchInputComponent } from './components/search-input/search-input.component';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    PaginationComponent,
    SearchInputComponent,
  ],
  imports: [CommonModule],
})
export class ThemeModule {}
