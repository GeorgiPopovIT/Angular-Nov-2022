import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private loginPath = environment.apiURL + '/identity/login';
  private registerPath = environment.apiURL + '/identity/register';

  private jwtHelper = inject(JwtHelperService);

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

  getToken() {
    return localStorage.getItem('token');
  }

  logOut() : void {
     localStorage.removeItem('token');
  }

  get isLoggedIn() {
    let isExpired = this.jwtHelper.isTokenExpired(this.getToken());
    if(isExpired){
      this.logOut();
    }
    return this.getToken();
  }
  
  get isAdmin(){
    const token = this.getToken();
    const decodedToken = this.jwtHelper.decodeToken(token!);

    if(!decodedToken){
      return;
    }
    const role = decodedToken['role'];

    return role === 'Administrator';
  }
}
