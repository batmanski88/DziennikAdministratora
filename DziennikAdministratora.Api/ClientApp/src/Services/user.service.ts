import { Injectable, Inject } from '@angular/core';
import { Http, Response} from '@angular/http';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { User } from '../app/models/user';
import { UserBackendService } from '../Services/userBackend.service';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
// tslint:disable-next-line:import-blacklist
import 'rxjs/Rx';
import { HttpHeaders, HttpClient } from '../../node_modules/@angular/common/http';
import { Role } from '../app/models/role';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };
@Injectable()

export class UserService extends UserBackendService {
    user: User;
    users: Observable<User>;
    baseUrl = '';

    constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrul: string) {
        super();
        this.baseUrl = this.baseUrl;
    }

    public addUser(newUser: User) {
        return this._http.post<number>(this.baseUrl + 'api/admin/User/AddUserAsync', newUser, httpOptions)
            .map( response => response)
            .catch(this.errorHandler);
    }

    public getUser(Id: string) {
        return this._http.get<User>(this.baseUrl + 'api/admin/User/GetUserById/' + Id)
            .map(resp => resp)
            .catch(error => this.errorHandler(error));
    }

    public getUsers() {
        return this._http.get<User[]>(this.baseUrl + 'api/admin/User/GetUsers')
            .map(resp => resp)
            .catch(error => this.errorHandler(error));
    }

    public deleteUser(Id: string) {
        return this._http.delete<number>(this.baseUrl + 'api/admin/User/DeleteUserAsync/' + Id)
            .map(resp => resp)
            .catch(error => this.errorHandler(error));
    }

    public getUserRoles(userId: string) {
        return this._http.get<Role[]>(this.baseUrl + 'api/admin/User/GetUserRoles' + userId)
            .map(resp => resp)
            .catch(error => this.errorHandler(error));
    }
    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}
