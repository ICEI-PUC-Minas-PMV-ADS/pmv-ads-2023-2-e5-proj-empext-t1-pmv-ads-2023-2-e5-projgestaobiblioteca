// eslint-disable-next-line @typescript-eslint/consistent-type-imports
import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { type Observable, take } from 'rxjs'
import { type Patrimonio } from 'src/app/models/Patrimonios/Patrimonio'
import { environment } from 'src/assets/environments/environments'

@Injectable({
  providedIn: 'root'
})
export class PatrimonioService {
  baseURL = environment.apiURL + 'Patrimonios'

  constructor (
    private readonly http: HttpClient
  ) { }

  public getPatrimonios (fisltrarPor?: string, TipoFiltro?: string): Observable<Patrimonio[]> {
    console.log(this.baseURL)
    return this.http.get<Patrimonio[]>(this.baseURL)
      .pipe(take(3))
  }
}
