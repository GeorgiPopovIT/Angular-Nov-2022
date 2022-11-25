import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormControl, NgForm, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm =  this.fb.group({
      'email' : ['',Validators.required,Validators.email],
      'username' : ['',Validators.required,Validators.maxLength(100)],
      'password' : ['',Validators.required, Validators.minLength(5)]
    });

  constructor(private fb : FormBuilder, private authService : AuthService){ 
      
   }

  ngOnInit(): void {
  }

  registerFormSubmit(form : NgForm) : void {
    this.authService.register(this.registerForm.value).subscribe(data => {
      this.authService.saveToken(data['token']);
    });
  }

}
