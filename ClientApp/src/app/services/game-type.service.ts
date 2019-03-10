import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameTypeModel } from '../models/game-type/game-type.model';
import { AddGameTypeModel } from '../models/game-type/add-game-type-model';
import { UpdateGameTypeModel } from '../models/game-type/update-game-type.model';

@Injectable({
  providedIn: 'root'
})
export class GameTypeService extends BaseService {

  constructor(
    protected http: HttpClient
  ) {
    super(http);
  }

  public getGameTypes(): Observable<GameTypeModel[]> {
    return super.get('GameType/GetGameTypes');
  }

  public addGameType(model: AddGameTypeModel): Observable<GameTypeModel> {
    return super.post('GameType/AddGameType', model);
  }

  public updateGameType(id: number, model: UpdateGameTypeModel): Observable<GameTypeModel> {
    return super.put(`GameType/UpdateGameType/${id}`, model);
  }

  public deleteGameType(id:number):Observable<boolean>{
    return super.delete(`GameType/DeleteGameType/${id}`);
  }
}
