import { Component, inject } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SongService } from '../../services/song.service';


@Component({
  standalone: false,
  selector: 'app-new-song',
  templateUrl: './new-song.component.html',
  styleUrls: ['./new-song.component.css']
})
export class NewSongComponent  {

  private fileUpload! : File;
  private fb = inject(FormBuilder);
  private songService = inject(SongService);
  private router = inject(Router);

  newSongForm = this.fb.group({
    name : ['',Validators.required],
    genre : ['',Validators.required],
    imageLink : ['',Validators.required],
    songAudio : ['',Validators.required]
  });
  
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
