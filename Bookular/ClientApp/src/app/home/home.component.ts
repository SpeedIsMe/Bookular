import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BookularService } from 'src/services/bookular.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'Bookular';
  subtitle = 'Your guide to book';
  bookservice = new BookularService(this.http);
  userInput: string | undefined = undefined;
  bookData = this.bookservice.books$;

  constructor(private http: HttpClient) { }

  updateInput = (input: string) => {
    this.userInput = input;
    console.log(this.userInput);
  };

  searchBooks = () => {
    this.bookservice.loadBooks(this.userInput!);
  };
}
