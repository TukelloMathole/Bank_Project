import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent {
  constructor(private router: Router) {}
  selectedSection: string | null = null;
  accountTypes = ['Personal', 'Business', 'Youth', 'Seniors'];
  showOpenAccountSection: boolean = false;
  openSection(section: string): void {
    this.selectedSection = section;
  }

  closeSection(): void {
    this.selectedSection = null;
  }
  login(): void {
    // Add your login functionality here
  }
  openRegistrationForm() {
    this.router.navigate(['/registration']);
    this.selectedSection = null;
  }
}
