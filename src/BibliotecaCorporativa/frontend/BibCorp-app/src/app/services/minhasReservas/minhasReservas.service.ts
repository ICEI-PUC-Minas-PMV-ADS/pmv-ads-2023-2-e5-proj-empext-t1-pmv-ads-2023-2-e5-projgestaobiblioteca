/* eslint-disable */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Patrimonio } from 'src/app/models/Patrimonios/Patrimonio';
import { Acervo } from 'src/app/models/Acervos/Acervo';
import { Emprestimo } from 'src/app/models/Emprestimos';

@Injectable({
  providedIn: 'root'
})
export class MinhasReservasService {

  // baseURL = 'http://localhost:5283/api/Acervo';
  baseURL = 'http://localhost:5283/api/Emprestimos/';

  constructor(private http: HttpClient) { }

  // getPatrimonio(): Observable<Acervo[]> {
  //   return this.http.get<Acervo[]>(this.baseURL).pipe(take(3));
  // }

  // getPatrimoniosByTitulo(isbn: string): Observable<Acervo[]> {
  //   return this.http.get<Acervo[]>(`${this.baseURL}/${isbn}/isbn`);
  // }

  // getPatrimonioById(id: number): Observable<Acervo> {
  //   return this.http.get<Acervo>(`${this.baseURL}/${id}`);
  // }

  getEmprestimo(): Observable<Emprestimo[]> {
    return this.http.get<Emprestimo[]>(this.baseURL);
  }

  getEmprestimoById(id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(`${this.baseURL}${id}`);
  }

  public novoEmprestimo(emprestimo: Emprestimo): Observable<Emprestimo> {
    return this.http.post<Emprestimo>(this.baseURL, emprestimo);
  }

}
