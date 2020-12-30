import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AlbumDTO } from 'src/app/core/swagger';

@Component({
  selector: 'app-album-card',
  templateUrl: './album-card.component.html',
  styleUrls: ['./album-card.component.css']
})
export class AlbumCardComponent implements OnInit {
  @Input()
  album!: AlbumDTO;
  @Output()
  addAlbumInCartEvent = new EventEmitter<AlbumDTO>();
  constructor() { }

  ngOnInit(): void {
  }

  addItemToCart(){
    this.addAlbumInCartEvent.emit(this.album);
  }

}
