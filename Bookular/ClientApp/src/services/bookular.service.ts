import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBook } from '../app/home/IBook';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BookularService {
  private bookSubject = new BehaviorSubject<IBook[]>([]);
  books$ = this.bookSubject.asObservable();

  constructor(private http: HttpClient) { }

  getBooks(param: string): Observable<IBook[]> {
    return this.http
      .get<IBook[]>('https://localhost:7195/api/book/find/' + param);
  }

  addBook(book: IBook): Observable<IBook> {
    return this.http.post<IBook>("https://localhost:7195/api/book/add", book)
  }

  /*  getBooks(param: string): Observable<IBook[]> {
      return this.http.get<IBook[]>("https://localhost:7195/test.json");
    }*/

  loadBooks(param: string) {
    this.getBooks(param).subscribe(res => {
      this.bookSubject.next(res)
    })
  }
}
