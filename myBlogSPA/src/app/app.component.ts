import { Component, OnInit } from '@angular/core';
import {AuthService} from './services/auth.service';
import {JwtHelperService} from '@auth0/angular-jwt';
import {
  Router, RouterEvent,
  NavigationStart,
   NavigationEnd,
   NavigationCancel,
   NavigationError
} from '@angular/router';

// import {ViewChild, ElementRef} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  // @ViewChild('sidenav', {static: false}) sidenavRef: ElementRef;

  snavStatus: any;
  jwtHelper = new JwtHelperService();
  loading = true;

  constructor(
    private authService: AuthService,
    private router: Router
    ) {
      router.events.subscribe((event: RouterEvent) => {
        this.navigationInterceptor(event);
      }); 
    }

  ngOnInit(){
    this.loading = true;
    this.snavStatus = false;
    const token = localStorage.getItem('token');
    if(token){
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }
    this.loading = false;
  }

  navigationInterceptor(event: RouterEvent){
    if(event instanceof NavigationStart){
      this.loading = true;
    }
    if(event instanceof NavigationEnd){
      this.loading = false;
    }
    if(event instanceof NavigationCancel){
      this.loading = false;
    }
    if(event instanceof NavigationError){
      this.loading = false;
    }
  }


  // getSnavMode($event){
  //   this.snavStatus = $event;
  // }

  

}
