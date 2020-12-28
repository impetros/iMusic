import { Component, OnInit } from '@angular/core';
import { AlbumDTO, AlbumService } from '../core/swagger';

@Component({
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css']
})
export class AlbumsComponent implements OnInit {

  public albums: AlbumDTO[] = [];
  constructor(private albumService: AlbumService) { }

  ngOnInit(): void {
    this.albumService.getAllAlbums().subscribe((albums: AlbumDTO[]) => {
      this.albums = albums;
    });
  }

}
