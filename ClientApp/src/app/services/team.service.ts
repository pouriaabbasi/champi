import { Injectable } from "@angular/core";
import { BaseService } from "./base/base.service";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { TeamModel } from "../models/team/team.model";
import { AddTeamModel } from "../models/team/add-team.model";
import { UpdateTeamModel } from "../models/team/update-team.model";
import { BaseSelectinoModel } from "../models/base/base-selection.model";

@Injectable({
  providedIn: "root"
})
export class TeamService extends BaseService {
  constructor(protected http: HttpClient) {
    super(http);
  }

  public getTeams(): Observable<TeamModel[]> {
    return super.get("Team/GetTeams");
  }

  public getTeamSelections(): Observable<BaseSelectinoModel[]> {
    return this.get("Team/GetTeamSelections");
  }

  public addTeam(model: AddTeamModel): Observable<TeamModel> {
    return super.post("Team/AddTeam", model);
  }

  public updateTeam(id: number, model: UpdateTeamModel): Observable<TeamModel> {
    return super.put(`Team/UpdateTeam/${id}`, model);
  }

  public deleteTeam(id: number): Observable<boolean> {
    return super.delete(`Team/DeleteTeam/${id}`);
  }
}
