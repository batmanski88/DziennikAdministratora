import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { RoleService } from '../Services/role.service';
import { UserService } from '../Services/user.service';
import { LoginService } from '../Services/login.service';
import { AdminComponent } from './admin/admin.component';
import { FetchRoleComponent } from './role/fetchrole.component';
import { AddRole } from './role/addrole.component';
import { FetchUserComponent } from './user/fethusers.component';
import { AddUser } from './user/adduser.component';
import { DateFormatPipe } from './customPipes/dateformatpipe';
import { LoginUser } from './login/login.component';
import { NavAdminComponent } from './navadmin/navadmin.component';
import { HttpModule } from '@angular/http';
import { AuthGuard } from './guards';
import { AlertService } from '../Services/alert.service';
import { AlertComponent } from './alerts/alert.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    HomeComponent, 
    FetchRoleComponent,
    AddRole,
    FetchUserComponent,
    AddUser,
    DateFormatPipe,
    LoginUser,
    AdminComponent,
    NavAdminComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'admin', component: AdminComponent, children: [
        { path: 'roles', component: FetchRoleComponent },
        { path: 'addrole', component: AddRole },
        { path: 'role/edit/:id', component: AddRole},
        { path: 'users', component: FetchUserComponent},
        { path: 'adduser', component: AddUser},
        { path: 'user/edit/:id', component: AddUser}
    ]},
      { path: 'login', component: LoginUser}
    ])
  ],
  providers: [
    RoleService,
    UserService,
    LoginService,
    AuthGuard,
    AlertService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
