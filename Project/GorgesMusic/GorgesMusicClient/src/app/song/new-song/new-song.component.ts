import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { SongService } from 'src/app/services/song.service';
import { SongInputModel } from 'src/app/shared/interfaces/songInputModel';


@Component({
  selector: 'app-new-song',
  templateUrl: './new-song.component.html',
  styleUrls: ['./new-song.component.css']
})
export class NewSongComponent implements OnInit {
  newSongForm = this.fb.group({
    name : ['',Validators.required],
    genre : ['',Validators.required],
    imageLink : ['',Validators.required],
    audioLink : ['',Validators.required]
  });

  constructor(private fb : FormBuilder, private songService : SongService) {}
 
  ngOnInit(): void {
  }

  addSongSubmit(){
    if(this.newSongForm.invalid){
      return;
    }

    const {name, genre, imageLink, audioLink} = this.newSongForm.value;


    const songToAdd : SongInputModel = {
      name : name!,
      genre : genre!,
      imageLink : imageLink!,
      audioLink : audioLink!
    };
    this.songService.createSong(songToAdd).subscribe({
     error : (Response) => {
      console.log(Response);
     }
    });
  }
}
