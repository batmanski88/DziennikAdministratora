import { Role } from './role';

export class User {
    // tslint:disable-next-line:max-line-length
    constructor(public userid?: string, public email?: string, public password?: string, public rePassword?: string, public userName?: string, public role?: Role, public createdAt?: Date, public updatedAt?: Date) {}
}
