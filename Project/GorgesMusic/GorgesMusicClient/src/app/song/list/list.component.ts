import { Component, OnInit } from '@angular/core';
import { Song } from 'src/app/shared/interfaces/song';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
    public songs! : Song[];
    page : number = 1;
    listSize : number = 16;
   
    constructor(private songService : SongService) { }

  ngOnInit(): void {
      this.loadSongs();
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

  playSong(id : number){
    
  }

  listSongOnChange(event : any){
    this.listSize = event.target.value;
    this.page = event;
    this.loadSongs();
  }
}
