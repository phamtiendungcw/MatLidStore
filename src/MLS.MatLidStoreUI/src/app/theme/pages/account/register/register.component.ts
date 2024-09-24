import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { MatLidStoreAPIServices, RegisterUserCommand, RegistrationRequest } from 'src/app/core/data/mls-data.service';

export class RegistrationResponse {
  userId: number;

  constructor(userId: number) {
    this.userId = userId;
  }
}

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent {
  model: RegistrationRequest = new RegistrationRequest();
  showPassword = false;

  constructor(
    private matlidstoreapi: MatLidStoreAPIServices,
    private router: Router
  ) {}

  togglePassword(): void {
    this.showPassword = !this.showPassword;
  }

  registerClick(): void {
    if (!this.model.username || !this.model.password) {
      console.error('Username and password are required');
      return;
    }

    // Tạo đối tượng RegisterUserCommand
    const registerCommand = new RegisterUserCommand({
      registrationUser: this.model,
    });

    this.matlidstoreapi.register(registerCommand).subscribe({
      next: () => {
        console.log('Registration successful');
        // Redirect or show success message
        this.router.navigate(['/account/login']);
      },
      error: error => {
        console.error('Registration failed: ', error);
      },
    });
  }
}
