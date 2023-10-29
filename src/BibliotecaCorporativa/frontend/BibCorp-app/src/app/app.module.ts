import { AppComponent } from "./app.component";

import { AppRoutingModule } from "./app-routing.module";

import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { BrowserModule } from "@angular/platform-browser";
import { CommonModule } from "@angular/common";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { NgbCollapseModule } from "@ng-bootstrap/ng-bootstrap";
import { NgSelectModule } from "@ng-select/ng-select";

import { NgxSpinnerModule, NgxSpinnerService } from "ngx-spinner";
import { ToastrModule, ToastrService } from "ngx-toastr";

import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatNativeDateModule } from '@angular/material/core';
import { MatSelectModule } from "@angular/material/select";
import { MatSidenavModule } from "@angular/material/sidenav";
import { MatToolbarModule } from "@angular/material/toolbar";



import {
  CadastroUsuarioComponent,
  LoginComponent,
  NavBarComponent,
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
import { PatrimonioService } from "./services";
import { MatDialogModule } from '@angular/material/dialog';
import { DeleteModalComponent } from "./components/deleteModal/deleteModal.component";
import { MatButtonModule } from "@angular/material/button";

@NgModule({
  declarations: [
    AcervoDetalheComponent,
    AppComponent,
    CadastroUsuarioComponent,
    DeleteModalComponent,
    LoginComponent,
    NavBarComponent,
    PatrimonioDetalheComponent,
    PatrimonioListaComponent,
    PatrimonioComponent,
    PrincipalComponent,
    MinhasReservasComponent,
    PerfilComponent,
    TitlebarComponent,
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
    NgSelectModule,
    NgxSpinnerModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: "toast-bottom-right",
      preventDuplicates: true,
      progressBar: true,
    }),
  ],
  providers: [
    CadastroUsuarioService, 
    LoginService, 
    MinhasReservasService, 
    NgxSpinnerService,
    PatrimonioService,
    ToastrService,
  ],
  bootstrap: [
    AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
