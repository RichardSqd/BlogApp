import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
   MatSidenavModule,
   MatIconModule,
   MatToolbarModule,
   MatListModule,
   MatMenuModule,
   MatButtonModule,
   MatCheckboxModule

 } from '@angular/material';
import { JwtModule } from '@auth0/angular-jwt';

import {NgxPaginationModule} from 'ngx-pagination';
import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';
import { ValueComponent } from './value/value.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AuthService } from './services/auth.service';
import { AlertifyService } from './services/alertify.service';
import { LoginComponent} from './login/login.component';
import { MessagesComponent } from './messages/messages.component';
import { ProfileComponent } from './profile/profile.component';
import { AppRoutingModule } from './routes';
import { TopicsComponent } from './topics/topics.component';
import { FooterComponent } from './core/footer/footer.component';
import { LayoutComponent } from './core/layout/layout.component';
import { HeaderComponent } from './core/header/header.component';
import { PostComponent } from './post/post.component';
import { MyaccountComponent } from './myaccount/myaccount.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { UserResolver } from './resolver/user.resolver';
import { PostListResolver } from './resolver/postlist.resolver';
import {PostResolver} from './resolver/post.resolver';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserService } from './services/user.service';
import { PreventUnsavedGuard } from './guards/prevent-unsaved.guard';
import { NgxLoadingModule } from 'ngx-loading';
import { TagComponent } from './tag/tag.component';

export function tokenFetcher(){
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      ValueComponent,
      HomeComponent,
      RegisterComponent,
      LoginComponent,
      MessagesComponent,
      ProfileComponent,
      TopicsComponent,
      FooterComponent,
      LayoutComponent,
      HeaderComponent,
      MyaccountComponent,
      PostComponent,
      PageNotFoundComponent,
      TagComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      CollapseModule.forRoot(),
      CarouselModule.forRoot(),
      NgxLoadingModule.forRoot({}),
      NgxPaginationModule,
      BrowserAnimationsModule,
      AppRoutingModule,
      MatSidenavModule,
      MatIconModule,
      MatToolbarModule,
      MatListModule,
      MatButtonModule,
      MatMenuModule,
      MatCheckboxModule,
      NgbModule,
      ReactiveFormsModule,
      JwtModule.forRoot({
         config:{
            tokenGetter: tokenFetcher,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      AlertifyService,
      UserService,
      UserResolver,
      PostListResolver,
      PostResolver,
      PreventUnsavedGuard
      
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
