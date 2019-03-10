import { Injectable, OnInit } from "@angular/core";
import { Subject } from "rxjs";

@Injectable({
  providedIn: "root"
})
export abstract class ChildBasePage implements OnInit {
  protected onClose: Subject<boolean>;

  constructor() {}

  ngOnInit(): void {
    this.onClose = new Subject();
  }
}
