import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuario } from 'src/app/models';
import { CadastroUsuarioService } from 'src/app/services/Usuarios/CadastroUsuario';

@Component({
  selector: 'app-cadastroUsuario',
  templateUrl: './cadastroUsuario.component.html',
  styleUrls: ['./cadastroUsuario.component.scss']
})
export class CadastroUsuarioComponent implements OnInit{

  usuario = {} as Usuario;
  model = {} as Usuario;

  constructor(private cadastroUsuarioService: CadastroUsuarioService,
              private router: Router,
              private toaster: ToastrService
    ){}

  form: FormGroup;
  
  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{
    this.form = new FormGroup({
      nome: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(150)]),
      userName: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]),
      telefone: new FormControl('', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(8)])
      
    })
  }

  public register(): void{
    this.usuario = { ...this.form.value};
    this.cadastroUsuarioService.createUser(this.usuario).subscribe(
      () => this.router.navigateByUrl('/principal'),
      (error: any) => this.toaster.error('Ocorreu um erro ao tentar cadastrar o usuário')
      )

  }

}
