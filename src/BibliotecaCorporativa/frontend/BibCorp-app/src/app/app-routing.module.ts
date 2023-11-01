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
  AcervoEdicaoComponent,
} from "./components";
import { MinhasReservasComponent } from "./components/minhasReservas/minhasReservas.component";
import { PerfilComponent } from "./components/usuario/perfil/perfil.component";
import { AcervoDetalheComponent } from "./components/acervo/detalhe";
import { AcervoListaComponent } from "./components/acervo/lista/acervoLista.component";

const routes: Routes = [
  { path: "principal", component: PrincipalComponent },
  { path: "solicitacoes", component: MinhasReservasComponent },

  { path: "acervos", redirectTo: "acervos/lista", pathMatch: "full" },
  {
    path: "acervos",
    component: AcervoComponent,
    children: [
      { path: "detalhe/:id", component: AcervoDetalheComponent },
      { path: "edicao/:id", component: AcervoEdicaoComponent },
      { path: "novo", component: AcervoEdicaoComponent },
      { path: "lista", component: AcervoListaComponent },
    ],
  },

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

  {
    path: "usuarios",
    component: UsuarioComponent,
    children: [
      { path: "login", component: LoginComponent },
      { path: "cadastro", component: CadastroUsuarioComponent },
      { path: "perfil", component: PerfilComponent },
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
