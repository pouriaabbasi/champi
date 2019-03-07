import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/operators';
import { ApiResultModel } from 'src/app/models/base/api-result.model';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class BaseService {

  baseUrl = 'http://localhost:5000/api/';

  constructor(
    protected http: HttpClient
  ) { }

  protected get<T>(url: string): Observable<T> {
    return this.http
      .get<ApiResultModel<T>>(this.baseUrl + url)
      .pipe(
        map(result => result.data)
      );
  }
}
