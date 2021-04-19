import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { AuthService } from 'src/app/core/services/auth.service';
import { DataService } from 'src/app/core/services/data.service';
import { ToastService } from 'src/app/core/services/toast.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(public dataService: DataService, public authService: AuthService, private toastService: ToastService) { }

  ngOnInit(): void { }

  transferFunds(fromAccountId: number, toAccountId: number, amount: number): void {
    if (amount < 0) {
      this.toastService.error('Amount can\'t be less than 0');
    }
    this.dataService.post('Account/TransferFunds',
      {
        amount,
        fromAccountId: this.authService.accounts.find((x: any) => x.accountTypeId == fromAccountId).accountId,
        toAccountId: this.authService.accounts.find((x: any) => x.accountTypeId == toAccountId).accountId
      })
      .pipe(
        take(1)
      )
      .subscribe({
        next: () => {
          this.authService.getAccounts();
          this.toastService.success('Funds transfered');
        }
      })
  }

  christmasGift() {
    this.dataService.post('admin/AddChristmasGift', null)
      .pipe(
        take(1)
      )
      .subscribe({
        next: () => this.authService.getAccounts()
      });
  }

  logOut() {
    this.authService.logOut();
  }

}
