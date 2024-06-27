import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../..//auth.service'; // Adjust the import path as per your project structure

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username: string = ''; // Initialize username
  password: string = ''; // Initialize password

  constructor(private authService: AuthService, private router: Router) {}

  login() {
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
}
