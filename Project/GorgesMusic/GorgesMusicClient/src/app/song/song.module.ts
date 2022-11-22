import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';




@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule
  ],
  exports:[ListComponent]
})
export class SongModule { }
