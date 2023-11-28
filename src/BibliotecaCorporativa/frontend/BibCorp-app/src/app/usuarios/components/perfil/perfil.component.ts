import { Component, OnInit } from "@angular/core";
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { FormValidator } from "src/app/util";

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {
  
  public formPerfil: FormGroup;
  
  public get ctrF(): any {
    return this.formPerfil.controls;
  }

  constructor(
    private formBuilder: FormBuilder
    ) {}



  ngOnInit(): void {
    this.validation();
  }

  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: FormValidator.argsCompare('password', 'confirmPassword')
    };

    this.formPerfil = this.formBuilder.group({
      nome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required]],
      localizacao: ['', Validators.required],
      funcao: ['', Validators.required],
      password: ['', [Validators.minLength(6), Validators.nullValidator]],
      confirmPassword: ['', Validators.nullValidator]
    }, formOptions);
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

    // Vai parar aqui se o form estiver inválido
    if (this.formPerfil.invalid) {
      return;
    }
  }

  public resetForm(event: any): void {
    event.preventDefault();
    this.formPerfil.reset();
  }

}
