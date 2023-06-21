import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import {User} from '../shared/models/User';

// const httpOptions = {
//   headers: new HttpHeaders({
//     'Authorization': 'Bearer ' + localStorage.getItem('token')
//   })
// };

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient
    ) { }

  getUser(id: number): Observable<User>{
    return this.http.get<User>(environment.apiUrl + 'userinfo/' + id);
  }

  updateUser(id: number, user: User): Observable<User>{
    return this.http.put<User>(environment.apiUrl + 'userinfo/' + id, user);
  }
}