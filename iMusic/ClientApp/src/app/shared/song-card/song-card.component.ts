import { Component, Input, OnInit } from '@angular/core';
import { CartService } from 'src/app/core/custom/cart.service';
import { SongDTO } from 'src/app/core/swagger';

@Component({
  selector: 'app-song-card',
  templateUrl: './song-card.component.html',
  styleUrls: ['./song-card.component.css']
})
export class SongCardComponent implements OnInit {
  @Input()
  song!: SongDTO;
  
  artists: string = "";

  constructor(private cartService: CartService) { }

  ngOnInit(): void {
    if(this.song && this.song.artists){
      for(let i = 0; i < this.song.artists?.length; i ++) {
        if(i === 0 || i === this.song.artists?.length - 1) {
          this.artists += this.song.artists[i].name;
        } else {
          this.artists += this.song.artists[i].name + ", ";
        }
      }
    }
  }

  addItemToCart() {
    this.cartService.addItem(this.song?.songId, undefined, this.song.price);
  }

}
