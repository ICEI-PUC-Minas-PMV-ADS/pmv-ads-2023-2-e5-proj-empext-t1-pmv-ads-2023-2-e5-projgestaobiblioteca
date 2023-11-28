import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject, Observable, take, map } from 'rxjs';
import { Constants } from 'src/app/util';
import { environment } from 'src/assets/environments/environments';
import { Usuario } from '../..';

@Injectable()
export class LoginService {
  public baseURL = environment.apiURL + "Usuarios/";

  private currentUserSource = new ReplaySubject<Usuario>(1);
  public currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  public login(model: any): Observable<void> {
    console.log(model);
    return this.http.post<Usuario>(this.baseURL + "Login", model).pipe(
      take(1),
      map((response: Usuario) => {
        const usuario = response;
        if (usuario) {
          this.setCurrentUser(usuario);
        }
      })
    );
  }

  public setCurrentUser(usuario: Usuario): void {
    localStorage.setItem(Constants.LOCAL_STORAGE_NAME, JSON.stringify(usuario));
    this.currentUserSource.next(usuario);
  }

  public logout(): void {
    localStorage.removeItem(Constants.LOCAL_STORAGE_NAME);
    this.currentUserSource.next(null as any);
    this.currentUserSource.complete();
  }

  public userLoged(usuario: Usuario): void {
    localStorage.setItem(Constants.LOCAL_STORAGE_NAME, JSON.stringify(usuario));
    this.currentUserSource.next(usuario);
  }
}
