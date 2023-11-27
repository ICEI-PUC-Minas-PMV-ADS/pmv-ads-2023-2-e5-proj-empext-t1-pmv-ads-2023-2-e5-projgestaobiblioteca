import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { Router } from "@angular/router";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Acervo } from "src/app/acervos";

import { AcervoService } from "src/app/services";
import { DeleteModalComponent, Paginacao, ResultadoPaginado } from "src/app/shared";


@Component({
  selector: "app-acervoLista",
  templateUrl: "./acervoLista.component.html",
  styleUrls: ["./acervoLista.component.scss"],
})
export class AcervoListaComponent implements OnInit {
  public acervos: Acervo[] = [];

  public paginacao = {} as Paginacao;

  public acervoId = 0;
  public acervoISBN = "";

  public opcaoPesquisa: string = 'Todos'
  public argumento: string = ''

  public exibirImagem: boolean = true;

  filtroAcervo() {
    console.log("Filtro");
    this.getAcervos();
  }

  constructor(
    private router: Router,
    public dialog: MatDialog,
    private acervoService: AcervoService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getAcervos();
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
      .add(() => this.spinnerService.show());
  }

  public editarAcervo(acerovId: number): void {
    this.router.navigate([`acervos/edicao/${acerovId}`]);
  }

  public detalheAcervo(acerovId: number): void {
    this.router.navigate([`acervos/detalhe/${acerovId}`]);
  }

  public alteracaoDePagina(event: any): void {
    //    this.pagination.currentPage = event.currentPage
    this.getAcervos();
  }
}
