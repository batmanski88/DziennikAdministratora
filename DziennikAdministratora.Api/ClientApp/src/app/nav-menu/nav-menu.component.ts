import { Component, OnInit, OnChanges } from '@angular/core';
import { LoginService } from '../../Services/login.service';
import { Role } from '../models/role';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  public get loggedIn(): boolean {
    return this.loginService.isAuthenticated();
  }
  public get isSuperAdmin(): boolean {
    return this.superAdmin();
  }
  constructor(private loginService: LoginService) {
  }
  userRoles: Role[];
  logout() {
    this.loginService.logOut();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  superAdmin(): boolean {
    this.userRoles = JSON.parse(sessionStorage.getItem('roles'));

    for (const i in this.userRoles) {
      if (this.userRoles[i].name === 'SuperAdmin') {
        return true;
      }
    }
  }
}
