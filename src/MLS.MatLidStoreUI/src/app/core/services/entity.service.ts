import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class EntityService {
  private baseUrl = 'https://your-api-endpoint.com/api'; // Thay đổi base URL thành API của bạn

  constructor(private http: HttpClient) {}

  getEntities(entityName: string) {
    return this.http.get(`${this.baseUrl}/${entityName}`);
  }
}
