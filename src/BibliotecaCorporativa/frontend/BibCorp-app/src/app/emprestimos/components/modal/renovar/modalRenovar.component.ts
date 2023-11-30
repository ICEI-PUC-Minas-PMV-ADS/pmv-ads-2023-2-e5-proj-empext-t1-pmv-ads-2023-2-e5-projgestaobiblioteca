/* eslint-disable */

import { Component, Inject, OnInit } from "@angular/core";
import { MAT_DIALOG_DATA } from "@angular/material/dialog";
import { Router } from "@angular/router";
import { formatDate } from "@angular/common";
import { MatDialog } from "@angular/material/dialog";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { ModalSucessoComponent } from "../renovacao";
import { Acervo } from "src/app/acervos";
import { Emprestimo, EmprestimoService } from "src/app/emprestimos";
import { Patrimonio } from "src/app/patrimonios";

@Component({
  selector: "app-modal-renovar",
  templateUrl: "./modalRenovar.component.html",
  styleUrls: ["./modalRenovar.component.scss"],
})
export class ModalRenovarComponent implements OnInit {
  title = "angular-material";

  public emprestimoIdParam: any = "";
  public acervo: Acervo;
  public patrimonio: Patrimonio;
  public acervoTituloParam: any = "";
  public dataPrevistaDevolucaoParam: any = "";
  public emprestimo = {} as Emprestimo;

  constructor(
    private dialog: MatDialog,
    @Inject(MAT_DIALOG_DATA)
    public dataInput: {
      emprestimoId: number;
      acervoTitulo: string;
      dataPrevistaDevolucao: String;
      id: string;
    },
    private emprestimoService: EmprestimoService,
    private spinnerService: NgxSpinnerService,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.emprestimoIdParam = this.dataInput.emprestimoId;
    this.acervoTituloParam = this.dataInput.acervoTitulo;
    this.dataPrevistaDevolucaoParam = this.dataInput.dataPrevistaDevolucao;
  }

  fecharModalRenovarEAbrirModalSucesso() {
    const dialogRefAlterar = this.dataInput.id;
    if (dialogRefAlterar) {
      this.dialog.closeAll();
    }

    this.dialog.open(ModalSucessoComponent, {
      data: { emprestimoId: this.emprestimoIdParam },
      id: "Sucesso",
    });
  }

  public renovarEmprestimo(): void {
    this.spinnerService.show();

    this.emprestimoService
      .renovarEmprestimo(this.emprestimoIdParam)
      .subscribe(
        () => {
          this.fecharModalRenovarEAbrirModalSucesso();
        },
        (error: any) => {
          if (
            error.status === 400 &&
            error.error ==
              "Renovação não permitida pois o empréstimo já foi renovado anteriormente"
          ) {
            this.toastrService.error(
              "Não será possível realizar a renovação solicitada pois o empréstimo já foi renovado anteriormente"
            );
          } else if (error.status === 500) {
            this.toastrService.error(
              "Ocorreu um erro ao tentar renovar o empréstimo"
            );
          }
        }
      )
      .add(() => this.spinnerService.hide());
  }

  public formatarData(data: Date): any{
    var dataFormatada = formatDate(data, "dd/MM/YYYY","en-US")

    return dataFormatada
  }
}
