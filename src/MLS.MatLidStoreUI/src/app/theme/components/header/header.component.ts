import { Component, HostListener, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AccountService } from 'src/app/core/services/account.service';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  public logoUrl = '/assets/Images/MatLidStore_Logo.png';
  public isLoggedIn = this.accountServices.isLoggedIn();
  isMenuOpened = false;
  isMenuProductOpened = false;
  currentRoute = '';

  constructor(
    private accountServices: AccountService,
    private router: Router
  ) {}
  ngOnInit() {
    this.isLoggedIn = this.accountServices.isLoggedIn();
    this.router.events.pipe(filter(event => event instanceof NavigationEnd)).subscribe(() => {
      this.updateCurrentRoute();
    });
    this.updateCurrentRoute();
  }

  private updateCurrentRoute(): void {
    this.currentRoute = this.router.url || '';
  }

  toggleMenu() {
    this.isMenuOpened = !this.isMenuOpened;
  }

  toggleProductMenu() {
    this.isMenuProductOpened = !this.isMenuProductOpened;
    const button = document.querySelector('.toggle-product-menu-button') as HTMLButtonElement;
    if (button) {
      button.setAttribute('aria-expanded', String(this.isMenuProductOpened));
    }
  }

  logoutClick() {
    this.router.navigate(['/login']).then(() => {
      this.isMenuOpened = false;
      this.isMenuProductOpened = false;
      this.accountServices.setLoggedIn(false);
    });
  }

  loginClick() {
    if (this.currentRoute === '/login') {
      this.router.navigate(['/register']).then(() => {
        this.isMenuOpened = false;
        this.isMenuProductOpened = false;
      });
    } else {
      this.router.navigate(['/login']).then(() => {
        this.isMenuOpened = false;
        this.isMenuProductOpened = false;
      });
    }
  }

  @HostListener('document:click', ['$event'])
  onClick(event: Event) {
    if (this.isClickOutside(event.target as HTMLElement)) {
      this.isMenuOpened = false;
      this.isMenuProductOpened = false;
    }
  }

  private isClickOutside(target: HTMLElement): boolean {
    return (
      !target.closest('.menu-container') &&
      !target.closest('.toggle-menu-button') &&
      !target.closest('.toggle-product-menu-button')
    );
  }

  getHeaderText(): string {
    return this.currentRoute === '/login' ? 'Đăng ký' : 'Đăng nhập';
  }
}
