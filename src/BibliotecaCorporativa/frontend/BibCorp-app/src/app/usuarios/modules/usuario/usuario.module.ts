import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginService, UsuarioService } from '../../services';



@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    LoginService,
    UsuarioService
  ]
})
export class UsuarioModule { }
