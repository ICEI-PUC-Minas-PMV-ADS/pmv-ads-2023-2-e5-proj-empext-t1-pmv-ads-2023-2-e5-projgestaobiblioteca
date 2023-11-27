import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, take, map } from "rxjs";
import { ResultadoPaginado } from "src/app/shared";
import { environment } from "src/assets/environments/environments";
import { Patrimonio } from "../..";

@Injectable()
export class PatrimonioService {
  baseURL = environment.apiURL + "Patrimonios/";

  constructor(private readonly http: HttpClient) {}

  public getPatrimonios(): Observable<Patrimonio[]> {
    console.log(this.baseURL);
    return this.http.get<Patrimonio[]>(this.baseURL).pipe(take(3));
  }

  public getPatrimoniosByISBN(isbn: string): Observable<Patrimonio[]> {
    return this.http
      .get<Patrimonio[]>(`${this.baseURL}${isbn}/ISBN`)
      .pipe(take(3));
  }

  public getPatrimoniosLivres(isbn: string): Observable<Patrimonio[]> {
    return this.http
      .get<Patrimonio[]>(`${this.baseURL}Livres/${isbn}`)
      .pipe(take(3));
  }

  public getPatrimonioById(patrimonioId: number): Observable<Patrimonio> {
    return this.http
      .get<Patrimonio>(`${this.baseURL}${patrimonioId}`)
      .pipe(take(3));
  }

  public createPatrimonio(patrimonio: Patrimonio): Observable<Patrimonio> {
    return this.http.post<Patrimonio>(this.baseURL, patrimonio).pipe(take(3));
  }

  public savePatrimonio(patrimonio: Patrimonio): Observable<Patrimonio> {
    return this.http
      .put<Patrimonio>(`${this.baseURL}${patrimonio.id}`, patrimonio)
      .pipe(take(3));
  }

  public getPatrimoniosPaginacao(
    pagina?: number,
    itensPorPagina?: number,
    argumento?: string,
    pesquisarPor: string = "Todos",
    genero: string = "Todos"
  ): Observable<ResultadoPaginado<Patrimonio[]>> {
    console.log(this.baseURL);
    const resultadoPaginado: ResultadoPaginado<Patrimonio[]> =
      new ResultadoPaginado<Patrimonio[]>();

    let parametrosHttp = new HttpParams();

    if (pagina != null && itensPorPagina != null) {
      parametrosHttp = parametrosHttp.append(
        "numeroDaPagina",
        pagina.toString()
      );
      parametrosHttp = parametrosHttp.append(
        "tamanhoDaPagina",
        itensPorPagina.toString()
      );
      parametrosHttp = parametrosHttp.append("pesquisarPor", pesquisarPor);
      parametrosHttp = parametrosHttp.append("genero", genero);
    }

    if (argumento != null && argumento != "") {
      parametrosHttp = parametrosHttp.append("argumento", argumento);
    }

    return this.http
      .get<Patrimonio[]>(`${this.baseURL}Paginacao`, {
        observe: "response",
        params: parametrosHttp,
      })
      .pipe(
        take(3),
        map((response: any) => {
          resultadoPaginado.resultado = response.body;
          if (response.headers.has("Paginacao")) {
            resultadoPaginado.paginacao = JSON.parse(
              response.headers.get("Paginacao")
            );
          }

          return resultadoPaginado;
        })
      );
  }

  public deletePatrimonio(patrimonioId: number): Observable<any> {
    return this.http
      .delete(`${this.baseURL}${patrimonioId}?patrimonio=${patrimonioId}`)
      .pipe(take(3));
  }
}
