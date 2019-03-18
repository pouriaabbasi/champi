import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionModel } from 'src/app/models/competition/competition.model';
import { CompetitionService } from 'src/app/services/competition.service';
import { TeamService } from 'src/app/services/team.service';
import { BaseSelectinoModel } from 'src/app/models/base/base-selection.model';
import { UpdateCompetitionTeamsModel } from 'src/app/models/competition/update-competition-teams.model';
import { CompetitionTeamModel } from 'src/app/models/competition/competition-team.model';

@Component({
  selector: 'app-competition-teams-modal',
  templateUrl: './competition-teams-modal.component.html',
  styleUrls: ['./competition-teams-modal.component.scss']
})
export class CompetitionTeamsModalComponent extends BasePage implements OnInit {
  competition: CompetitionModel;
  teamSelections: BaseSelectinoModel[] = [];
  competitionTeams: CompetitionTeamModel[] = [];

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private modalRef: BsModalRef,
    private competitionService: CompetitionService,
    private teamService: TeamService
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    super.ngOnInit();
    this.fetchData();
  }

  public close() {
    this.modalRef.hide();
    this.onClose.next(false);
  }

  public submit() {
    const model: UpdateCompetitionTeamsModel = {
      teamsId: []
    };

    this.teamSelections.forEach(selection => {
      if (selection.selected) {
        model.teamsId.push(selection.key);
      }
    });
    this.competitionService.updateCompetitionTeams(this.competition.id, model)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Competition Teams updated successfuly', 'Update Competition Teams');
          this.modalRef.hide();
          this.onClose.next(true);
        }
      });
  }

  private fetchData() {
    this.teamService.getTeamSelections()
      .subscribe(selections => {
        this.teamSelections = selections;

        this.competitionService.getCompetitionTeams(this.competition.id)
          .subscribe(teams => {
            this.competitionTeams = teams;

            this.competitionTeams.forEach(competitionTeam => {
              const selection = this.teamSelections.find(x => x.key === competitionTeam.teamId);
              selection.selected = true;
            });
          });
      });
  }
}
