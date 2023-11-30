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
  DeleteModalComponent,
  JwtInterceptor,
  NavBarComponent,
  TitlebarComponent,
} from "./shared";

import {
  AlterarLocalComponent,
  EmprestimoService,
  GerenciarSolicitacoesComponent,
  MinhasReservasComponent,
  ModalRenovarComponent,
} from "./emprestimos";

import {
  AcervoComponent,
  AcervoDetalheComponent,
  AcervoEdicaoComponent,
  AcervoListaComponent,
  AcervoService,
  ModalEmprestarComponent,
  ModalSucessoComponent,
} from "./acervos";

import {
  PatrimonioComponent,
  PatrimonioDetalheComponent,
  PatrimonioListaComponent,
  PatrimonioService,
} from "./patrimonios";
import { HomeAdminComponent, PrincipalComponent } from "./home";
import {
  CadastroUsuarioComponent,
  LoginComponent,
  LoginService,
  PerfilComponent,
  UsuarioComponent,
  UsuarioService,
} from "./usuarios";
import { UploadService } from "./upload";

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

    AlterarLocalComponent,
    GerenciarSolicitacoesComponent,
    MinhasReservasComponent,
    ModalRenovarComponent,

    PrincipalComponent,
    HomeAdminComponent,

    CadastroUsuarioComponent,
    LoginComponent,
    PerfilComponent,
    UsuarioComponent,

    // Componentes Angular
    AppComponent,

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
  ],
  providers: [
    AcervoService,
    EmprestimoService,
    LoginService,
    PatrimonioService,
    UploadService,
    UsuarioService,

    NgxSpinnerService,
    ToastrService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
