import { Component, OnInit } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  public song! : Song | null;

  constructor(private songService : SongService,private route : ActivatedRoute)
   { }
  
  ngOnInit(): void {
    this.route.params.subscribe(({id}) => {
      this.song = null;
      this.loadSong(id);
    });
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
