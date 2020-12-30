import { Component, OnInit } from '@angular/core';
import { CartService } from '../core/custom/cart.service';
import { AlbumDTO, AlbumService } from '../core/swagger';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {

  public albums: AlbumDTO[] = [];
  constructor(private albumService: AlbumService,private cartService: CartService) { }

  ngOnInit(): void {
    this.albumService.getAllAlbums().subscribe((albums: AlbumDTO[]) => {
      this.albums = albums;
    });
  }

  addAlbumInCartEvent($event: AlbumDTO) {
    this.cartService.addItem(null, $event, $event.price);
    console.log(this.cartService.getNumberOfItems());
  }

}
