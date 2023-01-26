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



@NgModule({
  declarations: [
    ListComponent,
    PlayComponent,
    ListItemComponent
  ],
  imports: [
    CommonModule,
    NgbPaginationModule,
    MatProgressSpinnerModule,
    NgxPaginationModule,
    HttpClientModule,
    RouterModule
  ],
  exports:[ListComponent,PlayComponent]
})
export class SongModule { }
