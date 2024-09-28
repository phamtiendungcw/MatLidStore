import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/core/services/account.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.scss'],
})
export class AdminHomeComponent implements OnInit {
  private accountService = inject(AccountService);
  private router = inject(Router);

  ngOnInit(): void {
    const token = this.accountService.getToken();
    const currentUrl = this.router.url;

    if (token && !this.accountService.isTokenExpired(token)) {
      this.accountService.setLoggedIn(true);
      this.router.navigate(['/admin/home/dashboard']);
    } else {
      this.accountService.removeCurrentUser();
      this.accountService.setLoggedIn(false);
      // Không điều hướng nếu đang ở trang login hoặc register
      if (currentUrl !== '/account/login' && currentUrl !== '/account/register') {
        this.router.navigate(['/account/login']);
      }
    }

    this.accountService.loggerIn$.subscribe(isLoggedIn => {
      if (isLoggedIn) {
        this.router.navigate(['/admin/home/dashboard']);
      } else if (currentUrl !== '/account/register') {
        // Chỉ điều hướng đến trang đăng nhập nếu không phải là trang đăng ký
        this.router.navigate(['/account/login']);
      }
    });
  }
}
