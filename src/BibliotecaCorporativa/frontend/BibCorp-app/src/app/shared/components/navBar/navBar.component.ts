import { Component, OnInit } from "@angular/core";
import { NavigationEnd, Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { LoginService, Usuario, UsuarioService } from "src/app/usuarios";
import { environment } from "src/assets/environments/environments";

@Component({
  selector: "app-navBar",
  templateUrl: "./navBar.component.html",
  styleUrls: ["./navBar.component.scss"],
})
export class NavBarComponent implements OnInit {
  public isCollapsed = true;

  public usuarioLogado = false;
  public usuarioAdmin = false;

  public usuarioAtivo = {} as Usuario;

  public fotoURL = "";

  constructor(
    private router: Router,
    private loginService: LoginService,
    private usuarioService: UsuarioService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit() {
    console.log(this.usuarioLogado);
    this.getUsuario();
  }

  public getUsuario(): void {
    this.spinnerService.show();

    this.usuarioService.getUsuarioByUserName().subscribe(
      (usuarioAtivo: Usuario) => {
        this.usuarioAtivo = { ...usuarioAtivo };
        console.log(this.usuarioAtivo.userName);
        this.usuarioLogado = this.usuarioAtivo.userName ? true : false;
        this.fotoURL =
          this.usuarioAtivo.fotoURL === null
            ? "../../../../../assets/Images/not-available.png"
            : environment.fotoURL + this.usuarioAtivo.fotoURL;
        console.log(this.fotoURL);

        this.usuarioAdmin = this.usuarioAtivo.userName === "Admin";
        console.log(this.usuarioLogado, this.usuarioAdmin);
      },
      (error: any) => {
        if (error.status == 401) {
        } else {
          this.toastrService.error("Falha ao logar no sistema");
          console.error(error);
        }
      }
    );
  }

  public logout(): void {
    this.loginService.logout();
    this.router.navigateByUrl("usuarios/login");
  }
}
