import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from 'src/app/comp/home/home.component';
import { HerolistComponent } from 'src/app/comp/herolist/herolist.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'herolist', component: HerolistComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
