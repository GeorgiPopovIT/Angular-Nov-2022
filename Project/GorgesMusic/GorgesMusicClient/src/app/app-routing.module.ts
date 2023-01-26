// import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { MainComponent } from './core/main/main.component';
import { PageNotFoundComponent } from './core/page-not-found/page-not-found.component';
import { PlayComponent } from './song/play/play.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    pathMatch : 'full'
  },
  {
    path: 'not-found',
    component: PageNotFoundComponent
  },
  {
    path : 'song/:id',
    component: PlayComponent
  },
  {
    path : 'auth',
    loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '**',
    redirectTo: '/not-found'
  }
];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
export const AppRoutingModule = RouterModule.forRoot(routes,{preloadingStrategy: PreloadAllModules});
