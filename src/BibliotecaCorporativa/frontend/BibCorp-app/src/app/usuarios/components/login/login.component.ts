import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { LoginService, UsuarioLogin } from "src/app/usuarios";
import { FormValidator } from "src/app/util";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  formLogin: FormGroup;

  model = {} as UsuarioLogin;

  public get ctrF(): any {
    return this.formLogin.controls;
  }

  constructor(
    private loginService: LoginService,
    private router: Router,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService
  ) {}

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void {
    this.formLogin = new FormGroup({
      userName: new FormControl("", [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(20),
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
    this.formLogin.reset();
  }

  public login(): void {
    this.spinnerService.show();

    this.model = { ...this.formLogin.value };

    this.loginService
      .login(this.model)
      .subscribe(
        () => {
          if(this.model.userName == "Admin"){
            this.router.navigateByUrl("/home-admin");
            location.replace("/home-admin");
          } else{
            this.router.navigateByUrl("/principal");
            location.replace("/principal");
          }
          
        },
        (error: any) => {
          if (error.status == 401)
            this.toastrService.error("Usuário ou senha inválidos");
          else {
            this.toastrService.error("Falha ao logar no sistema");
            console.error(error);
          }
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public reloadPrincipal(): void {
    this.router.navigateByUrl("/principal");
    location.replace("/princial");
  }

}
