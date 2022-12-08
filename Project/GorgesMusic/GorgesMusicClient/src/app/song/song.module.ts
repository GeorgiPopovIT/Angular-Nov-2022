import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { PlayComponent } from './play/play.component';
import { HttpClientModule } from '@angular/common/http';
// import { NgxAudioPlayerModule } from 'ngx-audio-player';



@NgModule({
  declarations: [
    ListComponent,
    PlayComponent
  ],
  imports: [
    CommonModule,
    NgbDropdownModule,
    MatProgressSpinnerModule,
    HttpClientModule
  ],
  exports:[ListComponent,PlayComponent]
})
export class SongModule { }
