import { Injectable } from '@angular/core';
import { AlbumDTO, ShoppingCartDTO, ShoppingCartItemDTO, SongDTO } from '../swagger';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private readonly CART: string = "iMusic-Cart";
  constructor() { }

  public getCart(): ShoppingCartDTO {
    let stringCART = localStorage.getItem(this.CART);
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

  public addItem(song: SongDTO | null, album: AlbumDTO | null, price: number | undefined) { 
    if((song == null && album == null) || (song != null && album != null)) return; // only one of them should be non-nullable
    let cart = this.getCart();
    let shoppingCartItem: ShoppingCartItemDTO 
    if(song) {
      shoppingCartItem = {
        songId: song?.songId,
        song: song,
        price: price
      };
      cart.cartitems?.push(shoppingCartItem);
    } else if(album) {
      shoppingCartItem = {
        albumId: album?.albumId,
        album: album,
        price: price
      };
      cart.cartitems?.push(shoppingCartItem);
    }
    
    this.setCart(cart);
  }

  public getTotalPrice(): number {
    let totalPrice: number = 0;
    let cart = this.getCart();
    cart.cartitems?.forEach(cartItem => {
      totalPrice += cartItem.price ?? 0;
    })
    return totalPrice;
  }

  private initEmptyCart(){
    let shoppingCart: ShoppingCartDTO = {
      cartitems: []
    };
    this.setCart(shoppingCart);
  }

  private setCart(cart: ShoppingCartDTO) {
    localStorage.setItem(this.CART, JSON.stringify(cart));
  }

}
