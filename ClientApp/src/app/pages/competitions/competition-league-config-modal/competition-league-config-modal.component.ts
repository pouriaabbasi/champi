import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionStepModel } from 'src/app/models/competition/competition-step.model';
import { CompetitionService } from 'src/app/services/competition.service';
import { CompetitionTeamModel } from 'src/app/models/competition/competition-team.model';
import { LeagueModel } from 'src/app/models/competition/league.model';

@Component({
  selector: 'app-competition-league-config-modal',
  templateUrl: './competition-league-config-modal.component.html',
  styleUrls: ['./competition-league-config-modal.component.scss']
})
export class CompetitionLeagueConfigModalComponent extends BasePage implements OnInit {
  league: LeagueModel;
  competitionStep: CompetitionStepModel;
  competitionTeams: CompetitionTeamModel[] = [];

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private modalRef: BsModalRef,
    private competitionService: CompetitionService
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    super.ngOnInit();
    this.fetchData();
    this.league = new LeagueModel();
  }

  public close() {
    this.modalRef.hide();
    this.onClose.next(false);
  }

  public submit() {

  }

  private fetchData() {
    this.competitionService.getleague(this.competitionStep.id)
      .subscribe(league => {
        if (league) { 
          this.league = league;
        }

        this.competitionService.getCompetitionTeams(this.competitionStep.competitionId)
          .subscribe(teams => {
            this.competitionTeams = teams;
          });
      });
  }
}
