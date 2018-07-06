import {Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from '../../models/role';
import { RoleService } from './../../Services/role.service';

@Component({
    selector: 'fetchroles',
    templateUrl: './fetchrole.component.html'
})

export class FetchRoleComponent implements OnInit {
    roles: Array<Role> = new Array<Role>();
    tempinfo: string = ""
    constructor(private roleService : RoleService, private router : Router){

    }

    ngOnInit(){
        this.getRoles();
    }

    getRoles(): void {
        let props: Array<Role> = new Array<Role>();
        this.roleService.getRoles().subscribe(
            rolesDb => {
                if(rolesDb.length == 0){
                    this.tempinfo = "Nie znaleziono rol";
                }
                else{
                    this.roles = rolesDb;
                }
            }
        )
    }

    delete(id: string){
        var ans = confirm("Czy na pewno chcesz usunąc?")
        if(ans) [
            this.roleService.deleteRole(id).subscribe((data) => {
                this.getRoles();
            }, error => console.log(error))
        ]
    }
}