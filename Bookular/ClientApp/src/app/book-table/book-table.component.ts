import { Component, Input } from '@angular/core';
import { IBook } from '../home/IBook';

@Component({
  selector: 'book-table',
  templateUrl: './book-table.component.html',
  styleUrls: ['./book-table.component.css']
})
export class BookTableComponent {
  @Input()
  data: IBook[] | undefined = undefined;
}
