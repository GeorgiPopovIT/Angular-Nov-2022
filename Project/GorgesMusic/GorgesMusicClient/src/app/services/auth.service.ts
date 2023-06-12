import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiURL + '/identity/login';
  private registerPath = environment.apiURL + '/identity/register';

  constructor(private httpClient : HttpClient) { }

  login(data : any) : Observable<any> {
    return this.httpClient.post(this.loginPath,data);
  }

  register(data : any) : Observable<any>{
    return this.httpClient.post(this.registerPath,data);
  }

  saveToken(token : string){
    localStorage.setItem('token',token);
  }

  getToken(){
    return localStorage.getItem('token');
  }

  logOut() : void {
     localStorage.removeItem('token');
  }
  get isLoggedIn() {
    return this.getToken;
  }

  get isAdmin(){
    //const token = localStorage.getItem("token");
    //const decodedToken = this.jwtHelper.decodeToken(token);
    //const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

    //return role === 'Administrator';

    return false;
  }
}
