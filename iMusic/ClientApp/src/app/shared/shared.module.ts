import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongCardComponent } from './song-card/song-card.component';
import { ArtistCardComponent } from './artist-card/artist-card.component';


@NgModule({
  declarations: [SongCardComponent, ArtistCardComponent],
  imports: [
    CommonModule
  ],
  exports: [SongCardComponent, ArtistCardComponent]
})
export class SharedModule { }
