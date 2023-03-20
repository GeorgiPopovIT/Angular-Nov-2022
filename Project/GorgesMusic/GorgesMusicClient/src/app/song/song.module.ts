import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import {NgxPaginationModule} from 'ngx-pagination'; 
import { PlayComponent } from './play/play.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ListItemComponent } from './list-item/list-item.component';
import { NewSongComponent } from './new-song/new-song.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Last5SongsComponent } from './last5-songs/last5-songs.component';



@NgModule({
  declarations: [
    ListComponent,
    PlayComponent,
    ListItemComponent,
    NewSongComponent,
    Last5SongsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatProgressSpinnerModule,
    NgxPaginationModule,
    HttpClientModule,
    RouterModule
  ],
  exports:[ListComponent,PlayComponent,NewSongComponent, Last5SongsComponent]
})
export class SongModule { }
