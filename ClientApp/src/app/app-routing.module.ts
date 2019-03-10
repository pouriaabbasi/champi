import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { TablesComponent } from './pages/tables/tables.component';
import { FormsComponent } from './pages/forms/forms.component';
import { TypographyComponent } from './pages/typography/typography.component';
import { MapsComponent } from './pages/maps/maps.component';
import { NotificationsComponent } from './pages/notifications/notifications.component';
import { GameTypesComponent } from './pages/game-types/game-types.component';
import { TeamsComponent } from './pages/teams/teams.component';
import { CompetitionsComponent } from './pages/competitions/competitions.component';

const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'game-types', component: GameTypesComponent },
  { path: 'teams', component: TeamsComponent },
  { path: 'competitions', component: CompetitionsComponent },

  { path: 'forms', component: FormsComponent },
  { path: 'tables', component: TablesComponent },
  { path: 'typography', component: TypographyComponent },
  { path: 'maps', component: MapsComponent },
  { path: 'notifications', component: NotificationsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
