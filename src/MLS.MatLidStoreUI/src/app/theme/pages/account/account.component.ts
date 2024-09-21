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
  loading = false;
  errorMessage: string | null = null;

  constructor(
    private matlidstoreapi: MatLidStoreAPIServices,
    private router: Router,
    private accountService: AccountService
  ) {}

  togglePassword(): void {
    this.showPassword = !this.showPassword;
  }

  loginClick(): void {
    this.errorMessage = null;

    if (!this.model.username || !this.model.password) {
      this.errorMessage = 'User name and password are required';
      console.error(this.errorMessage);
      return;
    }

    this.loading = true;

    this.matlidstoreapi.login(this.model).subscribe({
      next: (response: AuthResponse) => {
        this.user = response;
        console.log('User: ', this.user);
        this.accountService.setCurrentUser(this.user);
        this.loggedIn = this.accountService.isLoggedIn();
        console.log('Logged In: ', this.loggedIn);

        if (this.loggedIn) {
          this.router.navigate(['/admin/home/dashboard']).then(() => {
            this.loading = false;
          });
        } else {
          this.errorMessage = 'Failed to log in. Please try again.';
          this.loading = false;
        }
      },
      error: error => {
        this.errorMessage = 'Login failed: ' + error.message;
        console.error(this.errorMessage);
        this.loading = false;
      },
      complete: () => console.log('Login request completed.'),
    });
  }
}
