import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Song } from '../shared/interfaces/song';

@Injectable({
  providedIn: 'root'
})
export class SongService {
  private songPath = environment.apiURL + '/api/song';

  constructor(private httpClient : HttpClient) { }

  getAllSongs() : Observable<Song[]>{
    return this.httpClient.get<Song[]>(this.songPath);
  }

  getLast5Songs() : Observable<Song[]> {
    return this.httpClient.get<Song[]>(this.songPath + '/lastsongs');
  }
  
  getSongById(id : number) : Observable<Song>{
    return this.httpClient.get<Song>(this.songPath + `/${id}`)
  }
  createSong(song : FormData) : Observable<any>{
    return this.httpClient.post(this.songPath + `/create`,song);
  }

}
