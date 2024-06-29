import { Component } from '@angular/core';
import { AuthService } from '../..//auth.service';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html'
})
export class UserComponent { 
  constructor(private authService: AuthService) {}

  logout() {
    this.authService.logout();
  }
}



