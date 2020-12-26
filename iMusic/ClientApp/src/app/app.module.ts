import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TopnavbarComponent } from './topnavbar/topnavbar.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtTokenInterceptorService } from './core/interceptors/jwt-token-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    TopnavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtTokenInterceptorService, multi: true }], 
  bootstrap: [AppComponent]
})
export class AppModule { }
