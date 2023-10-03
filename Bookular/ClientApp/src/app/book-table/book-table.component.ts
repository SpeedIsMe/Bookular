import { Component, Input } from '@angular/core';
import { IBook } from '../home/IBook';
import { Observable } from 'rxjs/internal/Observable';

@Component({
  selector: 'book-table',
  templateUrl: './book-table.component.html',
  styleUrls: ['./book-table.component.css'],
})
export class BookTableComponent {
  @Input()
  data: Observable<IBook[]>;

  constructor() {
    this.data = new Observable<IBook[]>();
  }
}
