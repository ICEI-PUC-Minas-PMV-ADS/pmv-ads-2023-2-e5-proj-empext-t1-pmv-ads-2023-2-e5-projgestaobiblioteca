import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, take, map } from "rxjs";

import { environment } from "src/assets/environments/environments";

import { Usuario } from "src/app/models";

import { LoginService } from "../Login";



@Injectable({
  providedIn: "root",
})
export class UsuarioService {
  public baseURL = environment.apiURL + "Usuarios/";

  public userLoged = {} as Usuario;

  constructor(private http: HttpClient, private loginService: LoginService) {}

  public createUser(model: any): Observable<void> {
    return this.http.post<Usuario>(this.baseURL + "CreateUsuario", model).pipe(
      take(1),
      map((response: Usuario) => {
        const user = response;
        if (user) this.loginService.setCurrentUser(user);
      })
    );
  }

  public getUsuarioByUserName(): Observable<Usuario> {
    return this.http
      .get<Usuario>(this.baseURL + "getusername")
      .pipe(take(1));
  }

  public getUsuarioById(usuarioId: number): Observable<Usuario> {
    return this.http
      .get<Usuario>(`${this.baseURL}GetUsuario/${usuarioId}`)
      .pipe(take(1));
  }

  public updateUser(model: Usuario): Observable<void> {
    return this.http
      .put<Usuario>(this.baseURL + 'UpdateUsuario', model)
      .pipe(take(1),
        map((user: Usuario) => {
          this.loginService.setCurrentUser(user);
        })
      );
  }
}
