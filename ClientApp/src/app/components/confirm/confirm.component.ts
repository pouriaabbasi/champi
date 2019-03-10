import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { Subject } from "rxjs";

@Component({
  selector: "app-confirm",
  templateUrl: "./confirm.component.html",
  styleUrls: ["./confirm.component.scss"]
})
export class ConfirmComponent implements OnInit {
  onClose: Subject<boolean>;
  message: string;

  constructor(private bsModalRef: BsModalRef) {}

  ngOnInit() {
    this.onClose = new Subject();
  }

  public confirm() {
    this.bsModalRef.hide();
    this.onClose.next(true);
  }

  public decline() {
    this.bsModalRef.hide();
    this.onClose.next(false);
  }
}
