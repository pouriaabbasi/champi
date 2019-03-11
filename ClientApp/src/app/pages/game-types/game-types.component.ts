import { Component, OnInit } from "@angular/core";
import { GameTypeService } from "src/app/services/game-type.service";
import { GameTypeModel } from "src/app/models/game-type/game-type.model";
import { BsModalService } from "ngx-bootstrap/modal";
import { GameTypeModalComponent } from "./game-type-modal/game-type-modal.component";
import { BasePage } from "../base/base-page";
import { ToastrService } from "ngx-toastr";

@Component({
  selector: "app-game-types",
  templateUrl: "./game-types.component.html",
  styleUrls: ["./game-types.component.scss"]
})
export class GameTypesComponent extends BasePage implements OnInit {
  gameTypes: GameTypeModel[] = [];

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private gameTypeService: GameTypeService
  ) {
    super(modalService, toastrService);
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
      gameType: { ...gameType }
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

  public deleteGameType(gameType: GameTypeModel) {
    this.showConfirm(`Are you sure to delete '${gameType.name}' ?`).subscribe(
      result => {
        if (result) {
          this.gameTypeService.deleteGameType(gameType.id).subscribe(result => {
            if (result) {
              this.showSuccess('Game Type deleted successfuly', 'Delete Game Type');
              this.fetchData();
            }
          });
        }
      }
    );
  }

  private fetchData(): void {
    this.gameTypeService.getGameTypes().subscribe(gameTypes => {
      this.gameTypes = gameTypes;
    });
  }
}
