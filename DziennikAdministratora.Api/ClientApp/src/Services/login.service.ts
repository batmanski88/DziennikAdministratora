import { Injectable, Inject} from '@angular/core';
import { Response} from '@angular/http';
import { Observable} from 'rxjs/Rx';
import { Login } from '../app/models/login';
import { LoginBackendService } from '../Services/loginBackend.service';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { HttpHeaders, HttpClient } from '@angular/common/http';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

@Injectable()
export class LoginService extends LoginBackendService {
    slogin : Login = new Login();
    baseUrl : string = "";

    constructor(private _http : HttpClient, @Inject('BASE_URL') _baseUrul : string){
        super()
        
    }

    login(newLogin: Login){
        return this._http.post<any>(this.baseUrl + 'api/Login/LoginAsync', newLogin, httpOptions)  
            .map(user => {
                if(user && user.token) {
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }

                return user;
            }) 
            .catch(this.errorHandler)

    }

    logOut() {
        sessionStorage.removeItem('currentUser');
    }
    
    errorHandler(error: Response){
        console.log(error)
        return Observable.throw(error)
    }
}