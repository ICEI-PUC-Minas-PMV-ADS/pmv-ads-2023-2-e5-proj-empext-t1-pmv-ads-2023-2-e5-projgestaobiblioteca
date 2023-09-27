import { Patrimonio } from './../models/Patrimonio';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PatrimonioService {

  baseURL = 'https://localhost:5001/api/patrimonios';

constructor(private http: HttpClient) { }

getPatrimonio(): Observable<Patrimonio[]> {
  return this.http.get<Patrimonio[]>(this.baseURL);
}

getPatrimoniosByTitulo(titulo: string): Observable<Patrimonio[]> {
  return this.http.get<Patrimonio[]>(`${this.baseURL}/${titulo}/titulo`);
}

getPatrimonioById(id: number): Observable<Patrimonio> {
  return this.http.get<Patrimonio>(`${this.baseURL}/${id}`);
}

}
