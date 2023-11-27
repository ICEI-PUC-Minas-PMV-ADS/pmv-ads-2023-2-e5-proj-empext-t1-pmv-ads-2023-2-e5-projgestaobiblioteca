import { Component, Input, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { LoginService, UsuarioLogin } from 'src/app/usuarios';




@Component({
  selector: 'app-titlebar',
  templateUrl: './titlebar.component.html',
  styleUrls: ['./titlebar.component.scss']
})
export class TitlebarComponent implements OnInit {

  @Input() title: string | undefined;

  public usuarioLogado = false;

  public usuarioAtivo = {} as UsuarioLogin;


  constructor(
    public loginService: LoginService,
    private router: Router,
    public spinnerService: NgxSpinnerService,
    public toastrService: ToastrService,
    ) {
    router.events
    .subscribe(
      (verifyUser) => {
        if (verifyUser instanceof NavigationEnd)
          this.loginService.currentUser$
            .subscribe(
              (userActive) => {
                this.usuarioLogado = userActive !== null;
                this.usuarioAtivo = { ...userActive};
              }
            )
      }
    )
   }

  ngOnInit() {
    this.usuarioLogado = this.usuarioAtivo !== null;
  }

  public listNavigate(): void {
    this.router.navigate([`/${this.title?.toLocaleLowerCase()}/list`])
  }

  public showCabecalho(): boolean {
    return this.router.url != '/usuarios/login' && this.router.url != '/usuarios/cadastro' && this.usuarioLogado
  }

}
