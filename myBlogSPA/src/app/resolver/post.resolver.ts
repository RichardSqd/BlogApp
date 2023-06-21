import {Injectable} from '@angular/core';
import {Post } from '../shared/models/Post';
import { Resolve, Router, ActivatedRouteSnapshot, RouterState, RouterStateSnapshot } from '@angular/router';
import {PostService} from '../services/post.service';
import { AlertifyService } from '../services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
@Injectable()
export class PostResolver implements Resolve<Post>{
    postId = 0;
    constructor(
        private postService: PostService,
        private router: Router,
        private alertify: AlertifyService
    ){}

    resolve(
        route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ): Observable<Post> {
        if(route.params.id != null){
            this.postId = route.params.id;
        }
        return this.postService.getPost(this.postId).pipe(
            catchError(error => {
                this.alertify.error('Failed fetching post: #'+this.postId);
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}