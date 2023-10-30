import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import {
  AcervoComponent,
  CadastroUsuarioComponent,
  LoginComponent,
  PrincipalComponent,
  PatrimonioComponent,
  PatrimonioDetalheComponent,
  PatrimonioListaComponent,
  UsuarioComponent,
} from "./components";
import { MinhasReservasComponent } from "./components/minhasReservas/minhasReservas.component";
import { PerfilComponent } from "./components/usuario/perfil/perfil.component";
import { AcervoDetalheComponent } from "./components/acervo/acervoDetalhe";

const routes: Routes = [
  { path: "principal", component: PrincipalComponent },
  { path: "acervo", component: AcervoComponent },
  { path: "detalhes", component: AcervoDetalheComponent },
  { path: "solicitacoes", component: MinhasReservasComponent },
  
  { path: "patrimonios", redirectTo: "patrimonios/lista", pathMatch: "full" },
  {
    path: "patrimonios",
    component: PatrimonioComponent,
    children: [
      { path: "detalhe/:id", component: PatrimonioDetalheComponent },
      { path: "novo", component: PatrimonioDetalheComponent },
      { path: "lista", component: PatrimonioListaComponent },
    ],
  },
  
  { path: "usuarios/perfil", component: PerfilComponent },
  
  {
    path: "usuarios",
    component: UsuarioComponent,
    children: [
      { path: "login", component: LoginComponent },
      { path: "cadastro", component: CadastroUsuarioComponent },
    ],
  },

  { path: "**", redirectTo: "principal", pathMatch: "full" },
  { path: "", redirectTo: "principal", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
