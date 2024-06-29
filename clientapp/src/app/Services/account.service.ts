// account.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; // Import HttpClient for HTTP requests
import { Observable } from 'rxjs'; // Import Observable for handling asynchronous operations
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root' // Specifies that the service should be provided at the root level
})
export class AccountService {
  private baseUrl = 'http://your-api-base-url/api/accounts'; // Adjust with your actual API base URL

  constructor(private http: HttpClient, private authService: AuthService) {}

  getAccountDetails(): Observable<any> {
    const currentUser = this.authService.getCurrentUser();
    if (currentUser && currentUser.customerId) {
      return this.http.get(`${this.baseUrl}/details/${currentUser.customerId}`);
    } else {
      throw new Error('User not authenticated or customerId not available.');
    }
  }
//   getAccountDetails(customerId: string): Observable<any> {
//     return this.http.get(`${this.baseUrl}/details/${customerId}`);
//   }
  getAccountSettings(): Observable<any> {
    const currentUser = this.authService.getCurrentUser();
    if (currentUser && currentUser.customerId) {
      return this.http.get(`${this.baseUrl}/settings/${currentUser.customerId}`);
    } else {
      throw new Error('User not authenticated or customerId not available.');
    }
  }

  getAccountAlerts(): Observable<any> {
    const currentUser = this.authService.getCurrentUser();
    if (currentUser && currentUser.customerId) {
      return this.http.get(`${this.baseUrl}/alerts/${currentUser.customerId}`);
    } else {
      throw new Error('User not authenticated or customerId not available.');
    }
  }

  updateAccountSettings(settings: any): Observable<any> {
    const currentUser = this.authService.getCurrentUser();
    if (currentUser && currentUser.customerId) {
      return this.http.put(`${this.baseUrl}/settings/${currentUser.customerId}`, settings);
    } else {
      throw new Error('User not authenticated or customerId not available.');
    }
  }
}