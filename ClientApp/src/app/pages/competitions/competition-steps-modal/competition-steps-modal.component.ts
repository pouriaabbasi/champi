import { Component, OnInit } from '@angular/core';
import { BasePage } from '../../base/base-page';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CompetitionModel } from 'src/app/models/competition/competition.model';

@Component({
  selector: 'app-competition-steps-modal',
  templateUrl: './competition-steps-modal.component.html',
  styleUrls: ['./competition-steps-modal.component.scss']
})
export class CompetitionStepsModalComponent extends BasePage implements OnInit {
  competition: CompetitionModel;

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private modalRef: BsModalRef
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    super.ngOnInit();
  }

  public close() {
    this.modalRef.hide();
    this.onClose.next(false);
  }

  public submit() {

  }

}
