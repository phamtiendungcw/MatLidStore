import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  public logoUrl: string = '';
  constructor() {}

  ngOnInit(): void {
    this.logoUrl = `${environment.imageUrl}/Logo_MatLidStore.jpg`;
  }
}
