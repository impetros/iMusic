import { Component, Input, OnInit } from '@angular/core';
import { SongDTO } from 'src/app/core/swagger';

@Component({
  selector: 'app-song-card',
  templateUrl: './song-card.component.html',
  styleUrls: ['./song-card.component.css']
})
export class SongCardComponent implements OnInit {
  @Input()
  song!: SongDTO;
  
  constructor() { }

  ngOnInit(): void {
  }

}
