// import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './auth/register/register.component';
import { PageNotFoundComponent } from './core/page-not-found/page-not-found.component';
import { ListComponent } from './song/list/list.component';
import { PlayComponent } from './song/play/play.component';

const routes: Routes = [
  {
    path : ' ',
    pathMatch: 'full',  
    component : ListComponent,
  },
  {
    path : 'auth/register',
    component : RegisterComponent
  },
  {
    path : 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'song/:id',
    component : PlayComponent
  },
  {
    path : '**',
    component: PageNotFoundComponent
  },
];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
export const AppRoutingModule = RouterModule.forRoot(routes,{preloadingStrategy: PreloadAllModules});
