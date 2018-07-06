import {Component, OnInit, Inject} from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { LoginService } from './../../Services/login.service';
import { Login } from '../../models/login'; 
import { Jwt } from '../models/token';
import { BehaviorSubject } from 'rxjs';
import { AlertService } from '../../Services/alert.service';

@Component({
    selector: 'login', 
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginUser implements OnInit {
    constructor(private loginService : LoginService, private _router: Router, private _avRoute : ActivatedRoute, private alertService: AlertService){
        this.loggedIn = !sessionStorage.getItem('CurrentUser')
        this._authNavStatusSource.next(this.loggedIn)
    }

    title: string = "Logowanie";
    login: Login = new Login();
    private loggedIn = false;
    private _authNavStatusSource = new BehaviorSubject<boolean>(false);
    authNavStatus$ = this._authNavStatusSource.asObservable();
    token : Jwt;
    returnUrl: string

    ngOnInit(){
        this.loginService.logOut();
        
        this.returnUrl = this._avRoute.snapshot.queryParams['returnUrl'] || '/';
    }

    save(newLogin: Login){
        this.loginService.login(newLogin)
            .subscribe(resp => {
                this.loggedIn = true;
                this._authNavStatusSource.next(true);
                this._router.navigate([this.returnUrl]);
            },
            error => {
                this.alertService.error(error);
            });
    }
    
}