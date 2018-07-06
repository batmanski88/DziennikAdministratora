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
    role : Observable<Role>;
    roles : Observable<Role[]>;
    baseUrl : string = "";

    constructor(private _http : HttpClient , @Inject('BASE_URL') _baseUrul : string){
        super()
        this.baseUrl = this.baseUrl;
    }

    addRole(newRole: Role){
        return this._http.post<number>(this.baseUrl + 'api/admin/Role/AddRole', JSON.stringify(newRole))
        .map(response => {
            return response;
        })
        .catch(this.errorHandler)
    }

    getRole(Id : string){
        return this._http.get<Role>(this.baseUrl + 'api/admin/Role/GetRoleById/' + Id)
            .map(response => {
                return response;
            })
            .catch(this.errorHandler)
    }

    getRoles(){
        return this._http.get<Role[]>(this.baseUrl + 'api/admin/Role/GetRoles')
            .map(response => {
                return response;
            })
            .catch(this.errorHandler)
    }

    deleteRole(Id : string){
        return this._http.delete<number>(this.baseUrl + 'api/admin/Role/DeleteRole/' + Id)
            .map( response => {
                return response;
            })
            .catch(this.errorHandler)
    }

    updateRole(updateRole: Role){
        return this._http.put<number>(this.baseUrl + 'api/admin/Role/UpdateRole', JSON.stringify(updateRole))
            .map(response => {
                return response;
            })
            .catch(this.errorHandler)
    }
    
    errorHandler(error: Response){
        console.log(error)
        return Observable.throw(error)
    }
}