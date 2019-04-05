import { Component, OnInit } from '@angular/core';
import { TeamModel } from 'src/app/models/team/team.model';
import { BasePage } from '../base/base-page';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { TeamService } from 'src/app/services/team.service';
import { TeamModalComponent } from './team-modal/team-modal.component';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.scss']
})
export class TeamsComponent extends BasePage implements OnInit {
  teams: TeamModel[] = [];

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private teamService: TeamService
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    this.fetchData();
  }

  public addTeam() {
    const initialState = {
      team: new TeamModel()
    };
    const bsModalRef = this.modalService.show(TeamModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  public updateTean(team: TeamModel) {
    const initialState = {
      team: { ...team }
    };
    const bsModalRef = this.modalService.show(TeamModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  public deleteTeam(team: TeamModel) {
    this.showConfirm(`Are you sure to delete '${team.name}' ?`).subscribe(
      result => {
        if (result) {
          this.teamService.deleteTeam(team.id).subscribe(result => {
            if (result) {
              this.showSuccess('Team deleted successfuly', 'Delete Team');
              this.fetchData();
            }
          });
        }
      }
    );
  }

  private fetchData() {
    this.teamService.getTeams().subscribe(teams => {
      this.teams = teams;
    });
  }
}
