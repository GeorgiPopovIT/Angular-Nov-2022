import { Component, OnInit, Output, Input } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';
import { ActivatedRoute } from '@angular/router';
import { ChangeDetectionStrategy } from '@angular/core';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  public song! : Song;

  constructor(private songService : SongService,private route : ActivatedRoute)
   { }

  ngOnInit(): void {
    let id = this.route.snapshot.params['id'];

    this.songService.getSongById(id).subscribe({
      next :(value) => {
        this.song = value;
      },
      error: (Response) => {
        console.log(Response);
      }
    });
  }

  // loadSong(id : number) : void{
  //   this.songService.getSongById(id).subscribe({
  //     next :(value) => {
  //       this.song = value;
  //     },
  //     error: (Response) => {
  //       console.log(Response);
  //     }
  //   });
  // }
}
