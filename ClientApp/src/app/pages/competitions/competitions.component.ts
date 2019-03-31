import { Component, OnInit } from '@angular/core';
import { BasePage } from '../base/base-page';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { CompetitionModel } from 'src/app/models/competition/competition.model';
import { CompetitionService } from 'src/app/services/competition.service';
import { CompetitionModalComponent } from './competition-modal/competition-modal.component';
import { CompetitionTeamsModalComponent } from './competition-teams-modal/competition-teams-modal.component';
import { CompetitionStepsModalComponent } from './competition-steps-modal/competition-steps-modal.component';

@Component({
  selector: 'app-competitions',
  templateUrl: './competitions.component.html',
  styleUrls: ['./competitions.component.scss']
})
export class CompetitionsComponent extends BasePage implements OnInit {
  competitions: CompetitionModel[] = [];

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private competitionService: CompetitionService
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    this.fetchData();
  }

  public addCompetition() {
    const initialState = {
      competition: new CompetitionModel()
    };
    const bsModalRef = this.modalService.show(CompetitionModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  public updateCompetition(competition: CompetitionModel) {
    const initialState = {
      competition: { ...competition }
    };
    const bsModalRef = this.modalService.show(CompetitionModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  public selectCompetitionTeams(competition: CompetitionModel) {
    const initialState = {
      competition: { ...competition }
    };
    const bsModalRef = this.modalService.show(CompetitionTeamsModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  public setCompetitionSteps(competition: CompetitionModel) {
    const initialState = {
      competition: { ...competition }
    };
    const bsModalRef = this.modalService.show(CompetitionStepsModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      // if (result) {
      this.fetchData();
      // }
    });
  }

  public deleteCompetition(competition: CompetitionModel) {
    this.showConfirm(
      `Are you sure to delete '${competition.name}' ?`
    ).subscribe(result => {
      if (result) {
        this.competitionService
          .deleteCompetition(competition.id)
          .subscribe(result => {
            if (result) {
              this.showSuccess(
                'Competition deleted successfuly',
                'Delete Competition'
              );
              this.fetchData();
            }
          });
      }
    });
  }

  private fetchData() {
    this.competitionService.getCompetitions().subscribe(competitions => {
      this.competitions = competitions;
    });
  }
}
