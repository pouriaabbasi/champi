import { Component, OnInit } from "@angular/core";
import { BasePage } from "../../base/base-page";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { ToastrService } from "ngx-toastr";
import { TeamModel } from "src/app/models/team/team.model";
import { AddTeamModel } from "src/app/models/team/add-team.model";
import { TeamService } from "src/app/services/team.service";
import { UpdateTeamModel } from "src/app/models/team/update-team.model";

@Component({
  selector: "app-team-modal",
  templateUrl: "./team-modal.component.html",
  styleUrls: ["./team-modal.component.scss"]
})
export class TeamModalComponent extends BasePage implements OnInit {
  team: TeamModel;

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private bsModalRef: BsModalRef,
    private teamService: TeamService
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
    if (this.team.id && this.team.id > 0) {
      this.updateTeam();
    } else {
      this.addTeam();
    }
  }

  private addTeam() {
    const addTeamModel: AddTeamModel = {
      name: this.team.name,
      abbreviationName: this.team.abbreviationName
    };
    this.teamService.addTeam(addTeamModel).subscribe(() => {
      this.showSuccess("Team added successfuly", "Add Team");
      this.bsModalRef.hide();
      this.onClose.next(true);
    });
  }

  private updateTeam() {
    const updateTeamModel: UpdateTeamModel = {
      name: this.team.name,
      abbreviationName: this.team.abbreviationName
    };
    this.teamService
      .updateTeam(this.team.id, updateTeamModel)
      .subscribe(() => {
        this.showSuccess("Team updated successfuly", "Update Team");
        this.bsModalRef.hide();
        this.onClose.next(true);
      });
  }
}
