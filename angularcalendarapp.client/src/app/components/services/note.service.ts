
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core'
import { Router } from '@angular/router';
import { NoteModel } from '../../models/NoteModel';



@Injectable({
  providedIn: 'root'
})

export class NoteService {
  apiUrl: string = "http://localhost:5143";
  Notes: NoteModel[] = [];
  todayNotes!: NoteModel[];

  constructor(private http: HttpClient, private router: Router) { }
  getNotes(day?: number, month?: number) {
    return this.http.get(this.apiUrl + `/Topic/GetNotes?day=${day}&month=${month}}`).subscribe(res => {
      this.Notes = res as NoteModel[]; console.log(res)
    });

  }
  addNote(noteModel: NoteModel) {
    return this.http.post(this.apiUrl + `/Topic/AddNote`, noteModel).toPromise();
  };

  }


