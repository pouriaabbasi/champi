import { Component, OnInit } from '@angular/core';
import { LeagueModel } from 'src/app/models/competition/league.model';
import { CompetitionStepModel } from 'src/app/models/competition/competition-step.model';
import { LeagueMatchModel } from 'src/app/models/competition/league-match.model';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionService } from 'src/app/services/competition.service';

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
