import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  switchSignUp() {
    document.querySelector(".container")?.classList.add("sign-up-mode");
  }

  switchSignIn() {
    document.querySelector(".container")?.classList.remove("sign-up-mode");
  }

}
