import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs/';
import { Role } from '../app/models/role';
import { RoleBackendService } from '../Services/roleBackend.service';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };
@Injectable()

export class RoleService extends RoleBackendService {
    role: Observable<Role>;
    roles: Observable<Role[]>;
    // tslint:disable-next-line:no-inferrable-types
    baseUrl: string = '';

    constructor(private _http: HttpClient , @Inject('BASE_URL') _baseUrl: string) {
        super();
        this.baseUrl = _baseUrl;
    }

    addRole(newRole: Role) {
        return this._http.post<number>(this.baseUrl + 'api/admin/Role/AddRole', newRole, httpOptions)
        .map(response => {
            return response;
        })
        .catch(error => this.errorHandler(error));
    }

    getRole(Id: string) {
        return this._http.get<Role>(this.baseUrl + 'api/admin/Role/GetRoleById/' + Id)
            .map(response => {
                return response;
            })
            .catch(error => this.errorHandler(error));
    }

    getRoles() {
        return this._http.get<Role[]>(this.baseUrl + 'api/admin/Role/GetRoles')
            .map(response => {
                return response;
            })
            .catch(error => this.errorHandler(error));
    }

    deleteRole(Id: string) {
        return this._http.delete<number>(this.baseUrl + 'api/admin/Role/DeleteRole/' + Id)
            .map( response => {
                return response;
            })
            .catch(error => this.errorHandler(error));
    }

    updateRole(updateRole: Role) {
        return this._http.put<number>(this.baseUrl + 'api/admin/Role/UpdateRole', updateRole, httpOptions)
            .map(response => {
                return response;
            })
            .catch(error => this.errorHandler(error));
    }

    getUserRoles(userId: string) {
        return this._http.get<Role[]>(this.baseUrl + 'api/admin/Role/GetUserRolesAsync/' + userId)
            .map(response => {
                return response;
            })
            .catch(error => this.errorHandler(error));
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}
