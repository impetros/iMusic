import { Component, OnInit } from '@angular/core';
import { CartService } from '../core/custom/cart.service';
import { AlbumDTO, AlbumService, ArtistDTO, ArtistService, SongDTO, SongService } from '../core/swagger';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  public songs!: SongDTO[];
  public artists!: ArtistDTO[];
  public albums!: AlbumDTO[];

  constructor(private cartService: CartService, private songService: SongService, private artistService: ArtistService,
    private albumService: AlbumService) { }

  ngOnInit(): void {
    this.songService.getAllSongs().subscribe((songs: SongDTO[]) => {
      this.songs = songs;
    })
    this.artistService.getAllArtists().subscribe((artists: ArtistDTO[]) => {
      this.artists = artists;
    });
    this.albumService.getAllAlbums().subscribe((albums: AlbumDTO[]) => {
      this.albums = albums;
    });
  }

  addAlbumInCartEvent($event: AlbumDTO) {
    this.cartService.addItem(null, $event, $event.price);
  }

  addSongInCartEvent($event: SongDTO) {
    this.cartService.addItem($event, null, $event.price);
  }

}
