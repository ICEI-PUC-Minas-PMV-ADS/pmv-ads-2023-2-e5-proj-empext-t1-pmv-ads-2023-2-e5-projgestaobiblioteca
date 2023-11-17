/* eslint-disable */

import { Component, Inject, OnInit} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { EmprestimoService, UsuarioService } from 'src/app/services';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Acervo, Emprestimo, Patrimonio, Usuario } from 'src/app/models';
import { formatDate } from '@angular/common';
import { ModalSucessoComponent } from '../modalSucesso';

@Component({
  selector: 'app-modal-renovar',
  templateUrl: './modalRenovar.component.html',
  styleUrls: ['./modalRenovar.component.scss']
})
export class ModalRenovarComponent implements OnInit {
  title = 'angular-material';

  public emprestimoIdParam: any = "";
  public acervo: Acervo;
  public patrimonio: Patrimonio;
  public acervoTituloParam: any = "";
  public dataPrevistaDevolucaoParam: any = "";
  public emprestimo = {} as Emprestimo;

  constructor(
  private dialog: MatDialog,
  @Inject(MAT_DIALOG_DATA) public dataInput: { emprestimoId: number, acervoTitulo: string, dataPrevistaDevolucao: String, id: string},
  private router: Router,
  private emprestimoService: EmprestimoService,
  private spinnerService: NgxSpinnerService,
  private toastrService: ToastrService,
  public usuarioService: UsuarioService,
  ) {  }

  ngOnInit(): void {

    this.emprestimoIdParam = this.dataInput.emprestimoId;
    this.acervoTituloParam = this.dataInput.acervoTitulo;
    this.dataPrevistaDevolucaoParam = this.dataInput.dataPrevistaDevolucao;
  }


  fecharModalRenovarEAbrirModalSucesso() {
    const dialogRefRenovar = this.dataInput.id
    if (dialogRefRenovar) {
      this.dialog.closeAll();
    }

    this.dialog.open(ModalSucessoComponent, {
      data: {emprestimoId: this.emprestimoIdParam}, id: 'Sucesso'
    });
  }

public renovarEmprestimo(): void {
  this.spinnerService.show();

  this.emprestimoService.renovarEmprestimo(this.emprestimoIdParam).subscribe(
    () => {
      this.fecharModalRenovarEAbrirModalSucesso()
    },
    (error: any) => {
      this.toastrService.error("Ocorreu um erro ao tentar renovar o empréstimo");
      console.error(error)
    }
  )
    .add(() => this.spinnerService.hide())
}



}
