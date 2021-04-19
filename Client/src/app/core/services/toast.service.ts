import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class ToastService {
  constructor(private toastr: ToastrService) { }

  success(message: string): void {
    this.toastr.success(message, 'Success', {
      positionClass: 'toast-top-right',
      timeOut: 3250
    });
  }

  error(message: string): void {
    this.toastr.error(message, 'Error', {
      positionClass: 'toast-top-right',
      timeOut: 3250
    });
  }
}
