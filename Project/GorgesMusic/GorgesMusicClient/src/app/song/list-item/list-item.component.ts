import { Component, Input } from '@angular/core';
import { Song } from 'src/app/shared/interfaces/song';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent  {

  @Input()
  public song! : Song;
  
  constructor() { }
}
