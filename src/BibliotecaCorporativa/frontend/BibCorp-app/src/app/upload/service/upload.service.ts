import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Usuario } from 'src/app/usuarios';
import { environment } from 'src/assets/environments/environments';

@Injectable()
export class UploadService {

  baseURL = environment.apiURL + 'Uploads/'

  constructor(private http: HttpClient) { }

  public saveUserPhoto(file: File[]): Observable<Usuario> {
    console.log(this.baseURL)
    const fileUpload = file[0] as File;
    const formData = new FormData();

    formData. append('file', fileUpload);

    return this.http
    .post<Usuario>(`${this.baseURL}upload-user-photo`, formData)
    .pipe(take(1));
  }
}
