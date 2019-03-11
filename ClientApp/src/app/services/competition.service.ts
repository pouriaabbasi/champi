import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CompetitionModel } from '../models/competition/competition.model';
import { AddCompetitionModel } from '../models/competition/add-competition.model';
import { UpdateCompetitionModel } from '../models/competition/update-competition.model';

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

  public deleteCompetition(id:number):Observable<boolean>{
    return super.delete(`Competition/UpdateCompetition/${id}`);
  }
}
