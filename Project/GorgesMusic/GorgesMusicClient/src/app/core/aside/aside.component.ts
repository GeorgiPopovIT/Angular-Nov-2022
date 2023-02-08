import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-aside',
  templateUrl: './aside.component.html',
  styleUrls: ['./aside.component.css']
})
export class AsideComponent {

  constructor(private authService : AuthService) { }


  get isLogged(){
    return this.authService.isLoggedIn;
  }
}
