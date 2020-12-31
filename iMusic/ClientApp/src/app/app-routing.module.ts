import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: () => import('./home/home.module').then(p => p.HomeModule)
  },
  {
    path: 'songs',
    loadChildren: () => import('./songs/songs.module').then(p => p.SongsModule)
  },
  {
    path: 'artists',
    loadChildren: () => import('./artists/artists.module').then(p => p.ArtistsModule)
  },
  {
    path: 'albums',
    loadChildren: () => import('./albums/albums.module').then(p => p.AlbumsModule)
  },
  {
    path: 'shopping-cart',
    loadChildren: () => import('./shopping-cart/shopping-cart.module').then(p => p.ShoppingCartModule)
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then(p => p.LoginModule)
  },
  {
    path: 'profile',
    loadChildren: () => import('./profile/profile.module').then(p => p.ProfileModule)
  },
  { 
    path: '**', 
    redirectTo: 'home', 
    pathMatch: 'full' 
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
