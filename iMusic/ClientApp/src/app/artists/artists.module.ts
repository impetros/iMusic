import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArtistsRoutingModule } from './artists-routing.module';
import { ArtistsComponent } from './artists.component';
import { ArtistService } from '../core/swagger';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [ArtistsComponent],
  imports: [
    CommonModule,
    ArtistsRoutingModule,
    SharedModule
  ],
  providers: [ArtistService]
})
export class ArtistsModule { }
