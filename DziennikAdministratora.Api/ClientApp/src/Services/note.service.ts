import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { Note } from '../app/models/note';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
@Injectable()

export class NoteService {
    note: Observable<Note>;
    // tslint:disable-next-line:no-inferrable-types
    baseUrl: string = '';

    constructor(private _httpClient: HttpClient, @Inject('BASE_URL') _baseUrl: string) {
      this.baseUrl = _baseUrl;
    }

    getNotes() {
      return this._httpClient.get<Note[]>(this.baseUrl + 'api/Note/GetNotes')
        .map(response => {
          return response;
        })
        .catch(error => this.errorHandler(error));
    }

    addNote(newNote: Note) {
      return this._httpClient.post<Note>(this.baseUrl + 'api/Note/AddNote', newNote, httpOptions)
        .map(response => {
          return response;
        })
        .catch(error => this.errorHandler(error));
    }

    deleteNote(id: string) {
      return this._httpClient.delete(this.baseUrl + 'api/Note/DeleteNote' + id)
        .map(response => {
          return response;
        })
        .catch(error => this.errorHandler(error));
    }

    errorHandler(error: Response) {
      console.log(error);
      return Observable.throw(error);
  }
}
