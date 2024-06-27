import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth.service'; 
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
  constructor(private authService: AuthService, private router: Router) {}
  
  selectedSection: string | null = null;
  username: string = '';
  password: string = '';
  accountTypes = ['Personal', 'Business', 'Youth', 'Seniors'];
  showOpenAccountSection: boolean = false;
  openSection(section: string): void {
    this.selectedSection = section;
  }

  closeSection(): void {
    this.selectedSection = null;
  }
  login(): void {
    this.authService.login(this.username, this.password).subscribe(success => {
      if (success) {
        const role = this.authService.getUserRole();
        if (role === 'admin') {
          this.router.navigate(['/admin']);
        } else if (role === 'user') {
          this.router.navigate(['/user']);
        }
      } else {
        alert('Invalid credentials');
      }
    });
  }
  openRegistrationForm() {
    this.router.navigate(['/registration']);
    //this.router.navigate(['/register']);
    //this.selectedSection = null;
  }
}
