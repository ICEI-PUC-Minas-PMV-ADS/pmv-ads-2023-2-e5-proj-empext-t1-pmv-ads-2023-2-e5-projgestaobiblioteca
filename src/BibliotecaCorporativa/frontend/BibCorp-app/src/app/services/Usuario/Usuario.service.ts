import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable, take, map } from 'rxjs'
import { Usuario } from 'src/app/models/Usuarios/Usuario'
import { environment } from 'src/assets/environments/environments'
import { LoginService } from '../Login/Login.service'

@Injectable({
    providedIn: 'root'
  })

export class UsuarioService{
  public baseURL = environment.apiURL + 'Usuarios';

  public userLoged  = {} as Usuario;

  constructor(
    private http: HttpClient,
    private loginService: LoginService
  ) { }

  public createUser(model: any): Observable<void> {
    return this.http
      .post<Usuario>(this.baseURL + "CreateUsuario", model)
      .pipe(take(1),
        map((userReturn: Usuario) => {
          const user = userReturn;
          if (user)
            this.loginService.setCurrentUser(user)
        })
      );
  }  





}