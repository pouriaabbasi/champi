import { Component, OnInit } from '@angular/core';
import { GameTypeModel } from 'src/app/models/game-type/game-type.mode';
import { GameTypeService } from 'src/app/services/game-type.service';

@Component({
  selector: 'app-game-type',
  templateUrl: './game-type.component.html',
  styleUrls: ['./game-type.component.css']
})
export class GameTypeComponent implements OnInit {

  gameTypes: GameTypeModel[] = [];

  constructor(
    private gameTypeService: GameTypeService
  ) { }

  ngOnInit() {
    this.fetchData();
  }

  private fetchData() {
    this.gameTypeService.getGameTypes().subscribe(result => {
      this.gameTypes = result;
    });
  }
}
