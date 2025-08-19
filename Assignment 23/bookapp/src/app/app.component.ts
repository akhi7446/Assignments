import { Component, OnInit } from '@angular/core';
import { NgForm, FormsModule } from '@angular/forms';
import { NgFor, NgIf } from '@angular/common';
import { Book } from './models/book.model';
import { BookService } from './services/book.service';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, NgFor, NgIf, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  books: Book[] = [];
  newBookObj: Book = {
    name: '',
    author: '',
    year: new Date().getFullYear(),
    language: ''
  };

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    this.getBooksFromServer();
  }

  getBooksFromServer(): void {
    this.bookService.getBooks().subscribe((data: Book[]) => {
      this.books = data;
    });
  }

  newBook(form: NgForm): void {
    if (form.valid) {
      this.bookService.addBook(this.newBookObj).subscribe(() => {
        this.getBooksFromServer();
        form.resetForm();
        this.newBookObj = { name: '', author: '', year: new Date().getFullYear(), language: '' };
      });
    }
  }
}
