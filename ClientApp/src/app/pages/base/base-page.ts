import { Injectable, OnInit } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ConfirmComponent } from 'src/app/components/confirm/confirm.component';
import { Subject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export abstract class BasePage implements OnInit {
  protected onClose: Subject<boolean>;

  constructor(
    protected modalService: BsModalService,
    protected toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.onClose = new Subject();
  }

  public showConfirm(message: string): Subject<boolean> {
    const modalRef = this.modalService.show(ConfirmComponent, {
      initialState: { message: message },
      class: 'modal-dialog'
    });
    return modalRef.content.onClose;
  }

  public showSuccess(message: string, title: string) {
    this.toastr.success(message, title);
  }

  public showInfo(message: string, title: string) {
    this.toastr.info(message, title);
  }

  public showWarning(message: string, title: string) {
    this.toastr.warning(message, title);
  }

  public showError(message: string, title: string) {
    this.toastr.error(message, title);
  }
}
