import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthRequest, AuthResponse, MatLidStoreAPIServices } from 'src/app/core/data/mls-data.service';
import { AccountService } from 'src/app/core/services/account.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.scss', '../../styles/motion-tailwind.css'],
})
export class AccountComponent {
  loggedIn = false;
  model: AuthRequest = new AuthRequest();
  user: AuthResponse | null = null;
  showPassword = false;

  constructor(
    private matlidstoreapi: MatLidStoreAPIServices,
    private router: Router,
    private accountService: AccountService
  ) {}

  togglePassword(): void {
    this.showPassword = !this.showPassword;
  }

  loginClick(): void {
    if (!this.model.username || !this.model.password) {
      console.error('User name and password are required');
      return;
    }

    this.matlidstoreapi.login(this.model).subscribe({
      next: (response: AuthResponse) => {
        this.user = response;
        console.log('User: ', this.user);
        this.accountService.setCurrentUser(this.user);
        // Cập nhật trạng thái đăng nhập
        this.loggedIn = this.accountService.isLoggedIn();
        console.log('Logged In: ', this.loggedIn);
        if (this.loggedIn) {
          // Điều hướng tới dashboard nếu đăng nhập thành công
          this.router.navigate(['/admin/home/dashboard']).then(r => r.valueOf());
        }
      },
      error: error => {
        console.error('Login failed: ', error);
      },
      complete: () => console.log('Login request completed.'),
    });
  }
}
