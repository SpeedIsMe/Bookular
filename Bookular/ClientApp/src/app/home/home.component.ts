import { Component } from '@angular/core';
import { IBook } from './IBook';
import { IAuthor } from './IAuthor';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  title = 'Bookular';
  subtitle = 'Your guide to book';
  bookData: IBook[] | undefined = undefined;
  userInput: string | undefined = undefined;

  updateInput = (input: string) => {
    this.userInput = input;
    console.log(this.userInput);
  };

  searchBooks = () => {
    this.bookData = this.books.filter((book) =>
      book.title.toLowerCase().includes(this.userInput!.toLowerCase())
    );
    console.log(this.bookData);
  };

  books: IBook[] = [
    {
      id: 1,
      title: 'War and Peace',
      author: 'Leo Tolstoy',
      description:
        'The epic tale of love and loss set during the war between Russia and France.',
    },
    {
      id: 2,
      title: 'The Catcher in the Rye',
      author: 'J.D. Salinger',
      description:
        "Holden Caulfield's journey through New York City and the loss of his innocence.",
    },
    {
      id: 3,
      title: 'The Great Gatsby',
      author: 'F. Scott Fitzgerald',
      description:
        'The story of the mysteriously wealthy Jay Gatsby and his love for the beautiful Daisy Buchanan.',
    },
  ];
}
