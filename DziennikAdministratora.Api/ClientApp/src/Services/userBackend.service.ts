import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User} from '../app/models/user';

@Injectable()
export abstract class UserBackendService{
    abstract addUser(newRole: User): Observable<number>;

    abstract getUser(id: string): Observable<User>;

    abstract getUsers(): Observable<User[]>;

    abstract deleteUser(id: string): Observable<number>;
}