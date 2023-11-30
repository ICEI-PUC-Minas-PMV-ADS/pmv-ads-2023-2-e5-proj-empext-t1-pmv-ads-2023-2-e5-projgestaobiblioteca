import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { formatDate } from "@angular/common";
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Emprestimo, EmprestimoService } from 'src/app/emprestimos';


@Component({
  selector: 'app-modal-sucesso',
  templateUrl: './modalSucessoRenovacao.component.html',
  styleUrls: ['./modalSucessoRenovacao.component.scss']
})
export class ModalSucessoComponent implements OnInit {
  title = 'angular-material';

  public emprestimoAtualizado = {} as Emprestimo;
  public novaDataPrevistaDevolucao: any = "";
  public emprestimoIdParam: any = "";

  constructor(@Inject(MAT_DIALOG_DATA) public dataInput: { emprestimoId: number },
  private router: Router,
  private emprestimoService: EmprestimoService,
  private spinnerService: NgxSpinnerService,
  private toastrService: ToastrService,
  private dialog: MatDialog) {  }

  ngOnInit(): void {

    this.emprestimoIdParam = this.dataInput.emprestimoId;
    this.getEmprestimoById(this.emprestimoIdParam);
  }

  voltarParaMinhasSolicitacoes() {
    this.router.navigate(['/solicitacoes']);

    const dialogRefSucesso = this.dialog.getDialogById('Sucesso');
    if (dialogRefSucesso) {
      dialogRefSucesso.close();
    }
  }

  public getEmprestimoById(id: number): void {
    this.spinnerService.show();

    this.emprestimoService
      .getEmprestimoById(id)
      .subscribe(
        (retorno: Emprestimo) => {
          this.emprestimoAtualizado = retorno;
          this.novaDataPrevistaDevolucao = this.emprestimoAtualizado.dataPrevistaDevolucao
        },
        (error: any) => {
          this.toastrService.error("Erro ao carregar emprestimo", 'Erro!');
          console.error(error);
        }

      )

      .add(() => this.spinnerService.hide());
  }

  public formatarData(data: Date): any{
    var dataFormatada = formatDate(data, "dd/MM/YYYY","en-US")

    return dataFormatada
  }


}
