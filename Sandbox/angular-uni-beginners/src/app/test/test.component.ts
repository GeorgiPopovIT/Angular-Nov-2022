import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.css']
})
export class TestComponent implements OnInit {

    @Input()
    word! : string;

    @Output()
    buttonClicked = new EventEmitter<any>();
    
  constructor() { }

  ngOnInit(): void {
  }

  someChangeTest(){
    console.log('test component');

    this.buttonClicked.emit(this.word);

    console.log(this.word);
  }

}
