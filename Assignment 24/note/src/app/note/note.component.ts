import { Component, Input } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { Note } from '../models/note.model';

@Component({
  selector: 'app-note',
  standalone: true,
  imports: [MatCardModule],
  template: `
    <mat-card class="note-card">
      <mat-card-title>{{ note.title }}</mat-card-title>
      <mat-card-content>{{ note.text }}</mat-card-content>
    </mat-card>
  `,
  styles: [`
    .note-card {
      margin: 10px;
      padding: 10px;
      width: 200px;
    }
  `]
})
export class NoteComponent {
  @Input() note!: Note;
}
