import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

// Angular Material
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

import { Note } from './models/note.model';
import { NotesService } from './services/notes.service';
import { HeaderComponent } from './header/header.component';
import { NoteComponent } from './note/note.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    HeaderComponent,
    NoteComponent
  ],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  notes: Note[] = [];
  title: string = '';
  text: string = '';
  errMessage: string = '';

  constructor(private notesService: NotesService) {}

  ngOnInit(): void {
    this.loadNotes();
  }

  loadNotes() {
    this.notesService.getNotes().subscribe({
      next: data => this.notes = data,
      error: () => this.errMessage = 'Error loading notes'
    });
  }

  addNote() {
    if (!this.title.trim() || !this.text.trim()) {
      this.errMessage = 'Title and text are required';
      return;
    }

    const newNote = new Note(this.title, this.text);
    this.notes.unshift(newNote); // optimistic

    this.notesService.addNote(newNote).subscribe({
      next: savedNote => {
        this.notes[0].id = savedNote.id;
        this.errMessage = '';
      },
      error: () => {
        this.errMessage = 'Error saving note';
        this.notes.shift(); // rollback
      }
    });

    this.title = '';
    this.text = '';
  }
}
