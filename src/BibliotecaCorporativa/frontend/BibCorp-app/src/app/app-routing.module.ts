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
} from "./components";
import { MinhasReservasComponent } from "./components/minhasReservas/minhasReservas.component";
import { PerfilComponent } from "./components/perfil/perfil.component";
import { AcervoDetalheComponent } from "./components/acervo/acervoDetalhe";

const routes: Routes = [
  { path: "principal", component: PrincipalComponent },
  { path: "login", component: LoginComponent },
  { path: "cadastroUsuario", component: CadastroUsuarioComponent },
  { path: "acervo", component: AcervoComponent },
  { path: "detalhes", component: AcervoDetalheComponent },
  { path: "solicitacoes", component: MinhasReservasComponent },
  { path: "perfil", component: PerfilComponent },

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

  { path: "**", redirectTo: "principal", pathMatch: "full" },
  { path: "", redirectTo: "principal", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
