import {Component, OnInit, Input} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RoleService } from './../../Services/role.service';
import { UserService } from './../../Services/user.service';
import { Role } from '../../models/role'; 
import { User } from '../../models/user';
import { Observable } from 'rxjs';

@Component({
    selector: 'adduser', 
    templateUrl: './adduser.component.html'
})

export class AddUser implements OnInit {
    
    constructor(private roleService : RoleService, private userService: UserService ,private avRoute: ActivatedRoute, private _router: Router){
        if(this.avRoute.snapshot.params["id"]) {
            this.id = this.avRoute.snapshot.params["id"];
        }

        this.roles = this.getRoles(); 
    }

    title: string = "Nowy Użytkownik";
    id: string = "";
    errorMessaage: any;
    roles : Array<Role> = new Array<Role>();
    selectedRole : String = ""
    roleToDb: Role[];
    role : Role;
    userToDb: Observable<User>;

    ngOnInit(){
        if(this.id != ""){
            this.title = "Edycja";
            this.userService.getUser(this.id)
                .subscribe(resp => {
                    this.userToDb = resp
                });

            this.getRoles() 
        }
    }

    getRoles(): Role[] {
        this.roleService.getRoles().subscribe(
            rolesDb => {
                    this.roles = rolesDb;
            }
        )

        return this.roles;
    }

    onRoleSelected(val : any) 
    {   
        this.getRolesBySelectedId(val)
    }

    getRolesBySelectedId(val : any) 
    {
        return this.roleToDb = val
    }

    save(userObj: User) {
        userObj.role = this.role
        if(this.title == "Nowy Użytkownik") {
            this.userService.addUser(userObj)
                .subscribe((data) => {
                    this._router.navigate(['admin/users']);
                }, error => this.errorMessaage = error)
        }
        // else if(this.title == "Edycja") {
        //     this.userService.updateUser(userObj)
        //         .subscribe((data) => {
        //             this._router.navigate(['admin/users']);
        //         }, error => this.errorMessaage = error)
        // }
    }

    cancel(){
        this._router.navigate(['admin/users']);
    }
}