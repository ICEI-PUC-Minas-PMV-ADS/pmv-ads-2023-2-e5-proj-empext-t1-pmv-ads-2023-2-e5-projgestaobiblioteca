import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Emprestimo, EmprestimoService } from 'src/app/emprestimos';


@Component({
  selector: 'app-modal-sucesso-alteracao',
  templateUrl: './modalSucessoAlteracao.component.html',
  styleUrls: ['./modalSucessoAlteracao.component.scss']
})
export class ModalSucessoAlteracaoComponent implements OnInit {
  title = 'angular-material';

  public emprestimoAtualizado = {} as Emprestimo;
  public novaLocalColeta: any = "";
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
          this.novaLocalColeta = this.emprestimoAtualizado.localDeColeta
        },
        (error: any) => {
          this.toastrService.error("Erro ao carregar emprestimo", 'Erro!');
          console.error(error);
        }

      )

      .add(() => this.spinnerService.hide());
  }


}
