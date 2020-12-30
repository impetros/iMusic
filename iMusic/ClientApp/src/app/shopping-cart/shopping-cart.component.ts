import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../core/custom/api/auth-service';
import { CartService } from '../core/custom/cart.service';
import { ShoppingCartDTO } from '../core/swagger';
import { ShopService } from '../core/swagger/api/shop.service';

import swal from 'sweetalert2';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css']
})
export class ShoppingCartComponent implements OnInit {
  cart!: ShoppingCartDTO;
  priceTotal!: number;
  constructor(private cartService: CartService, private authService: AuthService, private shopService: ShopService, private router: Router) { }

  ngOnInit(): void {
    this.cart = this.cartService.getCart();
    this.priceTotal = this.cartService.getTotalPrice();
  }

  purchase() {
    if(this.authService.isAuthenticated()) {
      let userId = this.authService.getUserId();
      let shoppingCart = this.cart;
      shoppingCart.price = this.cartService.getTotalPrice();
      shoppingCart.date = new Date();
      if(userId) {
        shoppingCart.userId = parseInt(userId);
      }
      this.shopService.purchase(shoppingCart).subscribe(reponse => {
        Swal.fire('Purchased successfully', 'Congrats! operation successfull', 'success');
        this.cartService.clearCart();
        this.cart = this.cartService.getCart();
        this.priceTotal = this.cartService.getTotalPrice();
      });
    } else {
      this.router.navigate(['/login']);
    }
  }

}
