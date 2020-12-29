import { Injectable } from '@angular/core';
import { ShoppingCartDTO, ShoppingCartItemDTO } from '../swagger';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private readonly CART: string = "iMusic-Cart";
  constructor() { }

  public getCart(): ShoppingCartDTO {
    let stringCART = sessionStorage.getItem(this.CART);
    if(stringCART == null){
      this.initEmptyCart();
      return this.getCart();
    };
    return JSON.parse(stringCART) as ShoppingCartDTO;
  }

  public getNumberOfItems() : number {
    let shoppingCart = this.getCart();
    if(shoppingCart == null || shoppingCart.cartitems == null) return 0;
    return shoppingCart.cartitems.length;
  }

  public addItem(songId: number | undefined, albumId: number | undefined, price: number | undefined) { 
    if(songId == albumId || (songId != null && albumId != null)) return; // only one of them should be non-nullable
    let cart = this.getCart();
    let shoppingCartItem: ShoppingCartItemDTO = {
      albumId: albumId,
      songId: songId,
      price: price
    };
    cart.cartitems?.push(shoppingCartItem);
    this.setCart(cart);
  }

  private initEmptyCart(){
    let shoppingCart: ShoppingCartDTO = {
      cartitems: []
    };
    this.setCart(shoppingCart);
  }

  private setCart(cart: ShoppingCartDTO) {
    sessionStorage.setItem(this.CART, JSON.stringify(cart));
  }

}
