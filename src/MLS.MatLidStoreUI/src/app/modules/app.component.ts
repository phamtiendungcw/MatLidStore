import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../core/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {
  private accountService = inject(AccountService);
  private router = inject(Router);

  ngOnInit(): void {
    const token = this.accountService.getToken();

    if (token && !this.accountService.isTokenExpired(token)) {
      // Token hợp lệ, cho phép truy cập
      this.accountService.setLoggedIn(true);
      this.router.navigate(['/admin/home/dashboard']);
    } else {
      // Token hết hạn hoặc không tồn tại, yêu cầu đăng nhập lại
      this.accountService.removeCurrentUser();
      this.router.navigate(['/login']);
    }

    // Theo dõi sự thay đổi của trạng thái đăng nhập
    this.accountService.loggerIn$.subscribe(isLoggedIn => {
      if (isLoggedIn) {
        this.router.navigate(['/admin/home/dashboard']);
      } else {
        this.router.navigate(['/login']);
      }
    });
  }
}
