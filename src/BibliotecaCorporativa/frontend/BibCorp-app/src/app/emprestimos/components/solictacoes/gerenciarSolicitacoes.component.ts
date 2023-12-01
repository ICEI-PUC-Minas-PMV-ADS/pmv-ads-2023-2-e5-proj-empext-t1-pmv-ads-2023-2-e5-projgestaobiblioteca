import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { formatDate } from "@angular/common";

import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";

import {
  GerenciamentoEmprestimo,
  TipoAcaoEmprestimo,
} from "src/app/emprestimos/models/emprestimo/GerenciamentoEmprestimo";
import { Emprestimo, EmprestimoService } from "src/app/emprestimos";

@Component({
  selector: "app-gerenciar-solicitacoes",
  templateUrl: "./gerenciarSolicitacoes.component.html",
  styleUrls: ["./gerenciarSolicitacoes.component.scss"],
})
export class GerenciarSolicitacoesComponent implements OnInit {
  public exibirImagem: boolean = true;
  public emprestimos: Emprestimo[] = [];
  public emprestimo: Emprestimo;
  public emprestimoAlterado: Emprestimo;
  public gerenciamentoEmprestimo: GerenciamentoEmprestimo;
  public tipoAcaoEmprestimo: TipoAcaoEmprestimo;
  public statusPendentesDeAtuacao: string[]

  constructor(
    private router: Router,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService,
    private emprestimoService: EmprestimoService
  ) {}

  ngOnInit(): void {
    
    this.getEmprestimosPendentes();
    this.gerenciamentoEmprestimo = new GerenciamentoEmprestimo();
  }

  public editarAcervo(acerovId: number): void {
    this.router.navigate([`acervos/edicao/${acerovId}`]);
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  public alteracaoDePagina(event: any): void {
    //    this.pagination.currentPage = event.currentPage
  }

  public getEmprestimosPendentes(): void {
    this.spinnerService.show();

    this.statusPendentesDeAtuacao = ["Reservado","Emprestado","Renovado"]

    this.emprestimoService
      .getEmprestimosPendentes(this.statusPendentesDeAtuacao)
      .subscribe(
        (retorno: Emprestimo[]) => {
          this.emprestimos = retorno;
        },
        (error: any) => {
          this.toastrService.error("Erro ao buscar os empréstimos pendentes de atuação", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public obterStatus(emprestimoStatus: number): any {
    if (emprestimoStatus === 1) {
      return "Aguardando aprovação";
    } else if (emprestimoStatus === 2 || emprestimoStatus === 4) {
      return "Aguardando devolução";
    } else if (emprestimoStatus === 3 || emprestimoStatus === 5) {
      return "Solicitação concluída";
    }
  }

  public formatarData(data: Date): any{
    var dataFormatada = formatDate(data, "dd/MM/YYYY","en-US")

    return dataFormatada
  }

  public gerenciarEmprestimo(emprestimoId: number, acao: string): void {
    this.spinnerService.show();

    if (acao === "Aprovar") {
      console.log(this.gerenciamentoEmprestimo);
      this.gerenciamentoEmprestimo.acao = TipoAcaoEmprestimo.Aprovar;
    } else if (acao === "Recusar") {
      this.gerenciamentoEmprestimo.acao = TipoAcaoEmprestimo.Recusar;
    } else if (acao === "Devolver") {
      this.gerenciamentoEmprestimo.acao = TipoAcaoEmprestimo.Devolver;
    }

    this.emprestimoService
      .gerenciarEmprestimo(emprestimoId, this.gerenciamentoEmprestimo)
      .subscribe(
        (retorno: Emprestimo) => {
          this.emprestimoAlterado = retorno;
          this.ngOnInit();
        },
        (error: any) => {
          this.toastrService.error("Erro ao gerenciar o empréstimo", "Erro!");
          console.error(error);
        }
      )
      .add(() => this.spinnerService.hide());
  }
}
