import { Component, inject, OnInit } from '@angular/core';
import { LoginModel, MatLidStoreServices } from 'src/app/core/data/mls-data.service';

@Component({
  selector: 'app-login-layout',
  templateUrl: './login-layout.component.html',
  styleUrls: ['./login-layout.component.scss'],
})
export class LoginLayoutComponent implements OnInit {
  private loginService = inject(MatLidStoreServices);
  loggedIn = false;
  model: LoginModel = {};

  constructor() {}

  ngOnInit(): void {}

  loginClick() {
    this.loginService.login(this.model).subscribe({
      next: (data) => {
        this.loggedIn = true;
        console.log(this.loggedIn);
        console.log(data);
      },
      error: (error) => console.log(error),
      complete: () => console.log('Request has completed'),
    });
  }
}
