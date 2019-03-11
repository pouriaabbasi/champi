import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ToastrModule } from 'ngx-toastr';
import { BsDatepickerModule } from 'ngx-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { FooterComponent } from './components/footer/footer.component';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { TablesComponent } from './pages/tables/tables.component';
import { FormsComponent } from './pages/forms/forms.component';
import { TypographyComponent } from './pages/typography/typography.component';
import { MapsComponent } from './pages/maps/maps.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { GameTypesComponent } from './pages/game-types/game-types.component';
import { HttpClientModule } from '@angular/common/http';
import { GameTypeModalComponent } from './pages/game-types/game-type-modal/game-type-modal.component';
import { ConfirmComponent } from './components/confirm/confirm.component';
import { CompetitionsComponent } from './pages/competitions/competitions.component';
import { TeamsComponent } from './pages/teams/teams.component';
import { CompetitionModalComponent } from './pages/competitions/competition-modal/competition-modal.component';
import { TeamModalComponent } from './pages/teams/team-modal/team-modal.component';
import { UiSwitchModule } from 'angular2-ui-switch'

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SidebarComponent,
    FooterComponent,
    DashboardComponent,
    TablesComponent,
    FormsComponent,
    TypographyComponent,
    MapsComponent,
    NotificationsComponent,
    GameTypesComponent,
    GameTypeModalComponent,
    ConfirmComponent,
    CompetitionsComponent,
    TeamsComponent,
    CompetitionModalComponent,
    TeamModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    UiSwitchModule,
    CollapseModule.forRoot(),
    ToastrModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    ConfirmComponent,
    GameTypeModalComponent,
    TeamModalComponent,
    CompetitionModalComponent
  ]
})
export class AppModule { }
