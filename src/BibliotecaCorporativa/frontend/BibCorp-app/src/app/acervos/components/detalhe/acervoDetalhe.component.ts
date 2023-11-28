import { Component, OnInit } from "@angular/core";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { ActivatedRoute } from "@angular/router";
import { MatDialog } from "@angular/material/dialog";
import {
  Acervo,
  AcervoService,
  ModalEmprestarComponent,
} from "src/app/acervos";
import { Usuario, UsuarioService } from "src/app/usuarios";

@Component({
  selector: "app-acervoDetalhe",
  templateUrl: "./acervoDetalhe.component.html",
  styleUrls: ["./acervoDetalhe.component.scss"],
})
export class AcervoDetalheComponent implements OnInit {
  public acervo: Acervo;
  public acervoParam: any = "";
  public comentarios: string;

  public usuarioLogado = false;
  public disabledReservar = false;

  public usuarioAtivo: Usuario;

  constructor(
    private activevateRouter: ActivatedRoute,
    private acervoService: AcervoService,
    private toastrService: ToastrService,
    private spinnerService: NgxSpinnerService,
    private dialogRef: MatDialog,
    private usuarioService: UsuarioService
  ) {}

  abrirDialog(patrimonioId: number) {
    this.dialogRef.open(ModalEmprestarComponent, {
      data: {
        patrimonioId: patrimonioId,
        acervoId: this.acervo.id,
        id: "Emprestar",
      },
    });
  }

  public ngOnInit(): void {
    this.getUserAtivo();

    this.acervoParam = this.activevateRouter.snapshot.paramMap.get("id");
    this.getAcervoById();
  }

  public getUserAtivo(): void {
    this.spinnerService.show();

    this.usuarioService
      .getUsuarioByUserName()
      .subscribe(
        (usuarioAtivo: Usuario) => {
          this.usuarioAtivo = usuarioAtivo;
          this.usuarioLogado = true;
        },
        (error: any) => {
          if (error.status == 401) this.usuarioLogado = false;
          else
            this.toastrService.error("Falha ao recuperar usuario no sistema");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public getAcervoById(): void {
    this.spinnerService.show();

    this.acervoService
      .getAcervoById(+this.acervoParam)
      .subscribe(
        (retorno: Acervo) => {
          this.acervo = retorno;
          console.log(this.acervo);
        },
        (error: any) => {
          this.toastrService.error("Erro ao carregar Acervo", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public salvarAcervo(): void {
    this.spinnerService.show();

    this.acervo.comentarios = this.comentarios;
    this.acervoService
      .saveAcervo(this.acervo)
      .subscribe(
        (retorno: Acervo) => {
          this.acervo = retorno;
          console.log(this.acervo);
          this.toastrService.success(
            "Comentário incluído para o acervo!",
            "Salvo!"
          );
        },
        (error: any) => {
          this.toastrService.error("Erro ao salvar acervo", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public obterStatusPatrimonio(status: boolean): any {
    if (!this.usuarioLogado)
      this.disabledReservar = true;
    else if (this.usuarioAtivo.userName === "Admin")
      this.disabledReservar = true;
    else if (status)
      this.disabledReservar = true;
    else this.disabledReservar = false;

    if (status === true) {
      return "Indisponível";
    } else if (status === false) {
      return "Disponível";
    }
  }
}
