import { Component, inject, OnInit } from '@angular/core';
import { AccountService } from '../core/services/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {
  loggerIn = false;
  private accountService = inject(AccountService);
  private router = inject(Router);

  ngOnInit(): void {
    this.loggerIn = this.accountService.isLoggedIn();
    console.log('LoggerIn: ', this.loggerIn);

    if (!this.loggerIn) {
      this.router.navigate(['/login']);
    } else {
      this.router.navigate(['/admin/home/dashboard']);
    }

    this.accountService.loggerIn$.subscribe(value => {
      this.loggerIn = value;
      if (this.loggerIn) {
        this.router.navigate(['/admin/home/dashboard']);
      } else {
        this.router.navigate(['/login']);
      }
    });
  }
}
