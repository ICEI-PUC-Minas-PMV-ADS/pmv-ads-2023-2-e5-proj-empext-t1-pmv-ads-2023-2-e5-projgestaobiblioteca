/* eslint-disable */
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Patrimonio } from 'src/app/models/Patrimonios/Patrimonio';
// import { Acervo } from 'src/app/models';
import { Acervo } from 'src/app/models/Acervos/Acervo';

@Injectable({
  providedIn: 'root'
})
export class MinhasReservasService {

  baseURL = 'http://localhost:5283/api/Acervos';

  constructor(private http: HttpClient) { }

  getPatrimonio(): Observable<Acervo[]> {
    return this.http.get<Acervo[]>(this.baseURL).pipe(take(3));
  }

  getPatrimoniosByTitulo(isbn: string): Observable<Acervo[]> {
    return this.http.get<Acervo[]>(`${this.baseURL}/${isbn}/isbn`);
  }

  getPatrimonioById(id: number): Observable<Acervo> {
    return this.http.get<Acervo>(`${this.baseURL}/${id}`);
  }
}
