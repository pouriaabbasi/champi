import { Component, OnInit } from "@angular/core";
import { BsModalRef } from "ngx-bootstrap/modal";
import { GameTypeModel } from "src/app/models/game-type/game-type.model";
import { Subject } from "rxjs";
import { GameTypeService } from "src/app/services/game-type.service";
import { AddGameTypeModel } from "src/app/models/game-type/add-game-type-model";
import { UpdateGameTypeModel } from "src/app/models/game-type/update-game-type.model";
import { ChildBasePage } from "../../base/child-base-page";

@Component({
  selector: "app-game-type-modal",
  templateUrl: "./game-type-modal.component.html",
  styleUrls: ["./game-type-modal.component.scss"]
})
export class GameTypeModalComponent extends ChildBasePage implements OnInit {
  gameType: GameTypeModel;

  constructor(
    private bsModalRef: BsModalRef,
    private gameTypeService: GameTypeService
  ) {
    super();
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
        this.bsModalRef.hide();
        this.onClose.next(true);
      });
  }
}
