import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/custom/api/auth-service';
import { CartService } from '../core/custom/cart.service';

@Component({
  selector: 'app-topnavbar',
  templateUrl: './topnavbar.component.html',
  styleUrls: ['./topnavbar.component.css']
})
export class TopnavbarComponent implements OnInit {

  constructor(public authService: AuthService, public cartService: CartService) { }

  ngOnInit(): void {
  }

}
