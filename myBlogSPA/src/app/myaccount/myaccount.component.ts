import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../services/user.service';
import { AlertifyService } from '../services/alertify.service';
import { User } from '../shared/models/User';
import { AuthService } from '../services/auth.service';
import { ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-myaccount',
  templateUrl: './myaccount.component.html',
  styleUrls: ['./myaccount.component.css']
})
export class MyaccountComponent implements OnInit {
  @ViewChild('emailForm',{static:true}) emailForm: NgForm;
  user: User;
  id: number;
  
  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private authService: AuthService,
    private route: ActivatedRoute
  ) {
    this.user = {} as User;
   }


  ngOnInit() {
    this.id = this.authService.decodedToken.nameid;
    this.loadUserInfo(this.id);
  }

  loadUserInfo(id: number) {
    this.userService.getUser(id).subscribe((user: User) => {
      this.user = user;
      console.log('loaded user success:' + user.userName);
    }, error => {
      this.alertify.error(error);
    });
  }

  onSubmit(){
    console.log('email got:' + this.user.email);
    console.log('profession got:' + this.user.profession);
    this.userService.updateUser(this.id, this.user).subscribe(next =>{
      this.alertify.success('Profile update success!');
      this.emailForm.reset(this.user);
    }, error => {
      this.alertify.error(error);
    }
    );
  }



}
