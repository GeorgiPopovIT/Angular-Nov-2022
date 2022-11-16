import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsideComponent } from './aside/aside.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { ContentComponent } from './content/content.component';

@NgModule({
  declarations: [AsideComponent, ContentComponent],
  imports: [
    CommonModule,
    MatSidenavModule
  ],
  exports: [AsideComponent,ContentComponent]
})
export class CoreModule { }
