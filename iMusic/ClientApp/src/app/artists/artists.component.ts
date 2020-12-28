import { Component, OnInit } from '@angular/core';
import { ArtistDTO, ArtistService } from '../core/swagger';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.css']
})
export class ArtistsComponent implements OnInit {

  public artists: ArtistDTO[] = [];
  constructor(private artistService: ArtistService) { }

  ngOnInit(): void {
    this.artistService.getAllArtists().subscribe((artists: ArtistDTO[]) => {
      this.artists = artists;
    });
  }

}
