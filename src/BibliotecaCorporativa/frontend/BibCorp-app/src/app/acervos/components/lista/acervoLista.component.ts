import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { Router } from "@angular/router";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Acervo, AcervoService } from "src/app/acervos";

import { DeleteModalComponent, Paginacao, ResultadoPaginado } from "src/app/shared";
import { Usuario, UsuarioService } from "src/app/usuarios";


@Component({
  selector: "app-acervoLista",
  templateUrl: "./acervoLista.component.html",
  styleUrls: ["./acervoLista.component.scss"],
})
export class AcervoListaComponent implements OnInit {
  public acervos: Acervo[] = [];
  public acervo: Acervo;

  public paginacao = {} as Paginacao;

  public acervoId = 0;
  public acervoISBN = "";
  public acervoAlocado = false;

  public opcaoPesquisa: string = 'Todos'
  public argumento: string = ''

  public exibirImagem: boolean = true;

  public usuarioAdmin = false;

  filtroAcervo() {
    console.log("Filtro");
    this.getAcervos();
  }

  constructor(
    private router: Router,
    public dialog: MatDialog,
    private acervoService: AcervoService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private usuarioService: UsuarioService
  ) {}

  ngOnInit(): void {
    this.getUserName();
    this.getAcervos();
  }

  public getUserName(): void {
    this.spinnerService.show()

    this.usuarioService
      .getUsuarioByUserName()
      .subscribe(
        (usuario: Usuario) => {
          if (usuario.userName === "Admin")
            this.usuarioAdmin = true
        }
      )
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  public getAcervos(): void {
    this.spinnerService.show();

    this.acervoService
      .getAcervosPaginacao(
        this.paginacao.paginaCorrente,
        this.paginacao.itensPorPagina,
        this.argumento,
        this.opcaoPesquisa
      )
      .subscribe(
        (retorno: ResultadoPaginado<Acervo[]>) => {
          this.acervos = retorno.resultado;
          this.paginacao = retorno.paginacao;
        },
        (error: any) => {
          console.log("aqui 2");
          this.toastrService.error("Erro ao carregar Acervos", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public abrirModal(
    event: any,
    acervoId: number,
    acervoISBN: string
  ): void {
    event.stopPropagation();

    this.acervoId = acervoId;
    this.acervoISBN = acervoISBN;
    console.log(this.acervoId)

    this.validarAcervo(this.acervoId)
    console.log("alocado? ", this.acervoAlocado)
  }

  public confirmarDelecao(): void {
    this.spinnerService.show();

    this.acervoService
      .deleteAcervo(this.acervoId)
      .subscribe(
        (result: any) => {
          if (result == null)
            this.toastrService.error(
              "Acervo não pode se excluído.",
              "Erro!"
            );

          if (result.message == "OK") {
            this.toastrService.success(
              "Acervo excluído com sucesso",
              "Excluído!"
            );
            this.getAcervos();
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public validarAcervo(acervoId: number): void {
    this.spinnerService.show();

    this.acervoService
      .getAcervoById(acervoId)
      .subscribe(
        ( acervo: Acervo) => {
          this.acervo = acervo;
          console.log("valida ", this.acervo)
          if ((this.acervo.qtdeEmTransito + this.acervo.qtdeEmprestada) > 0)
            this.acervoAlocado = true

          if (!this.acervoAlocado) {
            const dialogRef = this.dialog.open(DeleteModalComponent, {
              data: {
                nomePagina: "Acervos",
                id: this.acervoId,
                argumento: this.acervoISBN,
              },
            });

            dialogRef.afterClosed().subscribe((result) => {
              console.log("The dialog was closed", result);
              if (result) this.confirmarDelecao();
            });
          } else {
            this.toastrService.info("Este livro está alocado em um empréstimo", "Informação!")
          }
        },
        (error: any) => {
          this.toastrService.error("Falha ao recuperar Acervo", `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public editarAcervo(acerovId: number): void {
    this.router.navigate([`acervos/edicao/${acerovId}`]);
  }

  public detalheAcervo(acerovId: number): void {
    this.router.navigate([`acervos/detalhe/${acerovId}`]);
  }

  public alteracaoDePagina(event: any): void {
    this.paginacao.paginaCorrente = event.currentPage
    this.getAcervos();
  }
}
