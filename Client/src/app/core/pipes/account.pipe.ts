import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'account'
})
export class AccountPipe implements PipeTransform {

  transform(value: any[], account: number): number {
    return value.find(x => x.accountTypeId == account).funds;
  }

}
