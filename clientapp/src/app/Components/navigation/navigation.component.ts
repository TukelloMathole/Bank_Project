import { Component } from '@angular/core';
import { Router } from '@angular/router';
import {
  trigger,
  state,
  style,
  animate,
  transition
} from '@angular/animations';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css'],
  animations: [
    trigger('sectionAnimation', [
      state('void', style({
        height: '0px',
        opacity: 0
      })),
      state('*', style({
        height: '*',
        opacity: 1
      })),
      transition('void <=> *', animate('300ms ease-in-out'))
    ])
  ]
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
    //this.router.navigate(['/register']);
    //this.selectedSection = null;
  }
}
