import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { Router } from "@angular/router";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";

import {
  DeleteModalComponent,
  Paginacao,
  ResultadoPaginado,
} from "src/app/shared";
import { Patrimonio } from "../../models";
import { PatrimonioService } from "../../services";

@Component({
  selector: "app-patrimonioLista",
  templateUrl: "./patrimonioLista.component.html",
  styleUrls: ["./patrimonioLista.component.scss"],
})
export class PatrimonioListaComponent implements OnInit {
  animal: string;
  name: string;

  public patrimonios: Patrimonio[] = [];
  public patrimonio: Patrimonio;
  public PatrimonioFiltrados: any = [];

  public paginacao = {} as Paginacao;

  public patrimonioId = 0;
  public patrimonioISBN = "";

  public argumento: string = "";
  public opcaoPesquisa: string = "Todos";

  public exibirImagem: boolean = true;

  public capaLivro =
    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSAvSXCxMVWmCqcYHAvsrPZXmy2OkBeGy1-fbuCX2yfV5duFlE84Bk7C_APCxidn5u9cE0&usqp=CAU";

  filtroPatrimonio() {
    console.log("Filtro");
    this.getPatrimonios();
  }

  constructor(
    private router: Router,
    public dialog: MatDialog,
    private patrimonioService: PatrimonioService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.getPatrimonios();
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  public getPatrimonios(): void {
    this.spinnerService.show();

    this.patrimonioService
      .getPatrimoniosPaginacao(
        this.paginacao.paginaCorrente,
        this.paginacao.itensPorPagina,
        this.argumento,
        this.opcaoPesquisa
      )
      .subscribe(
        (retorno: ResultadoPaginado<Patrimonio[]>) => {
          this.patrimonios = retorno.resultado;
          this.paginacao = retorno.paginacao;

          console.log(this.patrimonios);
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
    patrimonioId: number,
    patrimonioISBN: string
  ): void {
    event.stopPropagation();
    this.patrimonioId = patrimonioId;
    this.patrimonioISBN = patrimonioISBN;
    this.patrimonioService
      .getPatrimonioById(patrimonioId)
      .subscribe(
        (patrimonio: Patrimonio) => {
          this.patrimonio = patrimonio

          if (this.patrimonio.acervoId === null) {
            const dialogRef = this.dialog.open(DeleteModalComponent, {
              data: {
                nomePagina: "Patrimônios",
                id: this.patrimonioId,
                argumento: this.patrimonioISBN,
              },
            });

            dialogRef.afterClosed().subscribe((result) => {
              console.log("The dialog was closed", result);
              if (result) this.confirmarDelecao();
            });
          } else {
            this.toastrService.info("Este patrimônio está associado à um acervo e não pode ser excluído!", "Informação!")
          }
        }
      )
  }

  public confirmarDelecao(): void {
    this.spinnerService.show();

    this.patrimonioService
      .deletePatrimonio(this.patrimonioId)
      .subscribe(
        (result: any) => {
          if (result == null)
            this.toastrService.error(
              "Patrimonio não pode se excluído.",
              "Erro!"
            );

          if (result.message == "OK") {
            this.toastrService.success(
              "Patrimonio excluído com sucesso",
              "Excluído!"
            );
            this.getPatrimonios();
          }
        },
        (error: any) => {
          this.toastrService.error(error.error, `Erro! Status ${error.status}`);
          console.error(error);
        }
      )
      .add(() => this.spinnerService.show());
  }

  public editarPatrimonio(patrimonioId: number): void {
    this.router.navigate([`patrimonios/detalhe/${patrimonioId}`]);
  }

  public alteracaoDePagina(event: any): void {
    //    this.pagination.currentPage = event.currentPage
    this.getPatrimonios();
  }
}
