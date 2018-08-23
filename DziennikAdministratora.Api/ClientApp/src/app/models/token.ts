import { Role } from './role';

export class Jwt {
    constructor(public token?: string, public expiryMinutes?: LongRange, public userRoles?: Role[]) {}
}
