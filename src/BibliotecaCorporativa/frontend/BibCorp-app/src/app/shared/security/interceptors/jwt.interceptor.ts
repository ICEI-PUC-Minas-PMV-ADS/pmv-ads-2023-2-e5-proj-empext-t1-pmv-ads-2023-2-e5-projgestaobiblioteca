import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, catchError, take, throwError } from "rxjs";
import { LoginService, Usuario } from "src/app/usuarios";


@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(
    private loginService: LoginService
  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    let userCurrent: Usuario;

    this.loginService.currentUser$
      .pipe(take(1))
      .subscribe (
        user => {
          userCurrent = user

          if (userCurrent) {
            request = request.clone({
              setHeaders: {
                Authorization: `Bearer ${userCurrent.token}`
              }
            });
          }
        }
      );

    return next.handle(request)
      .pipe(catchError(
        error => {
          if (error) {
//            localStorage.removeItem(Constants.LOCAL_STORAGE_NAME);
          }
          return throwError(error);
        }
      ));
  }
}
