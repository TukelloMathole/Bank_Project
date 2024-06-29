import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7066/api'; // Replace with your API URL
  private tokenKey = 'authToken';

  constructor(private http: HttpClient, private router: Router) {}

  login(username: string, password: string): Observable<boolean> {
    return this.http.post<{ token: string, role: string }>(`${this.apiUrl}/login`, { username, password })
      .pipe(
        map(response => {
          
          if (response && response.token && response.role) {
            localStorage.setItem(this.tokenKey, response.token);
            return true;
          }
          return false;
        }),
        catchError(error => {
          console.error('Login error:', error);
          return of(false);
        })
      );
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
    this.router.navigate(['/login']);
  }

  getCurrentUser(): { role: string, customerId: string } | null {
    const token = localStorage.getItem(this.tokenKey);

    if (token) {
      try {
        const payload = JSON.parse(atob(token.split('.')[1]));
        const currentTime = Math.floor(Date.now() / 1000); // Current time in seconds
        if (payload.exp && payload.exp > currentTime) {
          // Token is valid
          return {
            role: payload.role,
            customerId: payload.Customer_ID // Assuming Customer_ID is part of the token payload
          };
        } else {
          console.log('Token has expired.');
          // Handle token expiration or refresh here
          return null;
        }
      } catch (error) {
        console.error('Token decoding error:', error);
        return null;
      }
    }
    return null;
  }

  isLoggedIn() {
    return !!localStorage.getItem(this.tokenKey);
  }

  getUserRole() {
    const user = this.getCurrentUser();
    return user ? user.role : null;
  }
}
