import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { tap, take } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DataService } from './data.service';

const JWT = new JwtHelperService();

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = this.checkLogin();
  userId: any;
  accounts: any;
  roleId = this.getRoleId();

  constructor(private dataService: DataService, private router: Router) { }

  get currentToken() { return localStorage.getItem('auth'); }

  login(payload: any): Observable<any> {
    return this.dataService.post('auth/login', payload)
      .pipe(
        tap((res) => this.setLogin(res))
      );
  }

  setLogin(user: any): void {
    this.isLoggedIn = true;
    localStorage.setItem('auth', user.token);
    this.roleId = this.getRoleId();
    this.userId = user.userId;
    localStorage.setItem('UserId', this.userId);
    this.getAccounts();
    this.router.navigateByUrl('/home');
  }

  logOut() {
    this.isLoggedIn = false;
    localStorage.clear();
    this.roleId = null;
    this.userId = null;
    this.accounts = null;
    this.router.navigateByUrl('/login');
  }

  getRoleId(): number {
    const decodedToken = JWT.decodeToken(localStorage.getItem('auth'));
    if (decodedToken) {
      return +decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    }
    return null;
  }

  checkLogin(): boolean {
    let ans = false;
    const token = this.currentToken;
    if (token) {
      ans = !this.isTokenExpired(token);
    }
    if (ans) {
      this.userId = +localStorage.getItem('UserId');
      this.getAccounts();
    }
    return ans;
  }

  isTokenExpired(token: any): boolean {
    return JWT.isTokenExpired(token);
  }

  getAccounts(): void {
    this.dataService.get('account/GetAccounts/' + this.userId)
      .pipe(
        take(1)
      )
      .subscribe({
        next: (res) => this.accounts = res
      });
  }
}
