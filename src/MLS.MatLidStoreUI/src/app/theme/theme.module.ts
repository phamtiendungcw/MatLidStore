import { NgModule } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SearchInputComponent } from './components/search-input/search-input.component';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, PaginationComponent, SearchInputComponent],
  imports: [],
  exports: [HeaderComponent, FooterComponent],
})
export class ThemeModule {}
