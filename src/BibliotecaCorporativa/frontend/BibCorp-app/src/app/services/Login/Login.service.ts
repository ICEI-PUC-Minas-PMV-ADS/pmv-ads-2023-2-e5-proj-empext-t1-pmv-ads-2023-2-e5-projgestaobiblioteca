import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable, take, map, ReplaySubject  } from 'rxjs'
import { Usuario } from 'src/app/models/Usuarios/Usuario'
import { environment } from 'src/assets/environments/environments'
import { Constants } from 'src/app/util/constants';

@Injectable({
    providedIn: 'root'
  })

export class LoginService{
  baseURL = environment.apiURL + 'Usuarios/'

  public userNull = {} as Usuario

  private rootCurrentUser = new ReplaySubject<Usuario>(1);
  public currentUser$ = this.rootCurrentUser.asObservable();

  constructor(private http: HttpClient) { }

  public logout(): void {
    localStorage.removeItem(Constants.LOCAL_STORAGE_NAME);
    this.rootCurrentUser.next(this.userNull);
    this.rootCurrentUser.complete();
  }

  public login(login: any): Observable<void> {
    return this.http
      .post<Usuario>(this.baseURL + "Login", login)
      .pipe(take(1),
        map((userLoged: Usuario) => {
        const user = userLoged;
        if (user)
          this.setCurrentUser(user);
      })
    );
  }

  public setCurrentUser(user: Usuario): void {
    localStorage.setItem(Constants.LOCAL_STORAGE_NAME, JSON.stringify(user));
    this.rootCurrentUser.next(user);
  }
}