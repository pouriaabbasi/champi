import { Injectable } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';

@Injectable({
  providedIn: 'root'
})
export abstract class BasePage {

  constructor(
    protected modalService: BsModalService
  ) { }
}
