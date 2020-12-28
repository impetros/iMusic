import { Component, Input, OnInit } from '@angular/core';
import { ArtistDTO } from 'src/app/core/swagger';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css']
})
export class ArtistCardComponent implements OnInit {
  @Input()
  artist!: ArtistDTO;
  constructor() { }

  ngOnInit(): void {
  }

}
