import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { PlayComponent } from './play/play.component';




@NgModule({
  declarations: [
    ListComponent,
    PlayComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule,
    NgbDropdownModule
  ],
  exports:[ListComponent]
})
export class SongModule { }
