import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { environment } from 'src/assets/environments/environments';
import { Emprestimo } from '../..';
import { GerenciamentoEmprestimo } from '../../models/emprestimo/GerenciamentoEmprestimo';

@Injectable()
export class EmprestimoService {

  baseURL = environment.apiURL + 'Emprestimos/'

  constructor (
    private readonly http: HttpClient
  ) { }


  public getEmprestimos (filtrarPor?: string, TipoFiltro?: string): Observable<Emprestimo[]> {
    return this.http.get<Emprestimo[]>(this.baseURL)
      .pipe(take(3))
  }

  public getEmprestimoById (id: number): Observable<Emprestimo> {
    return this.http.get<Emprestimo>(`${this.baseURL}${id}`)
      .pipe(take(3));
  }

  public getEmprestimosByUserName (userName: string): Observable<Emprestimo[]> {
    return this.http.get<Emprestimo[]>(`${this.baseURL}Users/${userName}`)
      .pipe(take(3));
  }

  public createEmprestimo(emprestimo: Emprestimo): Observable<Emprestimo> {
    return this.http.post<Emprestimo>(this.baseURL, emprestimo)
    .pipe(take(3));
  }

  public saveEmprestimo (emprestimo: Emprestimo): Observable<Emprestimo> {
    return this.http.put<Emprestimo>(`${this.baseURL}${emprestimo.id}`, emprestimo)
               .pipe(take(3));
  }

  public deleteEmprestimo(emprestimoId:number): Observable<any> {
    return this.http.delete(`${this.baseURL}${emprestimoId}?emprestimo=${emprestimoId}`)
    .pipe(take(3));
  }

  public renovarEmprestimo (id: number): Observable<Emprestimo> {
    return this.http.patch<Emprestimo>(`${this.baseURL}${id}/Renovacao`,null)
    .pipe(take(1));
}

public alterarLocalDeColeta (emprestimoId:number, novoLocalColeta: string ): Observable<Emprestimo> {
  return this.http.patch<Emprestimo>(`${this.baseURL}${emprestimoId}/${novoLocalColeta}/AlteraLocalDeColeta`,null)
  .pipe(take(1));
}

public getEmprestimosPendentes (): Observable<Emprestimo[]> {

  return this.http.get<Emprestimo[]>(`${this.baseURL}Status?status=Reservado&status=Emprestado&status=Renovado`)
    .pipe(take(3))
}

public gerenciarEmprestimo(emprestimoId:number, gerenciamentoEmprestimo: GerenciamentoEmprestimo): Observable<Emprestimo> {
  return this.http.patch<Emprestimo>(`${this.baseURL}${emprestimoId}/GerenciamentoEmprestimo`, gerenciamentoEmprestimo)
  .pipe(take(3));
}
}
