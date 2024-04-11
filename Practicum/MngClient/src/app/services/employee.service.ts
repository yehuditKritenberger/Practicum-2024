import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Employee } from '../models/employee.model';
import { HttpClient } from '@angular/common/http';
import { EmployeePost } from '../models/employeePost.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private employeesSubject = new Subject<Employee[]>();

  constructor(private _http: HttpClient) { }

  getAllEmployees(): Observable<Employee[]> {
    return this._http.get<Employee[]>('https://localhost:7001/api/Employee')
  }

  getEmployeesSubject(): Observable<Employee[]> {
    return this.employeesSubject.asObservable(); // החזר את ה-subject כ- Observable
  }

  getEmployeeById(employeeID: Number): Observable<Employee> {
    return this._http.get<Employee>(`https://localhost:7001/api/Employee/${employeeID}`)
  }

  addEmployee(employee: EmployeePost): Observable<any> {
    return this._http.post('https://localhost:7001/api/Employee', employee)
  }

  updateEmployee(id: Number, employee: Employee): Observable<any> {
    return this._http.put(`https://localhost:7001/api/Employee/${id}`, employee)
  }

  deleteEmployee(id:Number): Observable<any> {
    return this._http.delete(`https://localhost:7001/api/Employee/${id}`)
  }

}
