import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  private baseUrl = 'https://localhost:7066/api/transactions'; // Replace with your API endpoint

  constructor(private http: HttpClient, private authService: AuthService) { }

  getTransactions(): Observable<any> {
    const currentUser = this.authService.getCurrentUser();
  
    if (currentUser && currentUser.customerId) {
      const userDetails = {
        Customer_ID: currentUser.customerId
      };
      console.log(userDetails);
      const token = currentUser.token;
      if (!token) {
        throw new Error('Token not found.');
      }
  
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
      return this.http.post<any>(this.baseUrl, userDetails, { headers });
    } else {
      throw new Error('Customer ID not found.');
    }
  }

  transferFunds(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/transfer`, data);
  }

  setRecurringTransaction(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/recurring`, data);
  }

  getRecurringTransactions(): Observable<any> {
    return this.http.get(`${this.baseUrl}/recurring`);
  }
}
