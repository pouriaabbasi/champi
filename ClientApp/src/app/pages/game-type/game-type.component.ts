import { Component, OnInit, Renderer2, Inject } from '@angular/core';
import { GameTypeModel } from 'src/app/models/game-type/game-type.mode';
import { GameTypeService } from 'src/app/services/game-type.service';
import { DOCUMENT } from '@angular/platform-browser';
import { BaseComponent } from '../base/base/base.component';

@Component({
  selector: 'app-game-type',
  templateUrl: './game-type.component.html',
  styleUrls: ['./game-type.component.css']
})
export class GameTypeComponent extends BaseComponent implements OnInit {

  gameTypes: GameTypeModel[] = [];

  constructor(
    protected renderer2: Renderer2,
    @Inject(DOCUMENT) protected document,
    private gameTypeService: GameTypeService
  ) {
    super(renderer2, document);
  }

  ngOnInit() {
    this.fetchData();
  }

  private fetchData() {
    this.gameTypeService.getGameTypes().subscribe(result => {
      this.gameTypes = result;
      super.SetDataTable('gameTypesTable');
    });
  }
}
