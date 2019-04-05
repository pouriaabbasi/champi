import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { UserModel } from 'src/app/models/user/user.model';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  user: UserModel

  constructor(
    private userService: UserService
  ) { }

  ngOnInit() {
    this.userService.currentUser
      .subscribe(user => {
        this.user = user;
      });
  }

}
