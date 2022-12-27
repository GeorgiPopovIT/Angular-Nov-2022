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
    page = 1 ;
   
    constructor(private songService : SongService) { }

  ngOnInit(): void {
      this.songService.getAllSongs().subscribe({
      next: (value) => {
        this.songs = value;
      },  
      error: (Response) => {
        console.log(Response);
      }
    });
  }
  loadSongs(currentPage : number){

    console.log(currentPage)
    // this.songService.getAllSongs().subscribe({
    //   next: (value) => {
    //     this.songs = value;
    //   },  
    //   error: (Response) => {
    //     console.log(Response);
    //   }
    // });
  }
}
