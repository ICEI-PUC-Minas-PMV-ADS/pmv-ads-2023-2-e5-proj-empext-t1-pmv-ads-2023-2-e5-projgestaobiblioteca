import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AcervoComponent, CadastroUsuarioComponent, LoginComponent, PrincipalComponent, DetalhesComponent } from './components';

const routes: Routes = [
  { path: 'principal', component: PrincipalComponent},
  { path: 'login', component: LoginComponent},
  { path: 'cadastroUsuario', component: CadastroUsuarioComponent},
  { path: 'acervo', component: AcervoComponent},
  { path: 'detalhes', component: DetalhesComponent},
  { path: '**', redirectTo: 'detalhes', pathMatch: 'full'},
  { path: '', redirectTo: 'detalhes', pathMatch: 'full'},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
