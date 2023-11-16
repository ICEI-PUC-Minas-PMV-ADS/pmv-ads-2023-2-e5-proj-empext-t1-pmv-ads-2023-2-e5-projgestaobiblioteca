/* eslint-disable */

import { Component, Inject, OnInit} from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { AcervoService, EmprestimoService, PatrimonioService, UsuarioService } from 'src/app/services';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Acervo, Emprestimo, Patrimonio, Usuario } from 'src/app/models';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-modal-renovar',
  templateUrl: './modalRenovar.component.html',
  styleUrls: ['./modalRenovar.component.scss']
})
export class ModalRenovarComponent implements OnInit {
  title = 'angular-material';

  public emprestimoParam: any = "";
  public acervo: Acervo;
  public acervoParam: any = "";
  public patrimonio: Patrimonio;
  public patrimonioParam: any = "";
  public emprestimo = {} as Emprestimo;
  public localEntrega: string;
  public localColeta: string;
  public usuarioAtivo = {} as Usuario;

  constructor(@Inject(MAT_DIALOG_DATA) public dataInput: { acervoId: number, patrimonioId: number},
  private router: Router,
  private emprestimoService: EmprestimoService,
  private spinnerService: NgxSpinnerService,
  private toastrService: ToastrService,
  private dialog: MatDialog,
  private acervoService: AcervoService,
    public usuarioService: UsuarioService,
    private patrimonioService: PatrimonioService,
    private activatedRouter: ActivatedRoute,
  ) {  }

  ngOnInit(): void {

    this.acervoParam = this.dataInput.acervoId;
    this.patrimonioParam = this.dataInput.patrimonioId;

  }

  voltar() {
    this.router.navigate(['/acervos/detalhe']);
}

}
