import { Component, OnInit } from "@angular/core";
import { GameTypeService } from "src/app/services/game-type.service";
import { GameTypeModel } from "src/app/models/game-type/game-type.model";
import { BsModalService } from "ngx-bootstrap/modal";
import { GameTypeModalComponent } from "./game-type-modal/game-type-modal.component";
import { BasePage } from "../base/base-page";

@Component({
  selector: "app-game-types",
  templateUrl: "./game-types.component.html",
  styleUrls: ["./game-types.component.scss"]
})
export class GameTypesComponent extends BasePage implements OnInit {
  gameTypes: GameTypeModel[] = [];

  constructor(
    protected modalService: BsModalService,
    private gameTypeService: GameTypeService
  ) {
    super(modalService);
  }

  ngOnInit() {
    this.fetchData();
  }

  public addGameType() {
    const initialState = {
      gameType: new GameTypeModel()
    };
    const bsModalRef = this.modalService.show(GameTypeModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  public updateGameType(gameType: GameTypeModel) {
    const initialState = {
      gameType: gameType
    };
    const bsModalRef = this.modalService.show(GameTypeModalComponent, {
      initialState
    });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  private fetchData(): void {
    this.gameTypeService.getGameTypes().subscribe(gameTypes => {
      this.gameTypes = gameTypes;
    });
  }
}
