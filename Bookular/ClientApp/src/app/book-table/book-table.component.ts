import { Component, Input } from '@angular/core';
import { IBook } from '../home/IBook';
import { Observable } from 'rxjs/internal/Observable';
import { BookularService } from '../../services/bookular.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'book-table',
  templateUrl: './book-table.component.html',
  styleUrls: ['./book-table.component.css'],
})
export class BookTableComponent {
  @Input()
  data: Observable<IBook[]>;
  bookservice = new BookularService(this.http);

  constructor(private http: HttpClient) {
    this.data = new Observable<IBook[]>();
  }

  addBook(newBook: IBook) {
    this.bookservice.addBook(newBook).subscribe(addedBook => {
      this.data.subscribe(books => {
        books.push(addedBook);
      });
    })
  }
}
