// eslint-disable-next-line @typescript-eslint/consistent-type-imports
import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { type Observable, take } from 'rxjs'
import { type Livro } from 'src/app/models/Livros/Livro'
import { environment } from 'src/assets/environments/environments'

@Injectable({
  providedIn: 'root'
})
export class LivroService {
  baseURL = environment.apiURL + 'Livros'

  constructor (
    private readonly http: HttpClient
  ) { }

  public getLivros (fisltrarPor?: string, TipoFiltro?: string): Observable<Livro[]> {
    console.log(this.baseURL)
    return this.http.get<Livro[]>(this.baseURL)
      .pipe(take(3))
  }
}
