import { Component } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss'],
})
export class FooterComponent {
  onGitHubClick(): void {
    window.open('https://github.com/phamtiendungcw/MatLidStore', '_blank');
  }
}
