import { Component, OnInit } from "@angular/core";
import { ChildBasePage } from "src/app/pages/base/child-base-page";
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: "app-confirm",
  templateUrl: "./confirm.component.html",
  styleUrls: ["./confirm.component.scss"]
})
export class ConfirmComponent extends ChildBasePage implements OnInit {
  message: string;

  constructor(
    private bsModalRef: BsModalRef
  ) {
    super();
  }

  ngOnInit() {
    super.ngOnInit();
  }

  public confirm() {
    this.bsModalRef.hide();
    this.onClose.next(true);
  }

  public decline(){
    this.bsModalRef.hide();
    this.onClose.next(false);
  }
}
