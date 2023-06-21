import {Injectable} from '@angular/core';
import {User } from '../shared/models/User';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import {UserService} from '../services/user.service';
import { AlertifyService } from '../services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
@Injectable()
export class UserResolver implements Resolve<User> {
    constructor(
        private userService: UserService,
        private router: Router,
        private alertify: AlertifyService
        ){}

    resolve(route: ActivatedRouteSnapshot): Observable<User>{
        return this.userService.getUser(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error('cant fetch data');
                this.router.navigate(['/home']);
                return of(null);
            })
        )
    }
}