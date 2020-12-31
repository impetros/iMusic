import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { AuthService } from '../core/custom/api/auth-service';
import { UserDTO, UserService } from '../core/swagger';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  accountForm!: FormGroup;
  userId!: number;
  submitted: boolean = false;
  usernameExists: boolean = false;

  constructor(private formBuilder: FormBuilder, private userService: UserService, private authService: AuthService) { }

  ngOnInit(): void {
    this.accountForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
    let userIdString = this.authService.getUserId();
    if(userIdString){
      this.userId = parseInt(userIdString);
      this.userService.getUser(this.userId).subscribe((userDTO: UserDTO) => {
        if(userDTO) {
          this.accountForm.patchValue({
            username: userDTO.username,
            email: userDTO.email,
            password: userDTO.password
          });
        }
      });
    }
  }

  get g() { return this.accountForm.controls; }

  onUpdateSubmit() {
    this.submitted = true;
    if(!this.accountForm.invalid) {
      let userDTO: UserDTO = {
        userId: this.userId,
        username: this.accountForm.controls["username"].value,
        email: this.accountForm.controls["email"].value,
        password: this.accountForm.controls["password"].value
      };
      this.userService.update(userDTO).subscribe(response => {
        if(response === 1) {
          this.usernameExists = true;
        } else {
          Swal.fire('Account updated', 'Congrats! operation successfull', 'success');
          this.submitted = false;
        }
      })
    }
  }

  deleteAccount() {
    this.userService._delete(this.userId).subscribe(response => {
      Swal.fire('Account deleted', 'Congrats! operation successfull', 'success');
      this.authService.logout();
    })
  }

  onUsernameChange($event : any) {
    this.usernameExists = false;
  }
}
