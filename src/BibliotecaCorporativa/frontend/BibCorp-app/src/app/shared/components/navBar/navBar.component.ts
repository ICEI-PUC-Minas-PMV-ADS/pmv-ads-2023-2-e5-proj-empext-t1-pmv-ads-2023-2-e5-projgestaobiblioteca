import { ToastrService } from "ngx-toastr";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { Usuario } from "src/app/models";
import { LoginService, UsuarioService } from "src/app/services";
import { UsuarioUpdate } from "src/app/models/Usuarios/UsuarioUpdate";

@Component({
  selector: "app-navBar",
  templateUrl: "./navBar.component.html",
  styleUrls: ["./navBar.component.scss"],
})
export class NavBarComponent implements OnInit {
  public isCollapsed = true;

  public showItensAdmin = false;

  constructor(
    private router: Router,
    private loginService: LoginService,
    private spinnerService: NgxSpinnerService,
    private usuarioService: UsuarioService,
    private toastrService: ToastrService
  ) {}

  ngOnInit() {
    this.getUserName();
  }

  public getUserName(): void {
    this.spinnerService.show();

    this.usuarioService
      .getUsuarioByUserName()
      .subscribe(
        (usuarioLogado: UsuarioUpdate) => {
          if (usuarioLogado.userName == "Admin") this.showItensAdmin = true;
          else this.showItensAdmin = false;

          console.log("Admin pode ver? ", this.showItensAdmin);
        },
        (error: any) => {
          this.toastrService.error(
            "Falha ao recuperar usuário logado.",
            "Erro"
          );
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public logout(): void {
    this.loginService.logout();
    this.router.navigateByUrl("usuarios/login");
  }
}
