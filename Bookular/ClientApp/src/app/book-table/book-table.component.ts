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
    this.data.subscribe(books => {
      books.push(newBook);
    });

    // TODO: WHEN BACKEND IS READY, UNCOMMENT
    /*  const addedBook = this.bookservice.addBook(newBook).subscribe(addedBook => {
        console.log(addedBook.title)
  
        this.data.subscribe(books => {
          books.push(addedBook);
        });
      })*/
  }
}
