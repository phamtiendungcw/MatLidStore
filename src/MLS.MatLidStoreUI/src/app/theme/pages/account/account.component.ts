import { Component, inject } from '@angular/core';
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
  private matlidstoreapi = inject(MatLidStoreAPIServices);
  private router = inject(Router);
  private accountService = inject(AccountService);

  togglePassword() {
    this.showPassword = !this.showPassword;
  }

  loginClick() {
    this.matlidstoreapi.login(this.model).subscribe({
      next: response => {
        this.user = response;
        console.log('User: ', this.user);
        this.loggedIn = true;
        this.accountService.setLoggedIn(this.loggedIn);

        if (this.loggedIn) {
          this.router.navigate(['/admin/home/dashboard']).then(r => r.valueOf());
        }
      },
      error: error => console.log(error),
      complete: () => console.log('Request has completed.'),
    });
  }
}
