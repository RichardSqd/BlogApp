import { Component, OnInit } from '@angular/core';
import {AuthService} from '../../services/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: [
    './layout.component.scss', 
     '../../../assets/scss/clean-blog.min.css'
  ]
})
export class LayoutComponent implements OnInit {


  isCollapsed = true;
  name: string;

  constructor(
    public authService: AuthService,
    private router: Router,
  ) {

  }

  ngOnInit() {
    this.name = '';

  }

  loggedIn() {
    const status = this.authService.loggedIn();
    if(status){
      this.name = this.authService.decodedToken.unique_name;
    }
    return status;
  }

  logout() {
    localStorage.removeItem('token');
    this.name = '';
    this.router.navigate(['/topics']);
    console.log('logged out');
  }

  getName(){
    return this.name;
  }

}
