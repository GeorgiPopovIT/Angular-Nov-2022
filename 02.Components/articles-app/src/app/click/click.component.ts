import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-click',
  templateUrl: './click.component.html',
  styleUrls: ['./click.component.css']
})
export class ClickComponent  {
  counter : number;
  show : boolean = false;
  //inputValue = "Visible";
  isVisible = true;

  @Input() inputValue = 'Default value';
  @Output() outputValue = new EventEmitter<string>(); 

  constructor() {
    this.counter = 0;
   }

visible(inputEl : HTMLInputElement) : void{
  this.isVisible = !this.isVisible;

  console.log(inputEl.value);

  console.log()
}

addNewItem(value: string) {
  this.outputValue.emit(value);
}

  increment(){
    this.counter++;
  }
}
