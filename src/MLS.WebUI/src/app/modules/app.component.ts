import { Component, inject, OnInit } from '@angular/core';
import { MatLidStoreServices } from '../core/data/mls-data.service';
import { AccountService } from '../core/data/account.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  users: any;
  loggerIn: boolean = false;
  private matlidapi = inject(MatLidStoreServices);
  private accountService = inject(AccountService);
  private router = inject(Router);

  constructor() {}

  ngOnInit(): void {
    if (!this.loggerIn) {
      this.router.navigate(['/login']).then((r) => r.valueOf());
    } else {
      this.accountService.loggerIn$.subscribe((value) => {
        this.loggerIn = value;
        console.log('LoggerIn:', this.loggerIn);
        this.matlidapi.userAll().subscribe({
          next: (data) => {
            this.users = data;
            console.log('Users:', this.users);
          },
          error: (error) => console.log(error),
          complete: () => console.log('Request has completed.'),
        });
      });
    }
  }
}
