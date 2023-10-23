import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

import { UsuarioLogin } from 'src/app/models/Usuarios';

import { LoginService } from 'src/app/services/Login';
import { FormValidator } from 'src/app/util/class/validators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit{

  form: FormGroup;
  constructor(){}

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{
    this.form = new FormGroup({
      userName: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(20)]),
      password: new FormControl('', [Validators.required, Validators.minLength(6), Validators.maxLength(8)])
    })
  }

 

}

