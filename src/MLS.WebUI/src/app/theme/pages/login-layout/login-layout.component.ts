import { Component, inject, OnInit } from '@angular/core';
import { LoginModel, MatLidStoreServices, UserDetailsDto } from 'src/app/core/data/mls-data.service';

@Component({
  selector: 'app-login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['./login-layout.component.scss'],
})
export class LoginLayoutComponent implements OnInit {
  loggedIn = false;
  model: LoginModel = new LoginModel();
  user: UserDetailsDto | null = null;
  private matlidapi = inject(MatLidStoreServices);

  constructor() {}

  ngOnInit(): void {}

  loginClick() {
    this.matlidapi.login(this.model).subscribe({
      next: (response) => {
        this.user = response;
        this.loggedIn = true;
        console.log(this.user);
        console.log(this.loggedIn);
      },
      error: (error) => console.log(error),
      complete: () => console.log('This request is complete'),
    });
  }
}
