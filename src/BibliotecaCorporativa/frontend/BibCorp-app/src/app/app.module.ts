import { AppComponent } from "./app.component";

import { AppRoutingModule } from "./app-routing.module";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from "@angular/platform-browser";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { NgbCollapseModule, NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { NgSelectModule } from "@ng-select/ng-select";

import { NgxSpinnerModule } from "ngx-spinner";
import { ToastrModule } from "ngx-toastr";

import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatSelectModule } from "@angular/material/select";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatToolbarModule } from "@angular/material/toolbar";

import {
  CadastroUsuarioComponent,
  LoginComponent,
  NavBarComponent,
  PatrimonioCadastroComponent,
  PatrimonioComponent,
  PatrimonioDetalheComponent,
  PatrimonioListaComponent,
  PrincipalComponent,
  TitlebarComponent,
} from "./components";
import { MinhasReservasComponent } from "./components/minhasReservas/minhasReservas.component";
import { PerfilComponent } from "./components/perfil/perfil.component";
import { LoginService } from "./services/Usuarios/Login";
import { CadastroUsuarioService } from "./services/Usuarios/CadastroUsuario";
import { MinhasReservasService } from "./services/minhasReservas/minhasReservas.service";
import { AcervoDetalheComponent } from "./components/acervo/acervoDetalhe";

@NgModule({
  declarations: [
    AcervoDetalheComponent,
    AppComponent,
    CadastroUsuarioComponent,
    LoginComponent,
    NavBarComponent,
    PatrimonioDetalheComponent,
    PatrimonioCadastroComponent,
    PatrimonioListaComponent,
    PatrimonioComponent,
    PrincipalComponent,
    MinhasReservasComponent,
    PerfilComponent,
    TitlebarComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbCollapseModule,
    NgbModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatSidenavModule,
    MatToolbarModule,
    NgSelectModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: "toast-bottom-right",
      preventDuplicates: true,
      progressBar: true,
    }),
  ],
  providers: [LoginService, CadastroUsuarioService, MinhasReservasService],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
