import { Injectable, Inject } from '@angular/core';
import { Http, Response} from '@angular/http';
import { Observable } from 'rxjs';
import { User } from '../app/models/user';
import { UserBackendService } from '../Services/userBackend.service';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/Rx';

@Injectable()

export class UserService extends UserBackendService{
    user : User;
    baseUrl : string = "";

    constructor(private _http : Http, @Inject('BASE_URL') _baseUrul : string){
        super()
        this.baseUrl = this.baseUrl;
    }

    public addUser(newUser: User){
        return this._http.post(this.baseUrl + "api/admin/User/AddUserAsync", JSON.stringify(newUser))
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    public getUser(Id: string){
        return this._http.get(this.baseUrl + "api/admin/User/GetUserById/" + Id)
            .map(resp => resp.json())
            .catch(error => this.errorHandler(error))
    }

    public getUsers(){
        return this._http.get(this.baseUrl + "api/admin/User/GetUsers")
            .map(resp => resp.json())
            .catch(this.errorHandler)
    }

    public deleteUser(Id: string){
        return this._http.delete(this.baseUrl + "api/admin/User/DeleteUserAsync/" + Id)
            .map((response: Response) => response.json())
            .catch(this.errorHandler)
    }

    errorHandler(error: Response){
        console.log(error)
        return Observable.throw(error)
    }
}