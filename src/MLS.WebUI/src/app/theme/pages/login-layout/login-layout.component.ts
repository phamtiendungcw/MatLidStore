import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/core/data/account.service';
import { LoginModel, MatLidStoreServices, UserDetailsDto } from 'src/app/core/data/mls-data.service';

@Component({
  selector: 'app-login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['./login-layout.component.scss'],
})
export class LoginLayoutComponent {
  loggedIn = false;
  model: LoginModel = new LoginModel();
  user: UserDetailsDto | null = null;
  private matlidapi = inject(MatLidStoreServices);
  private router = inject(Router);
  private accountService = inject(AccountService);

  loginClick() {
    this.matlidapi.login(this.model).subscribe({
      next: (response) => {
        this.user = response;
        this.loggedIn = true;
        this.accountService.setLoggedIn(this.loggedIn);
        if (this.loggedIn) {
          this.router.navigate(['/admin/home']);
        }
      },
      error: (error) => console.log(error),
      complete: () => console.log('Request has completed.'),
    });
  }
}
