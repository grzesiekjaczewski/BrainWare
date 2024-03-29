import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ApiService } from './api.service';

@Component({
  standalone: true,
  imports: [CommonModule, RouterModule],
  selector: 'web-app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  orders: any[] = [];
  year = new Date().getFullYear();
  title: string = 'List of orders';

  constructor(private apiService: ApiService) {
    this.fetchOrders();
  }

  private fetchOrders(): void {
    this.apiService.getOrders(1).subscribe((data) => {
      this.orders = data;
    });
  }
}
