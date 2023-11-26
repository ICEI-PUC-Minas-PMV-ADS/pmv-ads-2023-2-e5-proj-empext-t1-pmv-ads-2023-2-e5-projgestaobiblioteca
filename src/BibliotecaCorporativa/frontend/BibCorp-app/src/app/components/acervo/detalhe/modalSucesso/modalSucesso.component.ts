import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';


@Component({
  selector: 'app-modal-sucesso',
  templateUrl: './modalSucesso.component.html',
  styleUrls: ['./modalSucesso.component.scss']
})
export class ModalSucessoComponent implements OnInit {
  title = 'angular-material';

  public localEntrega: string;

  constructor(@Inject(MAT_DIALOG_DATA) public dataInput: { localEntrega: string },
  private router: Router,
  private dialog: MatDialog) {  }

  ngOnInit(): void {
    this.localEntrega = this.dataInput.localEntrega;
    
  }
  
  voltarParaAcervoDetalhe() {
    this.router.navigate(['/acervos/detalhe']); //direcionar para tela Meus Empréstimos/Minhas Reservas
  
    const dialogRefSucesso = this.dialog.getDialogById('Sucesso'); 
    if (dialogRefSucesso) {
      dialogRefSucesso.close();
    }
  }

  consultarSolicitacoes() {
    this.router.navigate(['/solicitacoes']); //direcionar para tela Meus Empréstimos/Minhas Reservas
  
    const dialogRefSucesso = this.dialog.getDialogById('Sucesso'); 
    if (dialogRefSucesso) {
      dialogRefSucesso.close();
    }
  }
  

}
