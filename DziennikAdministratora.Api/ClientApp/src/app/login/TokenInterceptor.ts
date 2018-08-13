import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { LoginService } from './../../Services/login.service';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
    constructor(public loginService: LoginService) {}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const token = sessionStorage.getItem('token');
        if (token) {
            const cloned = request.clone({
                headers: request.headers.set('Authorization', 'Bearer ' + token)
            });

            return next.handle(cloned);
        } else {
            return next.handle(request);
        }
    }
}
