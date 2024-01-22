import { Component, Input, OnChanges,OnInit, SimpleChanges, signal } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, Subject } from 'rxjs';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent  implements  OnChanges  {

  @Input()
  public songToPlay! : Song;

  constructor(private songService : SongService,private route : ActivatedRoute)
   {}
  
 
  ngOnChanges(changes: SimpleChanges): void {
  }

}
