import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ToastService } from './toast.service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient, private toastService: ToastService) { }

  get(path: string): Observable<any> {
    return this.http.get(path)
      .pipe(
        tap(() => { },
          (err: HttpErrorResponse) => this.toastService.error(err.status == 403 ? 'Insufficient permissions' : err.error.Message ? err.error.Message : err.message))
      );
  }

  post(path: string, payload: any): Observable<any> {
    return this.http.post(path, payload)
      .pipe(
        tap(() => { },
          (err: HttpErrorResponse) => this.toastService.error(err.status == 403 ? 'Insufficient permissions' : err.error.Message ? err.error.Message : err.message))
      );
  }
}
