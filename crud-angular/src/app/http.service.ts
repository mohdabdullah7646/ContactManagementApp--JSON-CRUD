import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { IEmployee } from './interfaces/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  private apiUrl = 'http://localhost:5280/api/employee';
  http = inject(HttpClient);
  constructor() {}

  getAllEmployee(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(this.apiUrl);
  }

  createEmployee(employee: IEmployee): Observable<any> {
    console.log('Creating employee:', employee);
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post(this.apiUrl, employee, { headers });
  }

  getEmployee(employeeId: number): Observable<IEmployee> {
    const url = `${this.apiUrl}/${employeeId}`;
    return this.http.get<IEmployee>(url);
  }

  updateEmployee(employeeId: number, employee: IEmployee): Observable<IEmployee> {
    const url = `${this.apiUrl}/${employeeId}`;
    return this.http.put<IEmployee>(url, employee);
  }

  deleteEmployee(employeeId: number): Observable<any> {
    const url = `${this.apiUrl}/${employeeId}`;
    return this.http.delete(url);
  }
}