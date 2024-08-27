import { Component, inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatLidStoreServices } from '../core/data/mls-data.service';

@Component({
  selector: 'app-main',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  http = inject(HttpClient);
  users: any;

  constructor(private matlidapi: MatLidStoreServices) {}

  ngOnInit(): void {
    this.matlidapi.userAll().subscribe({
      next: (data) => {
        this.users = data;
      },
      error: (error) => console.log(error),
      complete: () => console.log('Request has completed'),
    });
  }
}
