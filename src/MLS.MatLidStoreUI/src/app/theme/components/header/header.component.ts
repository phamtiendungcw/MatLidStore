import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/core/services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  public logoUrl = '/assets/Images/MatLidStore_Logo.png';
  public isLoggedIn = this.accountServices.isLoggedIn();
  isMenuOpened = false;
  isMenuProductOpened = false;

  constructor(
    private accountServices: AccountService,
    private router: Router
  ) {}

  toggleMenu() {
    this.isMenuOpened = !this.isMenuOpened;
  }

  toggleProductMenu() {
    this.isMenuProductOpened = !this.isMenuProductOpened;
  }

  logoutClick() {
    this.router.navigate(['/login']);
    this.accountServices.setLoggedIn(false);
  }

  loginClick() {
    this.router.navigate(['/login']);
  }

  @HostListener('document:click', ['$event'])
  onClick(event: Event) {
    const target = event.target as HTMLElement;

    // Kiểm tra nếu click nằm ngoài phần tử menu và các nút toggle menu
    const isClickOutsideMenu =
      !target.closest('.menu-container') &&
      !target.closest('.toggle-menu-button') &&
      !target.closest('.toggle-product-menu-button'); // Thêm class của các nút mở menu

    if (isClickOutsideMenu) {
      this.isMenuOpened = false;
      this.isMenuProductOpened = false;
    }
  }
}
