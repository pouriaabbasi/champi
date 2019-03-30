import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { LeagueResultModel } from 'src/app/models/competition/league-result.model';
import { CompetitionStepModel } from 'src/app/models/competition/competition-step.model';
import { CompetitionService } from 'src/app/services/competition.service';

@Component({
  selector: 'app-competition-league-result',
  templateUrl: './competition-league-result.component.html',
  styleUrls: ['./competition-league-result.component.scss']
})
export class CompetitionLeagueResultComponent extends BasePage implements OnInit {

  competitionStep: CompetitionStepModel;
  leagueResult: LeagueResultModel[];

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

  private fetchData() {
    this.competitionService.getLeagueResult(this.competitionStep.id)
      .subscribe(result => {
        this.leagueResult = result;
      });
  }
}
