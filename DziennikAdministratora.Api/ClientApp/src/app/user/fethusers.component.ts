import {Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from '../models/role';
import { RoleService } from './../../Services/role.service';
import { UserService } from './../../Services/user.service';
import { User } from '../models/user';

@Component({
    // tslint:disable-next-line:component-selector
    selector: 'fetchusers',
    templateUrl: './fetchusers.component.html',
    styleUrls: ['./fetchusers.component.css']
})

export class FetchUserComponent implements OnInit {
    roles: Array<Role> = new Array<Role>();
    tempinfo = '';
    users: User[];

    constructor(private roleService: RoleService, private router: Router, private userService: UserService) {

    }

    ngOnInit() {
        this.getUsers();
    }

    getUsers() {
        this.userService.getUsers()
            .subscribe( (data) => {
                this.users = data;
            }, error => console.log(error));

    }

    delete(id: string) {
        // tslint:disable-next-line:prefer-const
        let ans = confirm('Czy na pewno chcesz usunąc?');
        // tslint:disable-next-line:no-unused-expression
        if (ans) { [
            this.userService.deleteUser(id).subscribe((data) => {
                this.getUsers();
            }, error => console.log(error))
        ];
        }
    }

    resetPassword(id: string) {
        const ans = confirm('Czy na pewno chcesz zresetowac haslo?');

        // tslint:disable-next-line:no-unused-expression
        if (ans) { [

        ]; }
    }
}
