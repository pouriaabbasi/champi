import { Component, OnInit } from '@angular/core';
import { LeagueModel } from 'src/app/models/competition/league.model';
import { CompetitionStepModel } from 'src/app/models/competition/competition-step.model';
import { LeagueMatchModel } from 'src/app/models/competition/league-match.model';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionService } from 'src/app/services/competition.service';
import { SetMatchScoreModel } from 'src/app/models/competition/set-match-score.model';

@Component({
  selector: 'app-competition-league-match-config-modal',
  templateUrl: './competition-league-match-config-modal.component.html',
  styleUrls: ['./competition-league-match-config-modal.component.scss']
})
export class CompetitionLeagueMatchConfigModalComponent extends BasePage implements OnInit {
  league: LeagueModel;
  competitionStep: CompetitionStepModel;
  leagueMatches: LeagueMatchModel[];

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
  }

  public close() {
    this.modalRef.hide();
    this.onClose.next(false);
  }

  public generateLeagueMatches() {
    this.competitionService
      .generateLeagueGames(this.league.id)
      .subscribe(matches => {
        this.leagueMatches = matches;
      });
  }

  public generateExtraRound() {
    this.competitionService
      .generateExtraRound(this.league.id)
      .subscribe(matches => {
        this.leagueMatches = matches;
      })
  }

  public editable(match: LeagueMatchModel) {
    match.editable = true;
  }

  public cancel(match: LeagueMatchModel) {
    match.editable = false;
  }

  public save(match: LeagueMatchModel) {
    const model: SetMatchScoreModel = {
      firstTeamScore: match.firstTeamScore,
      secondTeamScore: match.secondTeamScore
    };

    this.competitionService.setMatchScore(match.id, model)
      .subscribe(result => {
        if (result) {
          match.editable = false;
        }
      });
  }

  private fetchData() {
    this.competitionService
      .getleague(this.competitionStep.id)
      .subscribe(league => {
        this.league = league;
        this.competitionService
          .getLeagueMatches(this.league.id)
          .subscribe(matches => {
            this.leagueMatches = matches;
          });
      });
  }
}
