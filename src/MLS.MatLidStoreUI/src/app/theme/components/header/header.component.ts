import { Component, HostListener, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AccountService } from 'src/app/core/services/account.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  public logoUrl = '/assets/Images/MatLidStore_Logo.png';
  public isLoggedIn = false;
  public isLoginPage = false; // Kiểm tra xem có đang ở trang đăng nhập không
  isMenuOpened = false;
  isMenuProductOpened = false;
  currentRoute = '';

  constructor(
    private accountService: AccountService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.isLoggedIn = this.accountService.isLoggedIn();

    // Theo dõi thay đổi URL
    this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(() => {
      this.updateCurrentRoute();
      this.isLoginPage = this.currentRoute === '/account/login'; // Kiểm tra xem có phải trang đăng nhập không
    });

    this.updateCurrentRoute();
    this.isLoginPage = this.currentRoute === '/account/login';
  }

  toggleMenu(): void {
    this.isMenuOpened = !this.isMenuOpened;
  }

  toggleProductMenu(): void {
    this.isMenuProductOpened = !this.isMenuProductOpened;
    const button = document.querySelector('.toggle-product-menu-button') as HTMLButtonElement;
    if (button) {
      button.setAttribute('aria-expanded', String(this.isMenuProductOpened));
    }
  }

  logoutClick(): void {
    this.accountService.removeCurrentUser(); // Xóa token và đăng xuất
    this.router.navigate(['/account/login']);
  }

  loginClick(): void {
    if (this.currentRoute === '/account/login') {
      this.router.navigate(['/account/register']).then(() => {
        this.isMenuOpened = false;
        this.isMenuProductOpened = false;
      });
    } else {
      this.router.navigate(['/account/login']).then(() => {
        this.isMenuOpened = false;
        this.isMenuProductOpened = false;
      });
    }
  }

  @HostListener('document:click', ['$event'])
  onClick(event: Event): void {
    if (this.isClickOutside(event.target as HTMLElement)) {
      this.isMenuOpened = false;
      this.isMenuProductOpened = false;
    }
  }

  // Helpers
  private updateCurrentRoute(): void {
    this.currentRoute = this.router.url || '';
  }

  private isClickOutside(target: HTMLElement): boolean {
    return (
      !target.closest('.menu-container') &&
      !target.closest('.toggle-menu-button') &&
      !target.closest('.toggle-product-menu-button')
    );
  }

  getHeaderText(): string {
    return this.currentRoute === '/account/login' ? 'Đăng ký' : 'Đăng nhập';
  }
}
