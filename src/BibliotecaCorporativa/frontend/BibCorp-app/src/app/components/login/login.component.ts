import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { UsuarioLogin } from 'src/app/models/Usuarios';

import { LoginService } from 'src/app/services/Usuarios/Login';
import { FormValidator } from 'src/app/util/class/validators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

  model = {} as UsuarioLogin;
  
  constructor(private loginService: LoginService,
              private router: Router,
              private toaster: ToastrService
              
    ){}


  form: FormGroup;
 
  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{
    this.form = new FormGroup({
      userName: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(8)])
    })
  }

  public login(): void{
    this.loginService.login(this.model).subscribe(
      () => {this.router.navigateByUrl('/principal')},
      (error: any) => {
        if (error.status == 401)
        this.toaster.error('Usuário ou senha inválidos');
      else console.error(error);
      }
    )
  }


}

