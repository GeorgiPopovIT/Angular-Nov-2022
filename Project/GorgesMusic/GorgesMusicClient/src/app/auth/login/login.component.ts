import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators , NgForm, Form} from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  constructor(private authService : AuthService, private router : Router) { }

  ngOnInit(): void {
  }

  loginSubmit(loginForm : NgForm) : void{
    if(loginForm.invalid){
      return;
    }
    
    this.authService.login(loginForm.value).subscribe (data => {
      this.authService.saveToken(data['secret']);
      this.router.navigate(['/']);
    });
  }
}
