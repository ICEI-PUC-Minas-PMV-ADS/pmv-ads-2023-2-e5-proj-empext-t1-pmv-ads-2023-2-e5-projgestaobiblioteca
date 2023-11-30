import { Component, OnInit } from "@angular/core";
import {
  AbstractControlOptions,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from "@angular/forms";
import { FormValidator } from "src/app/util";
import { UsuarioService } from "../../services";
import { NgxSpinnerService } from "ngx-spinner";
import { UsuarioUpdate } from "../../models";
import { ToastrService } from "ngx-toastr";
import { UploadService } from "src/app/upload";
import { environment } from "src/assets/environments/environments";

@Component({
  selector: "app-perfil",
  templateUrl: "./perfil.component.html",
  styleUrls: ["./perfil.component.scss"],
})
export class PerfilComponent implements OnInit {
  public formPerfil: FormGroup;

  public usuario: UsuarioUpdate;

  public fotoUpload: string = "not-available.png";
  public fotoURL: string = "../../../../assets/Images/download.png";
  public file: File[];

  public get ctrF(): any {
    return this.formPerfil.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private usuarioService: UsuarioService,
    private uploadService: UploadService
  ) {}

  ngOnInit(): void {
    this.validation();
    this.getUsername();
  }

  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: FormValidator.argsCompare("password", "confirmPassword"),
    };

    this.formPerfil = this.formBuilder.group(
      {
        nome: ["", Validators.required],
        email: ["", [Validators.required, Validators.email]],
        phoneNumber: ["", [Validators.required]],
        password: ["", [Validators.minLength(6), Validators.nullValidator]],
        confirmPassword: ["", Validators.nullValidator],
        fotoURL: [''],
        userName: ['']
      },
      formOptions
    );
  }

  public getUsername() {
    this.spinnerService.show();

    this.usuarioService
      .getUsuarioByUserName()
      .subscribe(
        (usuario: UsuarioUpdate) => {
          this.usuario = usuario;
          this.formPerfil.patchValue(this.usuario);
          this.fotoURL = (this.usuario.fotoURL === null) ? "../../../../../assets/Images/not-available.png" : environment.fotoURL + this.usuario.fotoURL
          console.log(this.fotoURL);
        },
        (error: any) => {
          this.toastrService.error(
            "Falha ao recuperar usuário logado",
            "Erro!"
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
  get f(): any {
    return this.formPerfil.controls;
  }

  onSubmit(): void {
    // Vai parar aqui se o form estiver inválido
    if (this.formPerfil.invalid) {
      return;
    }

    this.updateUsuario();
  }

  public updateUsuario(): void {
    this.spinnerService.show();

    this.usuario = {
      id: this.usuario.id,
      userName: this.usuario.userName,
      ...this.formPerfil.value,
    };

    console.log("updateUsuairo ", this.usuario);
    this.usuarioService
      .updateUser(this.usuario)
      .subscribe(
        () => {
          this.toastrService.success(
            "Usuario atualizado com sucesso!",
            "Sucesso!"
          );
        },
        (error: any) => {
          this.toastrService.error("Falha ao atualizar usuário", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.formPerfil.reset();
  }

  public changePhoto(ev: any): void {
    const reader = new FileReader();

    reader.onload = (event: any) => (this.fotoUpload = event.target.result);

    this.file = ev.target.files;

    reader.readAsDataURL(this.file[0]);

    this.uploadPhoto();
  }

  private uploadPhoto(): void {
    this.spinnerService.show();
    console.log("aqui")
    this.uploadService
      .saveUserPhoto(this.file)
      .subscribe(
        () => {
          this.toastrService.success("Foto atualizada!", "Sucesso!"),
            this.getUsername();
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
