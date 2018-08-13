import { Component, OnInit, OnChanges } from '@angular/core';
import { LoginService } from '../../Services/login.service';
import { AuthGuard } from '../guards';
import { RoleGuardService } from '../guards/role.guard';

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
  constructor(private loginService: LoginService, private roleGuard: RoleGuardService) {
  }

  logout() {
    this.loginService.logOut();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
