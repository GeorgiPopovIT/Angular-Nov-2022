import { Component } from '@angular/core';
import { RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-aside',
  templateUrl: './aside.component.html',
  styleUrls: ['./aside.component.css']
})
export class AsideComponent  {
  constructor() { }

  navigateRegister(url:string){
   // this.router.navigate([url]);
  }

  navigateLogin(url : string){
    //this.router.navigate([url]);
  }
}
