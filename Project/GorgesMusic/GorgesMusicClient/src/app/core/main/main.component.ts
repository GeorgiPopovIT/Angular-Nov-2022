import { Component, Input, OnInit, Output } from '@angular/core';
import { Song } from 'src/app/shared/interfaces/song';


@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  @Output() songToPlay! : Song;
  constructor() { }
  

  songPlaying(songToPlay : Song){
    this.songToPlay = songToPlay;
    console.log(songToPlay);
  }
}