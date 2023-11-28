import { Component, OnInit } from "@angular/core";
import {
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Usuario, UsuarioService } from "src/app/usuarios";

import { FormValidator } from "src/app/util";

@Component({
  selector: "app-cadastroUsuario",
  templateUrl: "./cadastroUsuario.component.html",
  styleUrls: ["./cadastroUsuario.component.scss"],
})
export class CadastroUsuarioComponent implements OnInit {
  public formCadastro: FormGroup;

  public usuario: Usuario;

  public get ctrF(): any {
    return this.formCadastro.controls;
  }

  constructor(
    private usuarioService: UsuarioService,
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void {
    this.formCadastro = new FormGroup({
      nome: new FormControl("", [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(150),
      ]),
      userName: new FormControl("", [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(20),
      ]),
      phoneNumber: new FormControl("", [
        Validators.required,
        Validators.minLength(11),
        Validators.maxLength(11),
      ]),
      email: new FormControl("", [
        Validators.required,
        Validators.email,
      ]),
      password: new FormControl("", [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(8),
      ]),
    });
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }

  public clearForm(): void {
    this.formCadastro.reset();
  }

  public register(): void {
    this.spinnerService.show();

    this.usuario = { ...this.formCadastro.value };

    this.usuarioService.createUser(this.usuario).subscribe(
      () => {
        this.router.navigateByUrl("/principal");
        location.replace("/princial");
        this.toastrService.success("Conta Cadastrada!", "Sucesso!");
      },
      (error: any) => {
        this.toastrService.error("Ocorreu um erro ao tentar cadastrar o usuário");
        console.error(error)
      }
    )
    .add(() => this.spinnerService.hide())
  }

  public reloadPrincipal(): void {
    this.router.navigateByUrl("/principal");
    location.replace("/princial");
  }
}
