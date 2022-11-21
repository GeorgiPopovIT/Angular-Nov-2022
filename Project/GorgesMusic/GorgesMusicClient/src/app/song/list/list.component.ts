import { Component, OnInit } from '@angular/core';
import { ISong } from 'src/app/interfaces/song';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  songs: ISong[] = [];

  constructor(private songService : SongService) { }

  ngOnInit(): void {
      this.songService.getAllSongs().subscribe({
      next: (songs) => {
        console.log(songs);
      },
      error: (Response) => {
        console.log(Response);
      }
    });
  }

}
