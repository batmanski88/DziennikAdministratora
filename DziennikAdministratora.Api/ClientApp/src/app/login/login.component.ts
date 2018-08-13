import {Component, OnInit, Inject} from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { LoginService } from './../../Services/login.service';
import { Login } from '../models/login';
import { Jwt } from '../models/token';

@Component({
    // tslint:disable-next-line:component-selector
    selector: 'login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
// tslint:disable-next-line:component-class-suffix
export class LoginUser implements OnInit {
    constructor(private loginService: LoginService, private _router: Router, private _avRoute: ActivatedRoute) {

    }

    title = 'Logowanie';
    login: Login = new Login();
    token: Jwt;
    returnUrl: string;

    ngOnInit() {
        this.loginService.logOut();
        this.returnUrl = this._avRoute.snapshot.queryParams['returnUrl'] || '/';
    }

    save(newLogin: Login) {
        this.loginService.login(newLogin)
            .subscribe(resp => {
                this._router.navigate([this.returnUrl]);
            });
    }
}
