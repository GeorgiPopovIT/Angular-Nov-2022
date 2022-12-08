import { Component, OnInit } from '@angular/core';
import { SongService } from 'src/app/services/song.service';
// import { Track } from 'ngx-audio-player';   

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

  //msaapPlaylist : Track[] = [];
  

  constructor(private songService : SongService) { }

  ngOnInit(): void {

  }
}
