import { Injectable, NgModule } from "@angular/core";
import { Routes, mapToCanActivate, RouterModule } from "@angular/router";
import { UsuarioComponent, PerfilComponent, AcervoComponent, AcervoDetalheComponent, AcervoEdicaoComponent, AcervoListaComponent, LoginComponent, CadastroUsuarioComponent, PrincipalComponent } from "./components";
import { GerenciarSolicitacoesComponent } from "./components/gerenciarSolicitacoes/gerenciarSolicitacoes.component";
import { homeAdminComponent } from "./components/homeAdmin/homeAdmin.component";
import { MinhasReservasComponent } from "./components/minhasReservas";
import { PatrimonioComponent, PatrimonioDetalheComponent, PatrimonioListaComponent } from "./patrimonios";
import { AuthGuard } from "./shared";


@Injectable({ providedIn: "root" })
export class AdminGuard {
  canActivate() {
    return true;
  }
}

const routes: Routes = [
  { path: "", redirectTo: "principal", pathMatch: "full" },

  {
    path: "",
    runGuardsAndResolvers: "always",
    canActivate: mapToCanActivate([AuthGuard]),
    children: [
      {
        path: "usuarios",
        component: UsuarioComponent,
        children: [{ path: "perfil", component: PerfilComponent }],
      },

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

      {
        path: "patrimonios",
        redirectTo: "patrimonios/lista",
        pathMatch: "full",
      },
      {
        path: "patrimonios",
        component: PatrimonioComponent,
        children: [
          { path: "detalhe/:id", component: PatrimonioDetalheComponent },
          { path: "novo", component: PatrimonioDetalheComponent },
          { path: "lista", component: PatrimonioListaComponent },
        ],
      },
    ],
  },

  {
    path: "usuarios",
    component: UsuarioComponent,
    children: [
      { path: "login", component: LoginComponent },
      { path: "cadastro", component: CadastroUsuarioComponent },
    ],
  },

  { path: "solicitacoes", component: MinhasReservasComponent },

  { path: "gerenciar-solicitacoes", component: GerenciarSolicitacoesComponent },

  { path: "home-admin", component: homeAdminComponent },

  { path: "principal", component: PrincipalComponent },
  { path: "**", redirectTo: "principal", pathMatch: "full" },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
