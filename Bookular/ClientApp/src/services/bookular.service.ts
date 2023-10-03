import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBook } from '../app/home/IBook';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookularService {
  private bookSubject = new BehaviorSubject<IBook[]>([]);
  books$ = this.bookSubject.asObservable();

  constructor(private http: HttpClient) {}

  getBooks(param: string) {
    this.http
      .get<IBook[]>('https://localhost:7195/api/book/find/' + param)
      .subscribe((books) => {
        this.bookSubject.next(books);
      });
  }
}
