import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoginService } from '../../Services/login.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;
  loggedIn = true;
  subscription: Subscription = new Subscription();

  constructor(private loginService: LoginService){
    if(localStorage.getItem('currentUser'))
    {
      this.loggedIn = false;
    }
    else if(!localStorage.getItem('currentUser'))
    {
      this.loggedIn = true;
    }
  }

  ngOnInit(){
    if(localStorage.getItem('currentUser'))
    {
      this.loggedIn = false;
    }
    else if(localStorage.getItem('currentUser'))
    {
      this.loggedIn = true;
    }
  }

  logout(){
    this.loginService.logOut();
    localStorage.removeItem('currentUser');
    this.loggedIn = false;
}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
