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

  logOut() {
    this.authService.logOut();
  }

}
