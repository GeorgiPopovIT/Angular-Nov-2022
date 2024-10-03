import { Component, EventEmitter, Input, Output, effect, signal } from '@angular/core';
import { Song } from 'src/app/shared/interfaces/song';

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent  {
  @Input() song! : Song;

  @Output() songToEmit = new EventEmitter<Song>();
  
  constructor() {}

  songClicked(currentSong : Song){
    this.songToEmit.emit(currentSong);
  }
}
