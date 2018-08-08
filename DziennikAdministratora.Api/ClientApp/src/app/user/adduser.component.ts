import {Component, OnInit, Input} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RoleService } from './../../Services/role.service';
import { UserService } from './../../Services/user.service';
import { Role } from '../models/role';
import { User } from '../models/user';

@Component({
    // tslint:disable-next-line:component-selector
    selector: 'adduser',
    templateUrl: './adduser.component.html'
})

// tslint:disable-next-line:component-class-suffix
export class AddUser implements OnInit {

    // tslint:disable-next-line:max-line-length
    constructor(private roleService: RoleService, private userService: UserService , private avRoute: ActivatedRoute, private _router: Router) {
        if (this.avRoute.snapshot.params['id']) {
            this.id = this.avRoute.snapshot.params['id'];
        }

        this.roles = this.getRoles();
    }

    title = 'Nowy Użytkownik';
    id = '';
    errorMessaage: any;
    roles: Role[];
    selectedRole: String = '';
    roleToDb: Role;
    role: Role;
    user: User = new User();
    response: any;
    ngOnInit() {
        if (this.id !== '') {
            this.title = 'Edycja';
            this.userService.getUser(this.id)
                .subscribe(resp => {
                    this.user = resp;
                });

            this.getRoles();
        }
    }

    getRoles(): Role[] {
        this.roleService.getRoles().subscribe(
            rolesDb => {
                    this.roles = rolesDb;
            }
        );

        return this.roles;
    }

    onRoleSelected(val: any) {
        this.getRolesBySelectedId(val);
    }

    getRolesBySelectedId(val: any) {
        return this.roleToDb = val;
    }

    save(userObj: User) {
        userObj.role = this.roleToDb;
        if (this.title === 'Nowy Użytkownik') {
            this.userService.addUser(userObj)
                .subscribe((data) => {
                    this.response = data;
                    this._router.navigate(['admin/users']);
                }, error => this.errorMessaage = error);
        }
        // else if(this.title == "Edycja") {
        //     this.userService.updateUser(userObj)
        //         .subscribe((data) => {
        //             this._router.navigate(['admin/users']);
        //         }, error => this.errorMessaage = error)
        // }
    }

    cancel() {
        this._router.navigate(['admin/users']);
    }
}
