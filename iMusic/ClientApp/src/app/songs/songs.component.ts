import { Component, OnInit } from '@angular/core';
import { SongDTO, SongService } from '../core/swagger';

@Component({
  selector: 'app-songs',
  templateUrl: './songs.component.html',
  styleUrls: ['./songs.component.css']
})
export class SongsComponent implements OnInit {
  public songs: SongDTO[] = [];
  constructor(private songService: SongService) { }

  ngOnInit(): void {
    this.songService.getAllSongs().subscribe((songs: SongDTO[]) => {
      this.songs = songs;
    })
  }

}
