import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../services/alertify.service';
import { Post} from '../shared/models/Post';
import { Resolve, Router, ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Pagination } from '../shared/models/Pagination';
import { PostService } from '../services/post.service';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: [
    './home.component.scss',
    '../../assets/scss/clean-blog.min.css',
    '../../assets/scss/moonglade-base.css',
    '../../assets/scss/moonglade-rwd.css',
    '../../assets/scss/bootstrap-social.css'
    
  ]
})
export class HomeComponent implements OnInit {

  posts: Post[];
  images: any;
  pagination: Pagination;
  constructor(
    private alertifyService: AlertifyService,
    private route: ActivatedRoute,
    private router: Router,
    private postService: PostService
    ) {
      this.posts = {} as Post[];
    }

  ngOnInit() {

    this.route.queryParams.subscribe(params => {this.loadPosts(params.page);});
   
    this.images = [
      'https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/NGC_4414_%28NASA-med%29.jpg/1451px-NGC_4414_%28NASA-med%29.jpg',
      'assets/img/one.png',
      'assets/img/two.jpg',
      'assets/img/three.jpg'
    ];
    // this.route.data.subscribe(({postlist})  => {
    //   this.posts = postlist.result;
    //   this.pagination = postlist.pagination;
    // },error=>{
    //   console.log(error);
    // });

    // if(this.posts==null || this.pagination==null){
    //   this.router.navigate(['/home']);
    // }

  }

  loadPosts(pageNum){

    if(pageNum==null){
      pageNum = 1;
    }
    this.postService.getPosts(pageNum,5).subscribe((postlist)  => {
      this.posts = postlist.result.reverse();
      this.pagination = postlist.pagination;
    },error=>{
      console.log(error);
    });
    this.posts[0] = this.posts[1];
    

  }

  nextPage(){
    let next = this.pagination.currentPage+1;
    this.router.navigate([''],{ queryParams: { page: next.toString() } });
    //console.log(this.pagination.currentPage+1);
  }

  runsuccess() {
    this.alertifyService.success('Alertify Success');
  }

}
