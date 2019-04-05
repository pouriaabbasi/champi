import { Component, OnInit } from '@angular/core';
import { LoginModel } from 'src/app/models/user/login.model';
import { UserService } from 'src/app/services/user.service';
import { BasePage } from '../base/base-page';
import { BsModalService } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends BasePage implements OnInit {

  model: LoginModel = new LoginModel();
  returnUrl: string;

  constructor(
    protected modalService: BsModalService,
    protected toastrService: ToastrService,
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    super(modalService, toastrService);
  }

  ngOnInit() {
    super.ngOnInit();
    this.userService.logout();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  public login() {
    this.userService.login(this.model)
      .subscribe(result => {
        if (result) {
          this.showSuccess('U login successfully', 'Login');
          this.router.navigate([this.returnUrl]);
        }
      });
  }

}
