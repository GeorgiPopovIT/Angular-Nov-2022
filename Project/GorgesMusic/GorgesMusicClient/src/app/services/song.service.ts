import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ISong } from '../interfaces/song';

const baseApiUrl = environment.apiURL;


@Injectable({
  providedIn: 'root'
})
export class SongService {

  constructor(private httpClient : HttpClient) { }

  getAllSongs()  :Observable<ISong[]>{
    return this.httpClient.get<ISong[]>(baseApiUrl + '/api/songs');
  }
}