import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { CompetitionService } from 'src/app/services/competition.service';
import { CompetitionModel } from 'src/app/models/competition/competition.model';
import { AddCompetitionModel } from 'src/app/models/competition/add-competition.model';
import { UpdateCompetitionModel } from 'src/app/models/competition/update-competition.model';
import { BaseSelectinoModel } from 'src/app/models/base/base-selection.model';
import { GameTypeService } from 'src/app/services/game-type.service';

@Component({
  selector: 'app-competition-modal',
  templateUrl: './competition-modal.component.html',
  styleUrls: ['./competition-modal.component.scss']
})
export class CompetitionModalComponent extends BasePage implements OnInit {
  competition: CompetitionModel;
  gameTypes: BaseSelectinoModel[];

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private modalRef: BsModalRef,
    private competitionService: CompetitionService,
    private gameTypeService: GameTypeService
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    super.ngOnInit();
    this.fetchGameTypeSelection();
  }

  public close() {
    this.modalRef.hide();
    this.onClose.next(false);
  }

  public submit() {
    if (this.competition.id && this.competition.id > 0) {
      this.updateCompetition();
    } else {
      this.addCompetition();
    }
  }

  private addCompetition() {
    const addCompetitionModel: AddCompetitionModel = {
      endDate: this.competition.endDate,
      gameTypeId: this.competition.gameTypeId,
      isCompleted: this.competition.isCompleted,
      isStarted: this.competition.isStarted,
      name: this.competition.name,
      startDate: this.competition.startDate
    };

    this.competitionService
      .addCompetition(addCompetitionModel)
      .subscribe(() => {
        this.showSuccess('Competition added successfuly', 'Add Competition');
        this.modalRef.hide();
        this.onClose.next(true);
      });
  }

  private updateCompetition() {
    const updateCompetitionModel: UpdateCompetitionModel = {
      endDate: this.competition.endDate,
      gameTypeId: this.competition.gameTypeId,
      isCompleted: this.competition.isCompleted,
      isStarted: this.competition.isStarted,
      name: this.competition.name,
      startDate: this.competition.startDate
    };
    this.competitionService
      .updateCompetition(this.competition.id, updateCompetitionModel)
      .subscribe(() => {
        this.showSuccess('Competition updated successfuly', 'Update Competition');
        this.modalRef.hide();
        this.onClose.next(true);
      });
  }

  private fetchGameTypeSelection() {
    this.gameTypeService.getGameTypesSelection()
      .subscribe(gameTypes => {
        this.gameTypes = gameTypes;
      });
  }

}
