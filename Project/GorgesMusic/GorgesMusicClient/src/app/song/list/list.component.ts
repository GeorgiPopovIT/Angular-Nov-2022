import { Component, OnInit } from '@angular/core';
import { Song } from 'src/app/shared/interfaces/song';
import { SongService } from 'src/app/services/song.service';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner'

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
    public songs!: Song[];

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
}
