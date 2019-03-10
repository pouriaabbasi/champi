import { Component, OnInit } from "@angular/core";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { GameTypeModel } from "src/app/models/game-type/game-type.model";
import { GameTypeService } from "src/app/services/game-type.service";
import { AddGameTypeModel } from "src/app/models/game-type/add-game-type-model";
import { UpdateGameTypeModel } from "src/app/models/game-type/update-game-type.model";
import { BasePage } from '../../base/base-page';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: "app-game-type-modal",
  templateUrl: "./game-type-modal.component.html",
  styleUrls: ["./game-type-modal.component.scss"]
})
export class GameTypeModalComponent extends BasePage implements OnInit {
  gameType: GameTypeModel;

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private bsModalRef: BsModalRef,
    private gameTypeService: GameTypeService
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    super.ngOnInit();
  }

  public close() {
    this.bsModalRef.hide();
    this.onClose.next(false);
  }

  public submit() {
    if (this.gameType.id && this.gameType.id > 0) {
      this.updateGameType();
    } else {
      this.addGameType();
    }
  }

  private addGameType() {
    const addGameTypeModel: AddGameTypeModel = {
      name: this.gameType.name
    };
    this.gameTypeService.addGameType(addGameTypeModel).subscribe(() => {
      this.showSuccess('Game Type added successfuly', 'Add Game Type');
      this.bsModalRef.hide();
      this.onClose.next(true);
    });
  }

  private updateGameType() {
    const addGameTypeModel: UpdateGameTypeModel = {
      name: this.gameType.name
    };
    this.gameTypeService
      .updateGameType(this.gameType.id, addGameTypeModel)
      .subscribe(() => {
        this.showSuccess('Game Type updated successfuly', 'Update Game Type');
        this.bsModalRef.hide();
        this.onClose.next(true);
      });
  }
}
