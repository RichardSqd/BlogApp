import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { AlertifyService } from '../services/alertify.service';
import { Router } from '@angular/router';
import { User } from '../shared/models/User';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @Input() loginMode: boolean;
  user: User;
  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    private alertifyService: AlertifyService,
    private router: Router
    ) { }

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(16)]),
      remember: new FormControl(false)
    });
  }


  login(){
    if(this.loginForm.valid){
      this.user = Object.assign({}, this.loginForm.value);
      console.log(this.user);
      this.authService.login(this.user, this.loginForm.value.remember).subscribe(next => {
        this.alertifyService.success('Login Success!');
        this.router.navigate(['/home']);
      }, error => {
        this.alertifyService.error(error);
      });
    };
  }

  loggedIn(){
    return this.authService.loggedIn();
  }

  logout(){
    localStorage.removeItem('token');
    console.log('logged out');
  }

  // toggledLogin(){
  //   const token = localStorage.getItem('token');
  //   return this.loginMode && !(!!token);
  // }
}
