import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameTypeModel } from '../models/game-type/game-type.model';
import { AddGameTypeModel } from '../models/game-type/add-game-type-model';
import { UpdateGameTypeModel } from '../models/game-type/update-game-type.model';
import { BaseSelectinoModel } from '../models/base/base-selection.model';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class GameTypeService extends BaseService {

  constructor(
    protected http: HttpClient,
    protected toastr: ToastrService
  ) {
    super(http, toastr);
  }

  public getGameTypes(): Observable<GameTypeModel[]> {
    return super.get('GameType/GetGameTypes');
  }

  public getGameTypesSelection(): Observable<BaseSelectinoModel[]> {
    return super.get('GameType/GetGameTypeSelections');
  }

  public addGameType(model: AddGameTypeModel): Observable<GameTypeModel> {
    return super.post('GameType/AddGameType', model);
  }

  public updateGameType(id: number, model: UpdateGameTypeModel): Observable<GameTypeModel> {
    return super.put(`GameType/UpdateGameType/${id}`, model);
  }

  public deleteGameType(id: number): Observable<boolean> {
    return super.delete(`GameType/DeleteGameType/${id}`);
  }
}
