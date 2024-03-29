import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard   {
  constructor(private router : Router,  private jwtHelper : JwtHelperService){}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree>{
    const token = localStorage.getItem("token");
    if (token && !this.jwtHelper.isTokenExpired(token)){
      return true;
    }
    this.router.navigate(['/auth/login']);
      return false;
  }
}
