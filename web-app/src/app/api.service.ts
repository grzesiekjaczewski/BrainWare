import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiRoot: string = 'http://localhost:54730/api/' 
  constructor(private http: HttpClient) { }

  getOrders(orderId: number): Observable<any> {
    return this.http.get(this.apiRoot + 'order/' + orderId);
  }
}
