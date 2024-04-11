import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Role } from '../models/role.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RolesService {

  getAllRoles(): Observable<Role[]>{
    return this._http.get<Role[]>('https://localhost:7001/api/Role')
  }

  postRole(role: Role): Observable<any>{
    return this._http.post('/api/Roles', role)
  }

  constructor(private _http: HttpClient) { }
}
