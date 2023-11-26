import { Component, OnInit } from "@angular/core";
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Usuario } from "src/app/models";
import { UsuarioUpdate } from "src/app/models/Usuarios/UsuarioUpdate";
import { UsuarioService } from "src/app/services";
import { FormValidator } from "src/app/util";

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  public formPerfil: FormGroup;

  public usuario = {} as Usuario;
  public usuarioUpdate = {} as UsuarioUpdate;

  public get ctrF(): any {
    return this.formPerfil.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private usuarioService: UsuarioService
    ) {}



  ngOnInit(): void {
    this.validation();
    this.getUserName();
  }

  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: FormValidator.argsCompare('password', 'confirmPassword')
    };

    this.formPerfil = this.formBuilder.group({
      nome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required]],
      password: ['', [Validators.minLength(6), Validators.nullValidator]],
      confirmPassword: ['', Validators.nullValidator],
      userName: ['']
    }, formOptions);
  }

  public getUserName(): void {
    this.spinnerService.show()

    this.usuarioService
    .getUsuarioByUserName()
    .subscribe(
      (usuarioLogado: UsuarioUpdate) => {
        console.log(usuarioLogado)
        this.formPerfil.patchValue(usuarioLogado)
        //this.getUsuarioById(usuarioLogado.id)

      },
      (error: any) => {
        this.toastrService.error(
          "Falha ao recuperar usuário logado.",
          "Erro"
        );
        console.error(error);
      }
    )
    .add(() => this.spinnerService.hide());
  }

  public fieldValidator(campoForm: FormControl): any {
    return FormValidator.checkFieldsWhithError(campoForm);
  }

  public messageReturned(nomeCampo: FormControl, nomeElemento: string): any {
    return FormValidator.returnMessage(nomeCampo, nomeElemento);
  }
  // Conveniente para pegar um FormField apenas com a letra F
  get f(): any { return this.formPerfil.controls; }

  onSubmit(): void {

    this.atualizarUsuario();
  }

  public atualizarUsuario(): void{
    this.spinnerService.show();

    this.usuarioUpdate = { ...this.formPerfil.value }

    console.log(this.usuarioUpdate)

    this.usuarioService
      .updateUser(this.usuarioUpdate)
      .subscribe(
        () => {
          this.toastrService.success("Usuario atualizado!", "Sucesso!")
        },
        (error: any) => {
          this.toastrService.error("Falha ao atualizar usuário", "Erro!")
          console.error(error)
        }
      )
      .add(() => this.spinnerService.hide())
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.formPerfil.reset();
  }

}
