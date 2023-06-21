import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanDeactivate } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';
import { MyaccountComponent } from '../myaccount/myaccount.component';

@Injectable({
  providedIn: 'root'
})

export class PreventUnsavedGuard implements CanDeactivate<MyaccountComponent> {
  constructor(
    private authService: AuthService,
    private router: Router,
    private alertifyService: AlertifyService
  ) {}


  canDeactivate(component: MyaccountComponent) {
    if (component.emailForm.dirty) {
      return confirm('Are you sure you want to continue? Unsaved changes will be lost!');
    }
    return true;
  }
}
