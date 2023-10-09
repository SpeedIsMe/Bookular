import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { IBook } from '../home/IBook';

@Component({
  selector: 'app-create-book',
  templateUrl: './create-book.component.html',
  styleUrls: ['./create-book.component.css']
})
export class CreateBookComponent {
  @Output() onSubmit = new EventEmitter<IBook>();

  title = new FormControl('', [Validators.required]);
  description = new FormControl('', [Validators.required]);
  authorFirstName = new FormControl('', [Validators.required]);
  authorLastName = new FormControl('', [Validators.required]);
  authorBio = new FormControl('', [Validators.required]);

  checkoutForm = this.formBuilder.group({
    title: this.title,
    description: this.description,
    authorFirstName: this.authorFirstName,
    authorLastName: this.authorLastName,
    authorBio: this.authorBio
  });

  constructor(
    private formBuilder: FormBuilder
  ) {
  }

  addBook(): void {

    var formObject = this.checkoutForm.value;

    const newBook: IBook = {
      id: 0,
      title: formObject.title as string,
      description: formObject.description as string,
      author: {
        id: 0,
        firstName: formObject.authorFirstName as string,
        lastName: formObject.authorLastName as string,
        bio: formObject.authorBio as string,
        books: null
      },
      authorId: 0
    };

    this.onSubmit.emit(newBook as unknown as IBook);
  }
}
