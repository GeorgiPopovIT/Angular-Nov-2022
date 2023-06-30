import { compileNgModule } from '@angular/compiler';
import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';

@Component({
  selector: 'app-last5-songs',
  templateUrl: './last5-songs.component.html',
  styleUrls: ['./last5-songs.component.css']
})
export class Last5SongsComponent implements OnInit, OnChanges {
  public songs$! : Observable<Song[]>;
  public songs! : Song[];

  
  public song! : Song;


  constructor(private songService : SongService) { }
  ngOnChanges(changes: SimpleChanges): void {
    console.log(this.song);
  }

  ngOnInit(): void {
    this.songs$ = this.songService.getLast5Songs();
  }

loadSongs(){
    this.songService.getLast5Songs().subscribe({
      next: (value) => {
        this.songs = value;
      },  
      error: (Response) => {
        console.log(Response);
      }
    });
  }  

  songPlayingHandler(currSong : Song){
    this.song = currSong;
  }

}
