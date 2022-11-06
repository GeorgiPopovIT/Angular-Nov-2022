import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'articles-app';
  currentItem = 'TEST TEST';
  items = ['item1', 'item2', 'item3', 'item4'];


  addItem(outputValue: string) {
    this.items.push(outputValue);

    console.log(this.items.values)
  }
}
