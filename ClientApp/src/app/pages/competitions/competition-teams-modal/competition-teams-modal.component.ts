import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionModel } from 'src/app/models/competition/competition.model';
import { CompetitionService } from 'src/app/services/competition.service';
import { TeamService } from 'src/app/services/team.service';
import { BaseSelectinoModel } from 'src/app/models/base/base-selection.model';

@Component({
  selector: 'app-competition-teams-modal',
  templateUrl: './competition-teams-modal.component.html',
  styleUrls: ['./competition-teams-modal.component.scss']
})
export class CompetitionTeamsModalComponent extends BasePage implements OnInit {
  competition: CompetitionModel;
  teamSelections: BaseSelectinoModel[] = [];
  competitionTeamsId: number[] = [];

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
    const selectedTeams: number[] = [];
    this.teamSelections.forEach(selection => {
      if (selection.selected) {
        selectedTeams.push(selection.key);
      }
    });
    this.competitionService.updateCompetitionTeams(this.competition.id, selectedTeams)
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

        this.competitionService.getCompetitionTeamsId(this.competition.id)
          .subscribe(teamsId => {
            this.competitionTeamsId = teamsId;

            this.competitionTeamsId.forEach(competitionTeamId => {
              const selection = this.teamSelections.find(x => x.key === competitionTeamId);
              selection.selected = true;
            });
          });
      });
  }
}
