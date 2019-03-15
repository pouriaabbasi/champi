import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionModel } from 'src/app/models/competition/competition.model';
import { UpdateCompetitionStepsModel } from 'src/app/models/competition/update-competition-steps.model';
import { CompetitionStepModel } from 'src/app/models/competition/competition-step.model';
import { CompetitionService } from 'src/app/services/competition.service';

@Component({
  selector: 'app-competition-steps-modal',
  templateUrl: './competition-steps-modal.component.html',
  styleUrls: ['./competition-steps-modal.component.scss']
})
export class CompetitionStepsModalComponent extends BasePage implements OnInit {
  competition: CompetitionModel;
  tempStep: UpdateCompetitionStepsModel;
  competitionSteps: CompetitionStepModel[] = [];

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
    this.tempStep = new UpdateCompetitionStepsModel();
  }

  public addStep() {
    this.competitionSteps.push({
      competitionId: this.competition.id,
      competitionType: this.tempStep.competitionType,
      // tslint:disable-next-line:triple-equals
      competitionTypeString: this.tempStep.competitionType == 1 ? 'League' : (this.tempStep.competitionType == 2 ? 'Group' : 'Knockout'),
      endDate: this.tempStep.endDate,
      id: 0,
      endDatePersian: '',
      isCompleted: this.tempStep.isCompleted,
      isStarted: this.tempStep.isStarted,
      startDate: this.tempStep.startDate,
      startDatePersian: '',
      step: this.competitionSteps.length + 1
    });

    this.tempStep = new UpdateCompetitionStepsModel();
  }

  public removeStep(competitionStepModel: CompetitionStepModel) {
    const index = this.competitionSteps.findIndex(x => x.step === competitionStepModel.step);
    if (index !== -1) {
      this.competitionSteps.splice(index, 1);
    }
  }

  public close() {
    this.modalRef.hide();
    this.onClose.next(false);
  }

  public submit() {
    const model: UpdateCompetitionStepsModel[] = [];
    this.competitionSteps.forEach(step => {
      model.push({
        competitionType: step.competitionType,
        endDate: step.endDate,
        isCompleted: step.isCompleted,
        isStarted: step.isStarted,
        startDate: step.startDate
      });
    });

    this.competitionService.updateCompetitionSteps(this.competition.id, model)
      .subscribe(result => {
        if (result) {
          this.showSuccess('Competition Steps updated successfuly', 'Update Competition Steps');
          this.modalRef.hide();
          this.onClose.next(true);
        }
      });
  }

  private fetchData() {
    this.competitionService.getCompetitionSteps(this.competition.id)
      .subscribe(competitionSteps => {
        this.competitionSteps = competitionSteps;
      });
  }

}
