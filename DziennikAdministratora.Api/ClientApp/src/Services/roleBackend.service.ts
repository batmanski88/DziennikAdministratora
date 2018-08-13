import { Injectable } from '@angular/core';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { Role } from '../app/models/role';

@Injectable()
export abstract class RoleBackendService {

    abstract addRole(newRole: Role): Observable<number>;

    abstract getRole(Id: String): Observable<Role>;

    abstract getRoles(): Observable<Role[]>;

    abstract updateRole(updateRole: Role): Observable<number>;

    abstract deleteRole(Id: String): Observable<number>;

    abstract getUserRoles(userId: String): Observable<Role[]>;
}
