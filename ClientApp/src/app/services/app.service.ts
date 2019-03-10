import { Injectable } from "@angular/core";
import { BsModalService } from "ngx-bootstrap/modal";
import { ConfirmComponent } from "../components/confirm/confirm.component";
import { Observable, Subject } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class AppService {
  isSidebarPinned = false;
  isSidebarToggeled = false;

  constructor(private modalService: BsModalService) {}

  toggleSidebar() {
    this.isSidebarToggeled = !this.isSidebarToggeled;
  }

  toggleSidebarPin() {
    this.isSidebarPinned = !this.isSidebarPinned;
  }

  getSidebarStat() {
    return {
      isSidebarPinned: this.isSidebarPinned,
      isSidebarToggeled: this.isSidebarToggeled
    };
  }

  showConfirm(message: string): Subject<boolean> {
    const modalRef = this.modalService.show(ConfirmComponent, {
      initialState: { message: message },
      class: "modal-dialog"
    });
    return modalRef.content.onClose;
  }
}
