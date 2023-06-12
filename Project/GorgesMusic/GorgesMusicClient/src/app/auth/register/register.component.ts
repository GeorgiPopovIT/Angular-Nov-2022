import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { twoPasswordGroupValidator } from 'src/app/shared/validators/passwordGroup.validator';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent   {

  registerForm =  this.fb.group({
    email : ['',[Validators.required,Validators.email]],
    username : ['',[Validators.required,Validators.maxLength(100),Validators.minLength(5)]],
    pass: this.fb.group({
      password: ['', [Validators.required, Validators.minLength(5)]],
      confirmPassword: [Validators.required]
    }, {
      validators: [twoPasswordGroupValidator('password', 'confirmPassword')]
    })
  });
  constructor(private fb : FormBuilder, private authService : AuthService, private router: Router) { }

      register() : void {
        if(this.registerForm.invalid){
          return;
        }
        const formData = {
          username : this.registerForm.value.username,
          email : this.registerForm.value.email,
          password : this.registerForm.value.pass?.password
        }

        this.authService.register(formData).subscribe(data => {
          //console.log(data);
          this.router.navigate(['/auth/login']);
        });
  }

}
