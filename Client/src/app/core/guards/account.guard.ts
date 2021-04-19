import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AccountGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }
  canActivate(_: ActivatedRouteSnapshot, __: RouterStateSnapshot) {
    return (this.authService.isLoggedIn) ? true : this.router.parseUrl('/login');
  }
}
