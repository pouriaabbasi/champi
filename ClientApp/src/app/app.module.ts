import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { GameTypeComponent } from './pages/game-type/game-type.component';
import { BaseComponent } from './pages/base/base/base.component';
import { GameTypeModalComponent } from './pages/game-type/game-type-modal/game-type-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    GameTypeComponent,
    BaseComponent,
    GameTypeModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
