import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';


@Component({
  selector: 'app-add-new-song',
  templateUrl: './add-new-song.component.html',
  styleUrls: ['./add-new-song.component.css']
})
export class AddNewSongComponent implements OnInit {
  newSongForm = this.fb.group({
    name : ['',Validators.required],
    genre : ['',,Validators.required],
    imageLink : ['',,Validators.required],
    audioLink : ['',,Validators.required]
  });

  constructor(private fb : FormBuilder) {}

  ngOnInit(): void {
  }

}
