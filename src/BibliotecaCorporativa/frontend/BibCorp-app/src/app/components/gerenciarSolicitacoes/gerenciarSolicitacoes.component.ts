import { Component, OnInit } from '@angular/core';
import { Paginacao, ResultadoPaginado } from "src/app/shared";
import { Router } from "@angular/router";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";

import { AcervoService, EmprestimoService } from "src/app/services";
import { Acervo } from "src/app/models";


@Component({
  selector: 'app-gerenciar-solicitacoes',
  templateUrl: './gerenciarSolicitacoes.component.html',
  styleUrls: ['./gerenciarSolicitacoes.component.scss']
})
export class GerenciarSolicitacoesComponent implements OnInit {
  public acervos: Acervo[] = [];
  public paginacao = {} as Paginacao;
  public acervoId = 0;
  public exibirImagem: boolean = true;
  
  constructor(
    private router: Router,
    private acervoService: AcervoService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
   this.getAcervos();
  }

  public editarAcervo(acerovId: number): void {
    this.router.navigate([`acervos/edicao/${acerovId}`]);
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

  public alteracaoDePagina(event: any): void {
    //    this.pagination.currentPage = event.currentPage
  }

}
