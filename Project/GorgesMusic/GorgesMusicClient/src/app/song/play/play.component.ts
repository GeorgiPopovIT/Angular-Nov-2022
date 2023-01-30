import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnChanges, OnInit {

  @Input()
  public song! : Song;

  constructor(private songService : SongService,private route : ActivatedRoute)
   {}
   
  ngOnInit(): void {
    this.loadSong(this.song.id);
  }
  
  ngOnChanges(changes: SimpleChanges): void {
    this.loadSong(changes['song'].currentValue.id);
  }

  loadSong(id : number) : void{
    this.songService.getSongById(id).subscribe({
      next :(value) => {
        this.song = value;
      },
      error: (Response) => {
        console.log(Response);
      }
    });
  }
}
