import { AppComponent } from "./app.component";

import { AppRoutingModule } from "./app-routing.module";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";

import {
  NgbCollapseModule,
  NgbPaginationModule,
} from "@ng-bootstrap/ng-bootstrap";
import { NgSelectModule } from "@ng-select/ng-select";

import { NgxSpinnerModule, NgxSpinnerService } from "ngx-spinner";
import { ToastrModule, ToastrService } from "ngx-toastr";

import { MatButtonModule } from "@angular/material/button";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatDialogModule } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatNativeDateModule } from "@angular/material/core";
import { MatSelectModule } from "@angular/material/select";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatTooltipModule } from "@angular/material/tooltip";

import {
  CadastroUsuarioComponent,
  LoginComponent,
  PatrimonioComponent,
  PatrimonioDetalheComponent,
  PatrimonioListaComponent,
  PerfilComponent,
  PrincipalComponent,
  UsuarioComponent,
} from "./components";

import { MinhasReservasComponent } from "./components/minhasReservas/minhasReservas.component";
import { ModalRenovarComponent } from "./components/minhasReservas/modalRenovar/modalRenovar.component";
import { AlterarLocalComponent } from "./components/minhasReservas/alterarLocal";
import {
  DeleteModalComponent,
  JwtInterceptor,
  NavBarComponent,
  TitlebarComponent,
} from "./shared";
import { GerenciarSolicitacoesComponent } from "./components/gerenciarSolicitacoes/gerenciarSolicitacoes.component";
import { homeAdminComponent } from "./components/homeAdmin/homeAdmin.component";
import { UsuarioModule } from "./usuarios";
import { EmprestimoModule } from "./emprestimos";
import {
  AcervoComponent,
  AcervoDetalheComponent,
  AcervoListaComponent,
  AcervoService,
  ModalEmprestarComponent,
  ModalSucessoComponent,
} from "./acervos";
import { AcervoEdicaoComponent } from "./acervos/components/edicao";
import { PatrimonioService } from "./patrimonios";

@NgModule({
  declarations: [
    // Novos componentes ACERVOS
    AcervoComponent,
    AcervoDetalheComponent,
    AcervoEdicaoComponent,
    AcervoListaComponent,
    ModalEmprestarComponent,
    ModalSucessoComponent,

    PatrimonioComponent,
    PatrimonioDetalheComponent,
    PatrimonioListaComponent,

    // Componentes Angular
    AppComponent,
    CadastroUsuarioComponent,
    LoginComponent,
    PatrimonioDetalheComponent,
    PatrimonioListaComponent,
    PatrimonioComponent,
    PrincipalComponent,
    MinhasReservasComponent,
    PerfilComponent,
    UsuarioComponent,
    ModalRenovarComponent,
    AlterarLocalComponent,
    GerenciarSolicitacoesComponent,
    homeAdminComponent,

    // Shared Components
    NavBarComponent,
    TitlebarComponent,
    DeleteModalComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    NgbCollapseModule,
    MatButtonModule,
    MatDatepickerModule,
    MatDialogModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatNativeDateModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    MatTooltipModule,
    NgSelectModule,
    NgxSpinnerModule,
    NgbPaginationModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: "toast-bottom-right",
      preventDuplicates: true,
      progressBar: true,
    }),

    EmprestimoModule,
    UsuarioModule,
  ],
  providers: [
    AcervoService,
    PatrimonioService,
    NgxSpinnerService,
    ToastrService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
