import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { type Observable, take } from 'rxjs'
import { type Emprestimo } from 'src/app/models/Emprestimos/Emprestimo'
import { environment } from 'src/assets/environments/environments'

@Injectable({
  providedIn: 'root'
})
export class EmprestimoService {
  baseURL = environment.apiURL + 'Emprestimos/'

  constructor (
    private readonly http: HttpClient
  ) { }

  public getEmprestimos (filtrarPor?: string, TipoFiltro?: string): Observable<Emprestimo[]> {
    console.log(this.baseURL)
    return this.http.get<Emprestimo[]>(this.baseURL)
      .pipe(take(3))
  }

  public getEmprestimoById (id: number): Observable<Emprestimo> {
    console.log(this.baseURL)
    return this.http.get<Emprestimo>(`${this.baseURL}${id}`)
               .pipe(take(3));
  }

  public createEmprestimo(emprestimo: Emprestimo): Observable<Emprestimo> {
    return this.http.post<Emprestimo>(this.baseURL, emprestimo)
    .pipe(take(3));
  }

  public saveEmprestimo (emprestimo: Emprestimo): Observable<Emprestimo> {
    console.log(this.baseURL)
    return this.http.put<Emprestimo>(`${this.baseURL}${emprestimo.Id}`, emprestimo)
               .pipe(take(3));
  }

  public deleteEmprestimo(emprestimoId:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${emprestimoId}?acervo=${emprestimoId}`)
    .pipe(take(3));
  }

}
