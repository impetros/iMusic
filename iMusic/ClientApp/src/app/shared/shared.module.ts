import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SongCardComponent } from './song-card/song-card.component';


@NgModule({
  declarations: [SongCardComponent],
  imports: [
    CommonModule
  ],
  exports: [SongCardComponent]
})
export class SharedModule { }
