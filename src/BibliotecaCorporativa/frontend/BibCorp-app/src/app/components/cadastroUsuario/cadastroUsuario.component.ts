import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastroUsuario',
  templateUrl: './cadastroUsuario.component.html',
  styleUrls: ['./cadastroUsuario.component.scss']
})
export class CadastroUsuarioComponent implements OnInit{

  form: FormGroup;
  constructor(){}

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{
    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(150)]),
      userName: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(8)]),
      telefone: new FormControl('', [Validators.required, Validators.minLength(11), Validators.maxLength(11)])
    })
  }

}
