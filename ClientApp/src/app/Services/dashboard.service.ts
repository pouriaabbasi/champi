import { Injectable } from '@angular/core';
import { BaseService } from '../services/base/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StatisticsModel } from '../models/dashboard/statistics.model';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class DashboardService extends BaseService {

  constructor(
    protected http: HttpClient,
    protected toastr: ToastrService
  ) {
    super(http, toastr);
  }

  public getStatistics(): Observable<StatisticsModel> {
    return super.get('Dashboard/GetStatistics');
  }
}
