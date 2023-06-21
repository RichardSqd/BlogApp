import { Component, OnInit, SecurityContext, ViewEncapsulation } from '@angular/core';
// import { AlertifyService } from '../services/alertify.service';
import { Post} from '../shared/models/Post';
import { Resolve, Router, ActivatedRoute } from '@angular/router';
import { Route } from '@angular/compiler/src/core';
import { AlertifyService } from '../services/alertify.service';
import { DomSanitizer, SafeResourceUrl, SafeUrl} from '@angular/platform-browser';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: [
    './post.component.css',
    '../../assets/scss/clean-blog.min.css'
  ],
  encapsulation: ViewEncapsulation.None,

})
export class PostComponent implements OnInit {

  post: Post;
  constructor(
    // private alertifyService: AlertifyService,
    private route: ActivatedRoute,
    private r: Router,
    private alertifyService: AlertifyService,
    private sanitizer: DomSanitizer
  ) { 
  }

  ngOnInit() {
    this.route.data.subscribe(({post}) => {
      this.post = post;
      this.post.content = this.sanitizer.sanitize(SecurityContext.HTML, this.post.content);

    }, error => {
      this.alertifyService.error(error);
    });

    
  }

}
