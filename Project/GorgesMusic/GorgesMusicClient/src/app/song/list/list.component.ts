import { Component, EventEmitter, OnInit, Output, inject } from '@angular/core';
import { Song } from 'src/app/shared/interfaces/song';
import { SongService } from 'src/app/services/song.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
    public songs$! : Observable<Song[]>;
    public songs! : Song[];
    page : number = 1;
    listSize : number = 16;
    @Output()
    public songToEmit = new EventEmitter<Song>();
    public song! : Song;
    private songService = inject(SongService);
   

  ngOnInit(): void {
    this.songs$ = this.songService.getAllSongs();
  }
  loadSongs(){
    this.songService.getAllSongs().subscribe({
      next: (value) => {
        this.songs = value;
      },  
      error: (Response) => {
        console.log(Response);
      }
    });
  }

  songPlayingHandler(currSong : Song){
    this.songToEmit.emit(currSong);
  }
}