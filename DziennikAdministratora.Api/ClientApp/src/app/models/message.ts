export class Message{
    content: string;
    style: string;
    dissmissed: boolean = false;

    constructor(content, style?){
        this.content = content
        this.style = style || 'info'
    }
}