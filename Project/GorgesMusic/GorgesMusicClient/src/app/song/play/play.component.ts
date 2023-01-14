import { Component, OnInit } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { Song } from 'src/app/shared/interfaces/song';
import { ActivatedRoute } from '@angular/router';
import { switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {

  public song! : Song ;

  constructor(private songService : SongService,private route : ActivatedRoute)
   { }
  
  ngOnInit(): void {
    // this.route.params.subscribe(({id}) => {
    //   this.song = null;
    //   this.loadSong(id);
    // });

    this.route.params.pipe(
      tap(() => this.song == null),
      switchMap(({id}) => this.songService.getSongById(id))
        ).subscribe( song => {
          this.song = song;
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
