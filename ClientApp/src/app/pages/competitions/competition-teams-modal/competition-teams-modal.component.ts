import { Component, OnInit } from "@angular/core";
import { BasePage } from "../../base/base-page";
import { BsModalService } from "ngx-bootstrap";
import { ToastrService } from "ngx-toastr";
import { CompetitionModel } from "src/app/models/competition/competition.model";
import { CompetitionService } from "src/app/services/competition.service";
import { TeamService } from "src/app/services/team.service";
import {
  IMultiSelectOption,
  IMultiSelectSettings,
  IMultiSelectTexts
} from "angular-2-dropdown-multiselect";

@Component({
  selector: "app-competition-teams-modal",
  templateUrl: "./competition-teams-modal.component.html",
  styleUrls: ["./competition-teams-modal.component.scss"]
})
export class CompetitionTeamsModalComponent extends BasePage implements OnInit {
  competition: CompetitionModel;
  optionsModel: number[];
  myOptions: IMultiSelectOption[] = [];
  mySettings: IMultiSelectSettings = {
    enableSearch: true
  };
  myTexts: IMultiSelectTexts = {
    defaultTitle:'تیم های مورد نظر را انتخاب نمایید'
  };

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private competitionService: CompetitionService,
    private teamService: TeamService
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    super.ngOnInit();
    this.fetchData();
  }

  private fetchData() {
    this.teamService.getTeamSelections().subscribe(selections => {
      selections.forEach(element => {
        debugger
        this.myOptions.push({
          id: element.key,
          name: element.caption
        });
      });
    });
  }
}
