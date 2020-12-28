export * from './artist.service';
import { ArtistService } from './artist.service';
export * from './song.service';
import { SongService } from './song.service';
export const APIS = [ArtistService, SongService];
