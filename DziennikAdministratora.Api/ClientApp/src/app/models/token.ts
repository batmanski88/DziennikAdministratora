export class Jwt {
    constructor(public token?: string, public expiryMinutes?: LongRange) {}
}
