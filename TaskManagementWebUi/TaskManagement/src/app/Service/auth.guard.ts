import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard {

  constructor(private router: Router,  private auth: AuthService) { }

  canActivate(route: ActivatedRouteSnapshot,
      state: RouterStateSnapshot): boolean {
      if (!this.auth.authenticated) {
          this.router.navigateByUrl("/login");
          return false;
      }
      return true;
  }
}
