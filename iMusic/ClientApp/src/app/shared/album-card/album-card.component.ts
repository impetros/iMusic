import { Component, Input, OnInit } from '@angular/core';
import { AlbumDTO } from 'src/app/core/swagger';

@Component({
  selector: 'app-album-card',
  templateUrl: './album-card.component.html',
  styleUrls: ['./album-card.component.css']
})
export class AlbumCardComponent implements OnInit {
  @Input()
  album!: AlbumDTO;
  constructor() { }

  ngOnInit(): void {
  }

}
