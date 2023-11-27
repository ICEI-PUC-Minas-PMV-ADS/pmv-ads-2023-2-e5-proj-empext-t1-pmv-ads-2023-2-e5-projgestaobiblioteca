import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { LoginService, Usuario, UsuarioService } from 'src/app/usuarios';

@Component({
  selector: 'app-navBar',
  templateUrl: './navBar.component.html',
  styleUrls: ['./navBar.component.scss']
})
export class NavBarComponent implements OnInit {
  public isCollapsed = true
  public usuarioAtivo = {} as Usuario;

  constructor(
    private router: Router,
    private loginService: LoginService,
    public usuarioService: UsuarioService,
    ) { }

  ngOnInit() {
    this.getUsuarioAtivo();
  }

  public logout(): void{
    this.loginService.logout();
    this.router.navigateByUrl('usuarios/login');

  }

  public getUsuarioAtivo(): void{
      this.usuarioService.getUsuarioByUserName().subscribe(
        (usuario: Usuario) => {
          this.usuarioAtivo = usuario
        },
        (error: any) => {
          console.error(error)
        }
      )
  }
}
