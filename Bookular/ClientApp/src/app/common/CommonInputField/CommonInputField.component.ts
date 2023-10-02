import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'CommonInputField',
  templateUrl: 'CommonInputField.component.html',
  styleUrls: ['CommonInputField.component.css'],
})
export class CommonInputFieldComponent implements OnInit {
  @Input() label: string | undefined;
  @Input() callbackFunction!: Function;
  @Input() value!: string;
  @Input() onEnter?: Function;

  test = new FormControl('');

  updateInput() {
    this.callbackFunction(this.test.value);
    console.log(this.test.value);
  }

  //   submitInput() {}

  constructor() {
    // this.value = new FormControl('');
    // this.callbackFunction = () => {};
  }

  ngOnInit() {}
}
