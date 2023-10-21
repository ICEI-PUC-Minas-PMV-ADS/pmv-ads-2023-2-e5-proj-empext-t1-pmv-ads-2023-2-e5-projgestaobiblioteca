import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PrincipalComponent } from './components';

const routes: Routes = [
  { path: 'principal', component: PrincipalComponent},
  { path: '', redirectTo: 'principal', pathMatch: 'full'},
  { path: '**', redirectTo: 'principal', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
