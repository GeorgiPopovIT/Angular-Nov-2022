import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AsideComponent } from './aside/aside.component';
import { MatSidenavModule } from '@angular/material/sidenav';

@NgModule({
  declarations: [AsideComponent],
  imports: [
    CommonModule,
    MatSidenavModule
  ],
  exports: [AsideComponent]
})
export class CoreModule { }
