import { NgModule } from '@angular/core';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { RouterLink } from '@angular/router';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, PaginationComponent, SearchInputComponent],
  imports: [RouterLink],
  exports: [HeaderComponent, FooterComponent],
})
export class ThemeModule {}
