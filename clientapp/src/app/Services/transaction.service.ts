import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  private baseUrl = 'https://api.example.com/transactions'; // Replace with your API endpoint

  constructor(private http: HttpClient) {}

  getTransactions(): Observable<any> {
    return this.http.get(`${this.baseUrl}`);
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
