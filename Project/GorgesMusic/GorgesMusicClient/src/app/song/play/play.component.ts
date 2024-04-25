import { Component, Input, OnChanges,OnDestroy,OnInit, SimpleChanges, signal } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';
import { ActivatedRoute } from '@angular/router';
import { BehaviorSubject, Subject } from 'rxjs';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent  implements OnChanges  {

  @Input()
  public songToPlay! : Song;
  public songUrl = signal(this.songToPlay);

  constructor(private songService : SongService,private route : ActivatedRoute)
   {}
  
  ngOnChanges(changes: SimpleChanges): void {
    if(changes['songToPlay'] !== undefined){
       this.songUrl.update(v =>v = changes['songToPlay'].currentValue);
       document.getElementsByTagName('audio')[0].load();
    }
  }
}
