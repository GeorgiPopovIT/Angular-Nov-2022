import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SongService } from 'src/app/services/song.service';


@Component({
  selector: 'app-new-song',
  templateUrl: './new-song.component.html',
  styleUrls: ['./new-song.component.css']
})
export class NewSongComponent  {
  newSongForm = this.fb.group({
    name : ['',Validators.required],
    genre : ['',Validators.required],
    imageLink : ['',Validators.required],
    songAudio : ['',Validators.required]
  });

  private fileUpload! : File;

  constructor(private fb : FormBuilder, private songService : SongService, private router : Router) {}
 
  
  onFileSelected($event  :any){
    this.fileUpload = $event.target.files[0];
  }

  addSongSubmit(){
    if(this.newSongForm.invalid){
      return;
    }
    const {name, genre, imageLink} = this.newSongForm.value;

   const formData = new FormData();
   formData.append('name', name!);
   formData.append('genre', genre!);
   formData.append('imageLink', imageLink!);
   formData.append('songAudio', this.fileUpload!);


    this.songService.createSong(formData).subscribe({
      next: (value) => {
        this.router.navigate(['/']);
      },
     error : (Response) => {
      console.log(Response);
     }
    });
  }
}
