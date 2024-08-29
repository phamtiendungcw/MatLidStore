import { NgModule } from '@angular/core';
import { CommonModule, NgOptimizedImage } from '@angular/common';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { SearchInputComponent } from './components/search-input/search-input.component';
import { RouterLinkWithHref } from '@angular/router';

@NgModule({
  declarations: [HeaderComponent, FooterComponent, PaginationComponent, SearchInputComponent],
  imports: [CommonModule, NgOptimizedImage, RouterLinkWithHref],
  exports: [HeaderComponent, FooterComponent],
})
export class ThemeModule {}
