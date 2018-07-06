import {Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from '../../models/role';
import { RoleService } from './../../Services/role.service';
import { UserService } from './../../Services/user.service';
import { User } from '../../models/user';

@Component({
    selector: 'fetchusers',
    templateUrl: './fetchusers.component.html'
})

export class FetchUserComponent implements OnInit {
    roles: Array<Role> = new Array<Role>();
    tempinfo: string = ""
    users: User[];

    constructor(private roleService : RoleService, private router : Router, private userService: UserService){

    }

    ngOnInit(){
        this.getUsers();
    }

    getUsers() {
        this.userService.getUsers()
            .subscribe( (data) => {
                this.users = data;
            }, error => console.log(error));
            
    }

    delete(id: string){
        var ans = confirm("Czy na pewno chcesz usunąc?")
        if(ans) [
            this.userService.deleteUser(id).subscribe((data) => {
                this.getUsers();
            }, error => console.log(error))
        ]
    }
}