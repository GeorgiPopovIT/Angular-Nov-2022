import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Song } from 'src/app/shared/interfaces/song';
import { NgOptimizedImage } from '@angular/common'

@Component({
  selector: 'app-list-item',
  templateUrl: './list-item.component.html',
  styleUrls: ['./list-item.component.css']
})
export class ListItemComponent  {
  @Input()
  public song! : Song;

  @Output()
  public songId = new EventEmitter<Song>();
  
  constructor() { }

  songClicked(currentSong : Song){
    this.songId.emit(currentSong);

    console.log('Song audio: ' + currentSong !=  null);
  }
}
