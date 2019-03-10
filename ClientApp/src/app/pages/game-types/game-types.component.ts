import { Component, OnInit } from '@angular/core';
import { GameTypeService } from 'src/app/services/game-type.service';
import { GameTypeModel } from 'src/app/models/game-type/game-type.model';
import { BsModalService } from 'ngx-bootstrap/modal';
import { GameTypeModalComponent } from './game-type-modal/game-type-modal.component';

@Component({
  selector: 'app-game-types',
  templateUrl: './game-types.component.html',
  styleUrls: ['./game-types.component.scss']
})
export class GameTypesComponent implements OnInit {

  gameTypes: GameTypeModel[] = [];

  constructor(
    private modalService: BsModalService,
    private gameTypeService: GameTypeService
  ) { }

  ngOnInit() {
    this.fetchData();
  }

  public addGameType() {
    const initialState = {
      gameType: new GameTypeModel()
    };
    const bsModalRef = this.modalService.show(GameTypeModalComponent, { initialState });
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
    const bsModalRef = this.modalService.show(GameTypeModalComponent, { initialState });
    bsModalRef.content.onClose.subscribe((result: boolean) => {
      if (result) {
        this.fetchData();
      }
    });
  }

  private fetchData(): void {
    this.gameTypeService.getGameTypes()
      .subscribe(gameTypes => {
        this.gameTypes = gameTypes;
      });
  }

}
