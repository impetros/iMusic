import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../core/custom/api/auth-service';
import { MustMatch } from '../core/helpers/mustmatch';
import { LoginRequest } from '../core/swagger';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  registerForm!: FormGroup;
  submitted = false;

  constructor(private authService: AuthService, private formBuilder: FormBuilder, private router: Router) { 
  }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    }, {
      validator: MustMatch('password', 'confirmPassword')
    });
  }

  get f() { return this.loginForm.controls; }

  onLogInSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (!this.loginForm.invalid) {
      let loginRequest: LoginRequest = {
        emailOrUsername: this.loginForm.controls["username"].value,
        password: this.loginForm.controls["password"].value
      }
      this.authService.login(loginRequest).subscribe(repoonse => {
        this.router.navigate(['/home']);    
      }, error => {
        this.loginForm.reset();    
          this.loginForm.setErrors({    
            invalidLogin: true    
          });
      } )
    } 
  } 

  onLogInReset() {
      this.submitted = false;
      this.loginForm.reset();
  }

  switchSignUp() {
    document.querySelector(".container")?.classList.add("sign-up-mode");
    this.submitted = false;
  }

  switchSignIn() {
    document.querySelector(".container")?.classList.remove("sign-up-mode");
    this.submitted = false;
  }

}
