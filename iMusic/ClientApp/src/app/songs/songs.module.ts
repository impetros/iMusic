import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SongsRoutingModule } from './songs-routing.module';
import { SongsComponent } from './songs.component';
import { SongService } from '../core/swagger';


@NgModule({
  declarations: [SongsComponent],
  imports: [
    CommonModule,
    SongsRoutingModule
  ],
  providers: [SongService]
})
export class SongsModule { }
