import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SongsRoutingModule } from './songs-routing.module';
import { SongsComponent } from './songs.component';
import { SongService } from '../core/swagger';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [SongsComponent],
  imports: [
    CommonModule,
    SongsRoutingModule,
    SharedModule
  ],
  providers: [SongService]
})
export class SongsModule { }
