import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss', '../../styles/tailwind.css'],
})
export class FooterComponent {
  date = new Date().getFullYear();
}
