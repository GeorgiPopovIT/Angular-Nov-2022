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



@NgModule({
  declarations: [
    ListComponent,
    PlayComponent,
    ListItemComponent,
    NewSongComponent
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
  exports:[ListComponent,PlayComponent,NewSongComponent]
})
export class SongModule { }
