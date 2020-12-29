import { Component, OnInit } from '@angular/core';
import { CartService } from '../core/custom/cart.service';
import { SongDTO, SongService } from '../core/swagger';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css']
})
export class SongsComponent implements OnInit {
  public songs: SongDTO[] = [];
  constructor(private songService: SongService, private cartService: CartService) { }

  ngOnInit(): void {
    this.songService.getAllSongs().subscribe((songs: SongDTO[]) => {
      this.songs = songs;
    })
  }

  addSongInCartEvent($event: SongDTO) {
    this.cartService.addItem($event?.songId, undefined, $event.price);
    console.log(this.cartService.getNumberOfItems());
  }

}
