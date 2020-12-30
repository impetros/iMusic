import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AuthService } from '../core/custom/api/auth-service';
import { CartService } from '../core/custom/cart.service';
import { MustMatch } from '../core/helpers/mustmatch';
import { LoginRequest, UserDTO, UserService } from '../core/swagger';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  registerForm!: FormGroup;
  submitted: boolean = false;

  usernameExists: boolean = false;

  constructor(private authService: AuthService, private userService: UserService, private formBuilder: FormBuilder, private router: Router, 
    private cartService: CartService) { 
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
  get g() { return this.registerForm.controls; }
  onLogInSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (!this.loginForm.invalid) {
      let loginRequest: LoginRequest = {
        emailOrUsername: this.loginForm.controls["username"].value,
        password: this.loginForm.controls["password"].value
      }
      this.authService.login(loginRequest).subscribe(repoonse => {
        if(this.cartService.getNumberOfItems() === 0) {
          this.router.navigate(['/home']);    
        } else {
          this.router.navigate(['/shopping-cart']);
        }
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

  onRegisterSubmit() {
    this.submitted = true;
    if(!this.registerForm.invalid) {
      let userDTO: UserDTO = {
        username: this.registerForm.controls["username"].value,
        email: this.registerForm.controls["email"].value,
        password: this.registerForm.controls["password"].value
      };
      this.userService.register(userDTO).subscribe(response => {
        if(response == 1) {
          this.usernameExists = true;
        } else {
          Swal.fire('Purchased successfully', 'Congrats! operation successfull', 'success');
          this.submitted = false;
          this.registerForm.reset();
        }
      })
    }
  }

  onUsernameChange($event : any) {
    this.usernameExists = false;
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
