import { Component } from '@angular/core'
import { Router } from '@angular/router';
import { NgbConfig } from '@ng-bootstrap/ng-bootstrap'
import { Constants } from './util';
import { LoginService, Usuario } from './usuarios';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor (
    private loginService: LoginService,
    private router: Router
  ) {}

  ngOnInit (): void {
    this.setCurrentUser();
  }

  showDrawer():boolean{
    return this.router.url != '/usuarios/login' && this.router.url != '/usuarios/cadastro';

  }

  public setCurrentUser(): void {
    let usuario = {} as Usuario;

    if (localStorage.getItem(Constants.LOCAL_STORAGE_NAME))
    usuario = JSON.parse(localStorage.getItem(Constants.LOCAL_STORAGE_NAME) ?? '{}');

    if (usuario)
      this.loginService.setCurrentUser(usuario);
  }
}
