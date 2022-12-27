import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Song } from '../shared/interfaces/song';

const baseApiUrl = environment.apiURL;


@Injectable({
  providedIn: 'root'
})
export class SongService {
  constructor(private httpClient : HttpClient) { }

  getAllSongs(pageNumber? : number , songsPerPage? : number) : Observable<Song[]>{
    let queryParams = new HttpParams();
      queryParams.append('pageNumber',pageNumber!);
      queryParams.append('songsPerPage',songsPerPage!);

      return this.httpClient.get<Song[]>(baseApiUrl +'/api/song', {params: queryParams});
  }
  
  getSongById(id : number) : Observable<Song>{
    return this.httpClient.get<Song>(baseApiUrl + `/api/song/${id}`)
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
