//import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './song/list/list.component';

export const routes: Routes = [
  {
    path : '',
    pathMatch: 'full',  
    redirectTo : '/song/list',
    component: ListComponent
  }
];

export const AppRoutingModule = RouterModule.forRoot(routes);

//   @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
