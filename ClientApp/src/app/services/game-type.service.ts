import { Injectable } from '@angular/core';
import { BaseService } from './base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GameTypeModel } from '../models/game-type/game-type.mode';

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
}
