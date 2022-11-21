import { Component, OnInit } from '@angular/core';
import { ISong } from 'src/app/shared/interfaces/song';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
    songs: ISong[] | null = null;

  constructor(private songService : SongService) { }

  ngOnInit(): void {
      this.songService.getAllSongs().subscribe({
      next: (value) => {
        console.log(value);
        this.songs = value;
      },
      error: (Response) => {
        console.log(Response);
      }
    });
  }

}
