export * from './album.service';
import { AlbumService } from './album.service';
export * from './artist.service';
import { ArtistService } from './artist.service';
export * from './song.service';
import { SongService } from './song.service';
export const APIS = [AlbumService, ArtistService, SongService];
