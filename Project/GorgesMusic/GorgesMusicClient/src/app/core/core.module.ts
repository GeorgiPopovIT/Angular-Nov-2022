import { CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsideComponent } from './aside/aside.component';
import { RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { SongModule } from "../song/song.module";
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

@NgModule({
    declarations: [
        AsideComponent,
        MainComponent,
        PageNotFoundComponent
    ],
    exports: [AsideComponent, MainComponent],
    imports: [
        CommonModule,
        RouterModule,
        SongModule
    ],
    schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class CoreModule { }
