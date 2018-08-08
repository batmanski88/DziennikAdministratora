import {Component, OnInit, Inject} from '@angular/core';
import { Router, ActivatedRoute} from '@angular/router';
import { LoginService } from './../../Services/login.service';
import { Login } from '../models/login'; 
import { Jwt } from '../models/token';

@Component({
    selector: 'login', 
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginUser implements OnInit {
    constructor(private loginService : LoginService, private _router: Router, private _avRoute : ActivatedRoute){

    }

    title: string = "Logowanie";
    login: Login = new Login();
    token : Jwt;
    returnUrl: string

    ngOnInit(){
        this.loginService.logOut();
        
        this.returnUrl = this._avRoute.snapshot.queryParams['returnUrl'] || '/';
    }

    save(newLogin: Login){
        this.loginService.login(newLogin)
            .subscribe(resp => {
                
                this._router.navigate([this.returnUrl]);
            })
    }
    
}