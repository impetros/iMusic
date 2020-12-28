import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AlbumsRoutingModule } from './albums-routing.module';
import { AlbumsComponent } from './albums.component';
import { SharedModule } from '../shared/shared.module';
import { AlbumService } from '../core/swagger';


@NgModule({
  declarations: [AlbumsComponent],
  imports: [
    CommonModule,
    AlbumsRoutingModule,
    SharedModule
  ],
  providers: [AlbumService]
})
export class AlbumsModule { }
