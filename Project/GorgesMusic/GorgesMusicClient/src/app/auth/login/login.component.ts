import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators , NgForm, Form} from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm = this.fb.group({
    'username' : ['',Validators.required],
    'password' : ['',Validators.required]
  });
  constructor(private fb : FormBuilder, private authService : AuthService) { }

  ngOnInit(): void {
  }

  loginSubmit(){
    this.authService.login(this.loginForm.value).subscribe (data => {
      this.authService.saveToken(data['token']);
    });
  }
}
