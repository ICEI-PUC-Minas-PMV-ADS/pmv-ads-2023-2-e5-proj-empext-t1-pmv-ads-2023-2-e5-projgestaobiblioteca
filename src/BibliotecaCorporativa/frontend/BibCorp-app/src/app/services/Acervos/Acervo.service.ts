// eslint-disable-next-line @typescript-eslint/consistent-type-imports
import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { type Observable, take } from 'rxjs'
import { type Acervo } from 'src/app/models/Acervos/Acervo'
import { environment } from 'src/assets/environments/environments'

@Injectable({
  providedIn: 'root'
})
export class AcervoService {
  baseURL = environment.apiURL + 'Acervos'

  constructor (
    private readonly http: HttpClient
  ) { }

  public getAcervos (fisltrarPor?: string, TipoFiltro?: string): Observable<Acervo[]> {
    console.log(this.baseURL)
    return this.http.get<Acervo[]>(this.baseURL)
      .pipe(take(3))
  }
}
