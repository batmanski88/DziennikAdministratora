import { Injectable } from '@angular/core';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { Login } from '../app/models/login';
import { Jwt } from '../app/models/token';

@Injectable()
export abstract class LoginBackendService {
    abstract login(login: Login): Observable<Jwt>;
    abstract logOut();
}
