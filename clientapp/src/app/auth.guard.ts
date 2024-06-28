import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const currentUser = this.authService.getCurrentUser();
    if (currentUser) {
      const expectedRole = route.data['role'];
      console.log(expectedRole === currentUser.role);
      if (!expectedRole || expectedRole === currentUser.role.toLowerCase()) {
        return true;
      } else {
        this.router.navigate(['/unauthorized']);
        return false;
      }
    }

    this.router.navigate(['/login']);
    return false;
  }
}
