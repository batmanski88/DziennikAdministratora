export class Note {
    constructor(public noteId?: string, public userId?: string, public subject?: string, public body?: string, public updatedAt?: Date,
        public createdAt?: Date) {}
}
