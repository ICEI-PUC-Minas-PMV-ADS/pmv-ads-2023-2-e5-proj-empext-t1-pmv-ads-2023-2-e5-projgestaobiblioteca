import { Component, OnInit } from '@angular/core'
import { NavigationEnd, Router } from '@angular/router'
import { LoginService, Usuario } from 'src/app/usuarios';

@Component({
  selector: 'app-navBar',
  templateUrl: './navBar.component.html',
  styleUrls: ['./navBar.component.scss']
})
export class NavBarComponent implements OnInit {
  public isCollapsed = true

  public usuarioLogado = false;
  public usuarioAdmin = false;

  public usuarioAtivo = {} as Usuario;

  constructor(
    private router: Router,
    private loginService: LoginService,
    ) {
      router.events
      .subscribe(
        (verifyUser) => {
          if (verifyUser instanceof NavigationEnd)
            this.loginService.currentUser$
              .subscribe(
                (userActive) => {
                  this.usuarioAtivo = { ...userActive};
                  console.log(this.usuarioAtivo.userName)
                  this.usuarioLogado = this.usuarioAtivo.userName ? true : false

                  this.usuarioAdmin = (this.usuarioAtivo.userName === "Admin")
                  console.log(this.usuarioLogado, this.usuarioAdmin)
                }
              )
        }
      )
    }

  ngOnInit() { console.log(this.usuarioLogado) }

  public logout(): void{
    this.loginService.logout();
    this.router.navigateByUrl('usuarios/login');

  }

}
