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
  
  private currentUserSource = new ReplaySubject<Usuario>(1);
  public currentUser$ = this.currentUserSource.asObservable();
  
  baseURL = environment.apiURL + 'Usuarios/'

  constructor(private http: HttpClient) { }

  public login(model: any): Observable<void>{
    return this.http.post<Usuario>(this.baseURL + 'login', model).pipe(
      take(1),
      map((response: Usuario) => {
        const usuario = response;
        if(usuario){
            this.setCurrentUser(usuario)
        }
      })
    );
  }

  public setCurrentUser(usuario: Usuario): void{
    localStorage.setItem('usuario', JSON.stringify(usuario));
    this.currentUserSource.next(usuario);
  }

  public logout(): void{
    localStorage.removeItem('usuario');
    this.currentUserSource.next(null as any);
    this.currentUserSource.complete();
  }
 
}