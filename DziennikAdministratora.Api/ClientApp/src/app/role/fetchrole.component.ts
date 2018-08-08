import {Component, OnInit } from '@angular/core';
import { Role } from '../models/role';
import { RoleService } from './../../Services/role.service';

@Component({
    // tslint:disable-next-line:component-selector
    selector: 'fetchroles',
    templateUrl: './fetchrole.component.html',
    styleUrls: ['./fetchrole.component.css']
})

export class FetchRoleComponent implements OnInit {
    roles: Array<Role> = new Array<Role>();
    tempinfo = '';
    constructor(private roleService: RoleService) {

    }

    ngOnInit() {
        this.getRoles();
    }

    getRoles(): void {
        this.roleService.getRoles().subscribe(
            rolesDb => {
                if (rolesDb.length === 0) {
                    this.tempinfo = 'Nie znaleziono rol';
                } else {
                    this.roles = rolesDb;
                }
            }
        );
    }

    delete(id: string) {
        // tslint:disable-next-line:prefer-const
        let ans = confirm('Czy na pewno chcesz usunąc?');
        // tslint:disable-next-line:no-unused-expression
        if (ans) { [
            this.roleService.deleteRole(id).subscribe((data) => {
                this.getRoles();
            }, error => console.log(error))
        ];
        }
    }
}
