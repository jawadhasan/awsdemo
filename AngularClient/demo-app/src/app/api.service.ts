import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  apiBaseURI:string =`https://z28bd4vmse.execute-api.eu-central-1.amazonaws.com/Prod`;

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get(`${this.apiBaseURI}/api/users`);
  }

  getToken(){
    return this.http.get(`${this.apiBaseURI}/api/token`);
  }

  deleteUser(id:number){    
    return this.http.delete(`${this.apiBaseURI}/api/users/${id}`);
  }
}
