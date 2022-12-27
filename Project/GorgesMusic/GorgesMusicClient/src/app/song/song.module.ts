import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';
import { PlayComponent } from './play/play.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ListComponent,
    PlayComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule,
    MatProgressSpinnerModule,
    HttpClientModule,
    RouterModule
  ],
  exports:[ListComponent,PlayComponent]
})
export class SongModule { }
