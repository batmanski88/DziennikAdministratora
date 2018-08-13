import { Injectable } from '@angular/core';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { User} from '../app/models/user';
import { Role } from '../app/models/role';

@Injectable()
export abstract class UserBackendService {
    abstract addUser(newRole: User): Observable<number>;

    abstract getUser(id: string): Observable<User>;

    abstract getUsers(): Observable<User[]>;

    abstract deleteUser(id: string): Observable<number>;

    abstract getUserRoles(userId: string): Observable<Role[]>;
}
