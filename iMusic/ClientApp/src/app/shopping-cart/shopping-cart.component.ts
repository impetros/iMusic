import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/custom/api/auth-service';
import { CartService } from '../core/custom/cart.service';
import { ShoppingCartDTO } from '../core/swagger';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  cart!: ShoppingCartDTO;
  priceTotal!: number;
  constructor(private cartService: CartService, private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.cart = this.cartService.getCart();
    this.priceTotal = this.cartService.getTotalPrice();
  }

  purchase() {
    if(this.authService.isAuthenticated()) {
      
    } else {
      this.router.navigate(['/login']);
    }
  }

}
