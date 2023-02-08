import { Component } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { twoPasswordGroupValidator } from 'src/app/shared/validators/passwordGroup.validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent  {

  registerForm : FormGroup; 

  constructor(private fb : FormBuilder, private authService : AuthService){
    this.registerForm =  this.fb.group({
      email : ['',Validators.required,Validators.email],
      username : ['',Validators.required,Validators.maxLength(100),Validators.minLength(5)],
      pass: this.fb.group({
        password: ['', [Validators.required, Validators.minLength(5)]],
        confirmPassword: []
      }, {
        validators: [twoPasswordGroupValidator('password', 'confirmPassword')]
      })
    });
   }

      register() : void {
        if(this.registerForm.invalid){
          return;
        }

        this.authService.register(this.registerForm.value).subscribe(data =>{
          
        });
  }

}
