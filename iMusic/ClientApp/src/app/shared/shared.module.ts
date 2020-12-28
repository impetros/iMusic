import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongCardComponent } from './song-card/song-card.component';
import { ArtistCardComponent } from './artist-card/artist-card.component';
import { AlbumCardComponent } from './album-card/album-card.component';


@NgModule({
  declarations: [SongCardComponent, ArtistCardComponent, AlbumCardComponent],
  imports: [
    CommonModule
  ],
  exports: [SongCardComponent, ArtistCardComponent, AlbumCardComponent]
})
export class SharedModule { }
