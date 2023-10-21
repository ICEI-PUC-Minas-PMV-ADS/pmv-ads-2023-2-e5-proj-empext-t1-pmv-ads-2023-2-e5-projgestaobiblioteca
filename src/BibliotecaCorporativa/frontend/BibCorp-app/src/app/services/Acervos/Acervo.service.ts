import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Observable, take } from 'rxjs'
import { Acervo } from 'src/app/models/Acervos/Acervo'
import { environment } from 'src/assets/environments/environments'

@Injectable({
  providedIn: 'root'
})
export class AcervoService {
  baseURL = environment.apiURL + 'Acervos'

  constructor (
    private http: HttpClient
  ) { }

  public getAcervos (filtrarPor?: String, TipoFiltro?: String): Observable<Acervo[]> {
    console.log(this.baseURL)
    return this.http.get<Acervo[]>(this.baseURL)
               .pipe(take(3));
  }
}
