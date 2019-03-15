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

  public updateCompetition(id: number, model: UpdateCompetitionModel): Observable<CompetitionModel> {
    return super.put(`Competition/UpdateCompetition/${id}`, model);
  }

  public updateCompetitionTeams(id: number, model: UpdateCompetitionTeamsModel): Observable<boolean> {
    return super.put(`Competition/UpdateCompetitionTeams/${id}`, model);
  }

  public deleteCompetition(id: number): Observable<boolean> {
    return super.delete(`Competition/DeleteCompetition/${id}`);
  }

  public getCompetitionTeamsId(id: number): Observable<number[]> {
    return super.get(`Competition/GetCompetitionTeamsId/${id}`);
  }

  public updateCompetitionSteps(id: number, model: UpdateCompetitionStepsModel[]): Observable<boolean> {
    return super.put(`Competition/UpdateCompetitionSteps/${id}`, model);
  }

  public getCompetitionSteps(id: number): Observable<CompetitionStepModel[]> {
    return super.get(`Competition/GetCompetitionSteps/${id}`);
  }
}
