import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CompetitionModel } from '../models/competition/competition.model';
import { AddCompetitionModel } from '../models/competition/add-competition.model';
import { UpdateCompetitionModel } from '../models/competition/update-competition.model';
import { UpdateCompetitionTeamsModel } from '../models/competition/update-competition-teams.model';
import { UpdateCompetitionStepsModel } from '../models/competition/update-competition-steps.model';
import { CompetitionStepModel } from '../models/competition/competition-step.model';
import { CompetitionTeamModel } from '../models/competition/competition-team.model';
import { LeagueModel } from '../models/competition/league.model';
import { AddLeagueModel } from '../models/competition/add-league.model';
import { UpdateLeagueModel } from '../models/competition/update-league.model';
import { LeagueMatchModel } from '../models/competition/league-match.model';

@Injectable({
  providedIn: 'root'
})
export class CompetitionService extends BaseService {

  constructor(
    protected http: HttpClient
  ) {
    super(http);
  }

  public getCompetitions(): Observable<CompetitionModel[]> {
    return super.get('Competition/GetCompetitions');
  }

  public addCompetition(model: AddCompetitionModel): Observable<CompetitionModel> {
    return super.post('Competition/AddCompetition', model);
  }

  public updateCompetition(competitionId: number, model: UpdateCompetitionModel): Observable<CompetitionModel> {
    return super.put(`Competition/UpdateCompetition/${competitionId}`, model);
  }

  public updateCompetitionTeams(competitionId: number, model: UpdateCompetitionTeamsModel): Observable<boolean> {
    return super.put(`Competition/UpdateCompetitionTeams/${competitionId}`, model);
  }

  public deleteCompetition(competitionId: number): Observable<boolean> {
    return super.delete(`Competition/DeleteCompetition/${competitionId}`);
  }

  public getCompetitionTeams(competitionId: number): Observable<CompetitionTeamModel[]> {
    return super.get(`Competition/GetCompetitionTeams/${competitionId}`);
  }

  public updateCompetitionSteps(competitionId: number, model: UpdateCompetitionStepsModel[]): Observable<boolean> {
    return super.put(`Competition/UpdateCompetitionSteps/${competitionId}`, model);
  }

  public getCompetitionSteps(competitionId: number): Observable<CompetitionStepModel[]> {
    return super.get(`Competition/GetCompetitionSteps/${competitionId}`);
  }

  public getleague(competitionStepId: number): Observable<LeagueModel> {
    return super.get(`Competition/GetCompetitionLeague/${competitionStepId}`);
  }

  public addLeague(model: AddLeagueModel): Observable<LeagueModel> {
    return super.post('Competition/AddCompetitionLeague', model);
  }

  public updateLeague(leagueId: number, model: UpdateLeagueModel): Observable<LeagueModel> {
    return super.put(`Competition/UpdateCompetitionLeague/${leagueId}`, model);
  }

  public getLeagueMatches(leagueId: number): Observable<LeagueMatchModel[]> {
    return super.get(`Competition/GetLeagueMatches/${leagueId}`);
  }

  public generateLeagueGames(leagueId: number): Observable<LeagueMatchModel[]> {
    return super.post(`Competition/GenerateLeagueGames/${leagueId}`, null);
  }
}
