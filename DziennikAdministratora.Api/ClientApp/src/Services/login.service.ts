import { Injectable, Inject} from '@angular/core';
import { Response, Jsonp} from '@angular/http';
// tslint:disable-next-line:import-blacklist
import { Observable} from 'rxjs/Rx';
import { Login } from '../app/models/login';
import { LoginBackendService } from '../Services/loginBackend.service';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Jwt } from '../app/models/token';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

@Injectable()
export class LoginService extends LoginBackendService {
    slogin: Login = new Login();
    baseUrl = '';

    constructor(private _http: HttpClient, @Inject('BASE_URL') _baseUrul: string) {
        super();
    }

    login(newLogin: Login) {
        return this._http.post<Jwt>(this.baseUrl + 'api/Login/LoginAsync', newLogin, httpOptions)
            .map(jwt => {
                if (jwt && jwt.token) {
                    sessionStorage.setItem('token', jwt.token);
                    sessionStorage.setItem('expiryMinutes', JSON.stringify(jwt.expiryMinutes));
                    sessionStorage.setItem('roles', JSON.stringify(jwt.userRoles));
                }

                return jwt;
            })
            .catch(this.errorHandler);

    }

    logOut() {
        sessionStorage.removeItem('token');
        sessionStorage.removeItem('expiryMinutes');
        sessionStorage.removeItem('roles');
    }

    isAuthenticated(): boolean {
        if (sessionStorage.getItem('token') != null) {
            return true;
        } else {
            return false;
        }
    }

    getToken(): string {
        return sessionStorage.getItem('token');
    }

    errorHandler(error: Response) {
        console.log(error);
        return Observable.throw(error);
    }
}
