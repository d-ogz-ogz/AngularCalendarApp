import { Component } from '@angular/core';
import { NoteModel } from '../../models/NoteModel';
import { NoteService } from '../services/note.service';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent {
  months: Array<string> = [
    'Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran',
    'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'
  ];
  currentYear: number;
  currentMonth: number;
  daysInMonth: number[] = [];
  selectedDay: number = 1;
  isPopupVisible: boolean = false;
  noteModel = new NoteModel;

  today: { day: number, month: number, year: number };

  constructor(public noteService: NoteService) {
    const now = new Date();
    this.currentYear = now.getFullYear();
    this.currentMonth = now.getMonth();
    this.today = {
      day: now.getDate(),
      month: now.getMonth(),
      year: now.getFullYear()
    };
    this.generateDaysInMonth(this.currentMonth, this.currentYear);
    this.getNotesForDay(this.today.day);
    this.noteService.getNotes()
  }

  generateDaysInMonth(month: number, year: number) {
    const daysInMonth = new Date(year, month + 1, 0).getDate();
    this.daysInMonth = Array.from({ length: daysInMonth }, (_, i) => i + 1);
  }

  openPopup(day: number) {
    this.selectedDay = day;
    this.isPopupVisible = true;
  }

  closePopup() {
    this.isPopupVisible = false;
  }

  saveNote() {
    this.noteModel.day = this.selectedDay;
    this.noteModel.month = this.currentMonth;
    this.noteModel.year = this.currentYear;

    if (this.noteModel.title && this.noteModel.content !== null) {
      this.noteService.addNote(this.noteModel).then(res=> console.log(res))
    }
    this.clearInputs();
    this.closePopup();
  }

  getNotesForDay(day: number) {
    this.noteService.todayNotes = this.noteService.Notes.filter(
      note => note.day === day && note.month === this.currentMonth && note.year === this.currentYear
    );
  }

  clearInputs() {
    this.noteModel.content = "";
    this.noteModel.title = ""
  }

  isToday(day: number): boolean {
    return (
      this.today.day === day &&
      this.today.month === this.currentMonth &&
      this.today.year === this.currentYear
    );
  }

  previousMonth() {
    if (this.currentMonth === 0) {
      this.currentMonth = 11;
      this.currentYear--;
    } else {
      this.currentMonth--;
    }
    this.generateDaysInMonth(this.currentMonth, this.currentYear);
  }

  nextMonth() {
    if (this.currentMonth === 11) {
      this.currentMonth = 0;
      this.currentYear++;
    } else {
      this.currentMonth++;
    }
    this.generateDaysInMonth(this.currentMonth, this.currentYear);
  }
}
