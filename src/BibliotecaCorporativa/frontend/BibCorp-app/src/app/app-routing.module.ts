import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AcervoComponent, CadastroUsuarioComponent, LoginComponent, PrincipalComponent } from './components';

const routes: Routes = [
  { path: 'principal', component: PrincipalComponent},
  { path: '', redirectTo: 'principal', pathMatch: 'full'},
  { path: 'login', component: LoginComponent},
  { path: 'cadastroUsuario', component: CadastroUsuarioComponent},
  { path: 'acervo', component: AcervoComponent},
  { path: '**', redirectTo: 'principal', pathMatch: 'full'},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
