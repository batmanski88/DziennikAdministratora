import {Component, OnInit} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RoleService } from './../../Services/role.service';
import { Role } from '../../models/role'; 

@Component({
    selector: 'addrole', 
    templateUrl: './addrole.component.html'
})

export class AddRole implements OnInit {
    
    constructor(private roleService : RoleService, private avRoute: ActivatedRoute, private _router: Router){
        if(this.avRoute.snapshot.params["id"]) {
            this.id = this.avRoute.snapshot.params["id"];
        }
    }

    title: string = "Nowa Rola";
    role: Role = new Role();
    id: string = "";
    errorMessaage: any;

    ngOnInit(){
        if(this.id != ""){
            this.title = "Edycja";
            this.roleService.getRole(this.id)
                .subscribe(resp => { this.role = resp}, error => this.errorMessaage = error)
        }
    }

    save(roleObj: Role): void {
        if(this.title == "Nowa Rola") {
            this.roleService.addRole(roleObj)
                .subscribe((data) => {
                    this._router.navigate(['admin/roles']);
                }, error => this.errorMessaage = error)
        }
        else if(this.title == "Edycja") {
            this.roleService.updateRole(roleObj)
                .subscribe((data) => {
                    this._router.navigate(['admin/roles']);
                }, error => this.errorMessaage = error)
        }
    }

    cancel(){
        this._router.navigate(['admin/roles']);
    }
}