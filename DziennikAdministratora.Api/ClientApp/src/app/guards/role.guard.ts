import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { LoginService } from './../../Services/login.service';
import * as decode from 'jwt-decode';
import { RoleService } from '../../Services/role.service';
import { Role } from '../models/role';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';

@Injectable()
export class RoleGuardService implements CanActivate {
    constructor(public loginService: LoginService, public router: Router, public roleService: RoleService) {}
    userRoles: Role[];

    canActivate(route: ActivatedRouteSnapshot) {

        const expectedRole = route.data.expectedRole;

        this.userRoles = JSON.parse(sessionStorage.getItem('roles'));

        // tslint:disable-next-line:prefer-const
        for (let i in this.userRoles) {
            if (this.userRoles[i].name === expectedRole ) {
                return true;
            } else {
                return false;
            }
        }
    }
}
