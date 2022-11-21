import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsideComponent } from './aside/aside.component';
import {MainComponent} from './main/main.component';
import { SongModule } from '../song/song.module';

@NgModule({
  declarations: [AsideComponent,MainComponent],
  imports: [
    CommonModule,
    SongModule
  ],
  exports: [AsideComponent,MainComponent]
})
export class CoreModule { }
