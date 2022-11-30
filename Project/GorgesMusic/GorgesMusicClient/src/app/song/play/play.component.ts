import { Component, OnInit } from '@angular/core';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  constructor(private songService : SongService) { }

  ngOnInit(): void {

  }

}
