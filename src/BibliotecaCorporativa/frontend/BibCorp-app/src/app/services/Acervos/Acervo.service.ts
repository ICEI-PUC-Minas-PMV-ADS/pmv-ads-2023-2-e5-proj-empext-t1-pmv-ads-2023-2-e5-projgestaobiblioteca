import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core'
import { Observable, map, take } from 'rxjs'
import { Acervo } from 'src/app/models/Acervos/Acervo'
import { ResultadoPaginado } from 'src/app/util'
import { environment } from 'src/assets/environments/environments'

@Injectable({
  providedIn: 'root'
})
export class AcervoService {
  baseURL = environment.apiURL + 'Acervo'

  constructor (
    private http: HttpClient
  ) { }

  public getAcervos (filtrarPor?: String, TipoFiltro?: String): Observable<Acervo[]> {
    console.log(this.baseURL)
    return this.http.get<Acervo[]>(this.baseURL)
               .pipe(take(3));
  }

  public getAcervoById (id: number): Observable<Acervo> {
    console.log(this.baseURL)
    return this.http.get<Acervo>(`${this.baseURL}/${id}`)
               .pipe(take(3));
  }

  public updateAcervo (id: number, acervo: Acervo): Observable<Acervo> {
    console.log(this.baseURL)
    return this.http.put<Acervo>(`${this.baseURL}/${id}`, acervo)
               .pipe(take(3));
  }

  public getAcervosRecentes (pagina?: number, itensPorPagina?: number, argumento?: string, pesquisarPor: string = 'Todos', genero: string = 'Todos'): Observable<ResultadoPaginado<Acervo[]>> {
    console.log(this.baseURL)
    const resultadoPaginado: ResultadoPaginado<Acervo[]> = new ResultadoPaginado<Acervo[]>()

    let parametrosHttp = new HttpParams;

    if (pagina != null && itensPorPagina != null) {
      parametrosHttp = parametrosHttp.append("numeroDaPagina", pagina.toString())
      parametrosHttp = parametrosHttp.append("tamanhoDaPagina", itensPorPagina.toString())
      parametrosHttp = parametrosHttp.append("pesquisarPor", pesquisarPor)
      parametrosHttp = parametrosHttp.append("genero", genero)
    }

    if (argumento != null && argumento != '')
      parametrosHttp = parametrosHttp.append("argumento", argumento)

    return this.http
      .get<Acervo[]>( `${this.baseURL}/Recentes`, { observe: "response", params: parametrosHttp } )
      .pipe(  
        take(3),  
        map((response: any) => {
          resultadoPaginado.resultado = response.body

          if (response.headers.has('Paginacao')) {
            resultadoPaginado.paginacao = JSON.parse(response.headers.get('Paginacao'))
          }

          return resultadoPaginado
        }));
  }
}
