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
  private matlidapi = inject(MatLidStoreServices);
  private accountService = inject(AccountService);
  private router = inject(Router);
  users: any;
  loggerIn: boolean = false;

  constructor() {}

  ngOnInit(): void {
    if (this.loggerIn === false) {
      this.router.navigate(['/login']);
    } else {
      this.accountService.loggerIn$.subscribe((value) => {
        this.loggerIn = value;
        console.log('LoggerIn:', this.loggerIn);
        this.matlidapi.userAll().subscribe({
          next: (data) => {
            this.users = data;
          },
          error: (error) => console.log(error),
          complete: () => console.log('Request has completed.'),
        });
      });
    }
  }
}
