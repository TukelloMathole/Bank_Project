import { Component } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  selectedSection: string | null = null;
  accountTypes = ['Personal', 'Business', 'Youth', 'Seniors'];

  openSection(section: string): void {
    this.selectedSection = section;
  }

  closeSection(): void {
    this.selectedSection = null;
  }
  login(): void {
    // Add your login functionality here
  }
}
