import { Component, OnInit, Output, Input } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
import { Track } from 'ngx-audio-player';   
import { Song } from 'src/app/shared/interfaces/song';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {
  
  msaapDisplayTitle = true;
  msaapDisplayPlayList = true;
  msaapPageSizeOptions = [2,4,6];
  msaapDisplayVolumeControls = true;
  msaapDisplayRepeatControls = false;
  msaapDisplayArtist = false;
  msaapDisplayDuration = false;
  msaapDisablePositionSlider = true;

  private id! : number;
  public song! : Song;

  constructor(private songService : SongService,private route : ActivatedRoute, 
    public msaapPlaylist : Track)
   { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];
    
    this.songService.getSongById(this.id).subscribe({
      next :(value) => {
        this.song = value;
        this.msaapPlaylist = {
          title: this.song.name,
          link: this.song.audioLink
        };
      },
      error: (Response) => {
        console.log(Response);
      }
    });
  }
}
