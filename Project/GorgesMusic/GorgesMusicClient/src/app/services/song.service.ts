import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Song } from '../shared/interfaces/song';
import { SongInputModel } from '../shared/interfaces/songInputModel';

@Injectable({
  providedIn: 'root'
})
export class SongService {
  private songPath = environment.apiURL + '/api/song';

  constructor(private httpClient : HttpClient) { }

  getAllSongs() : Observable<Song[]>{
      return this.httpClient.get<Song[]>(this.songPath);
  }
  
  getSongById(id : number) : Observable<Song>{
    return this.httpClient.get<Song>(this.songPath + `/${id}`)
  }
  createSong(song : SongInputModel) : Observable<Song>{
    return this.httpClient.post<Song>(this.songPath + `/create`);
  }

  // playAudio(mp3Url : string){
  //   let audio = new Audio();
  //   audio.src = mp3Url;
  //   audio.load();
  //   audio.play();
  // }

  // addSongToPlayList() : Observable<Track>{
    
  // }
}
