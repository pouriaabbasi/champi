import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionStepModel } from 'src/app/models/competition/competition-step.model';
import { CompetitionService } from 'src/app/services/competition.service';
import { CompetitionTeamModel } from 'src/app/models/competition/competition-team.model';
import { LeagueModel } from 'src/app/models/competition/league.model';
import { AddLeagueModel } from 'src/app/models/competition/add-league.model';
import { UpdateLeagueModel } from 'src/app/models/competition/update-league.model';

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
    this.league.id ? this.updateLeague() : this.addLeague();
  }

  private addLeague() {
    const addLeagueModel: AddLeagueModel = {
      competitionStepId: this.competitionStep.id,
      fallTeamCount: this.league.teamCount,
      isHomeAway: this.league.isHomeAway,
      peerToPeerPlayCount: this.league.peerToPeerPlayCount,
      riseTeamCount: this.league.riseTeamCount,
      leagueTeams: [],
      teamCount: 0,
      drawPoint: this.league.drawPoint,
      lostPoint: this.league.lostPoint,
      wonPoint: this.league.wonPoint
    };

    this.competitionTeams.forEach(competitionTeam => {
      if (competitionTeam.selected) {
        addLeagueModel.leagueTeams.push({
          competitionTeamId: competitionTeam.id,
          leagueId: 0
        });
      }
    });

    addLeagueModel.teamCount = addLeagueModel.leagueTeams.length;

    this.competitionService.addLeague(addLeagueModel)
      .subscribe(result => {
        if (result) {
          this.modalRef.hide();
          this.showSuccess('League configed successfuly', 'League Config');
        }
      });
  }

  private updateLeague() {
    const updateLeagueModel: UpdateLeagueModel = {
      fallTeamCount: this.league.fallTeamCount,
      isHomeAway: this.league.isHomeAway,
      peerToPeerPlayCount: this.league.peerToPeerPlayCount,
      riseTeamCount: this.league.riseTeamCount,
      leagueTeams: [],
      teamCount: 0,
      drawPoint: this.league.drawPoint,
      lostPoint: this.league.lostPoint,
      wonPoint: this.league.wonPoint
    };

    this.competitionTeams.forEach(competitionTeam => {
      if (competitionTeam.selected) {
        updateLeagueModel.leagueTeams.push({
          competitionTeamId: competitionTeam.id,
          leagueId: 0
        });
      }
    });

    updateLeagueModel.teamCount = updateLeagueModel.leagueTeams.length;

    this.competitionService.updateLeague(this.league.id, updateLeagueModel)
      .subscribe(result => {
        if (result) {
          this.modalRef.hide();
          this.showSuccess('League configed successfuly', 'League Config');
        }
      });
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

            if (this.league && this.league.leagueTeams) {
              this.league.leagueTeams.forEach(leagueTeam => {
                const cteam = this.competitionTeams.find(x => x.id === leagueTeam.competitionTeamId);
                cteam.selected = cteam ? true : true;
              });
            }
          });
      });
  }
}
