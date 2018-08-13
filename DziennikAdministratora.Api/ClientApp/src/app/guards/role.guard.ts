import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { LoginService } from './../../Services/login.service';
import decode from 'jwt-decode';
import { RoleService } from '../../Services/role.service';

@Injectable()
export class RoleGuardService implements CanActivate {
    constructor(public loginService: LoginService, public router: Router, public roleService: RoleService) {}

    canActivate(route: ActivatedRouteSnapshot, ): boolean {

        const expectedRole = route.data.expectedRole;

        const token = localStorage.getItem('token');

        const tokenPayload = decode(token);

        const userId = tokenPayload.sub;

        const userRoles = this.roleService.getUserRoles(userId);

        if (userRoles !== expectedRole) {
            return false;
        } else {
          return true;
        }
    }
}
