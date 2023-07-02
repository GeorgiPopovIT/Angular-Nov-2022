import { compileNgModule } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';

@Component({
  selector: 'app-last5-songs',
  templateUrl: './last5-songs.component.html',
  styleUrls: ['./last5-songs.component.css']
})
export class Last5SongsComponent implements OnInit {
  public songs$! : Observable<Song[]>;
  public songs! : Song[];

  public song! : Song;

  constructor(private songService : SongService) { }

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
    console.log(this.song != null);
  }

}
